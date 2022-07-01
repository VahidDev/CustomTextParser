using CustomTxtParser.Constants;
using CustomTxtParser.Extensions;
using CustomTxtParser.Services.Abstraction;
using CustomTxtParser.Utilities.TransactionUtilities;
using DomainModels.Models.Entities;
using System.Text.RegularExpressions;

namespace CustomTxtParser.Services.Implementation
{
    public class TxtParserServices : ITxtParserServices
    {
        private readonly IRuntimeServices _runtimeServices;

        public TxtParserServices(IRuntimeServices runtimeServices)
        {
            _runtimeServices = runtimeServices;
        }

        public async Task<ICollection<Transaction>> ReadFileAndGetTransactionsAsync(IFormFile file)
        {
            StreamReader reader = new (file.OpenReadStream());
            string text = await reader.ReadToEndAsync(); 
            reader.Close();

            List<string> transactionTitles = new();
            List<string> transactionDetails = new();
            
            bool isTitleFinished = false;
            int counterTable = 0;
            int counterTitle = 0;

            // In the first loop we collect Transaction Titles and Transaction Details
            // into collections (transactionTitles and transactionDetails)
            for (int i = 0, j = i; i < text.Length; i++)
            {
                if (text[i] == '+' && !isTitleFinished)
                {
                    StringUtilitites.AddSubStrToCollection(transactionTitles, 
                        text, j, counterTitle);

                    isTitleFinished = true;
                    j = i;
                    counterTitle = 0;
                }
                else if (!isTitleFinished && text[i] != '+')
                {
                    counterTitle++;
                }

                if (isTitleFinished)
                {
                    //TextFileConstants.SeperatorKeyword is a keyword that
                    //we use to separate transaction titles from transaction details
                    if (text.Length >= i + TextFileConstants.SeperatorKeyword.Length 
                        || text.IsLastIndex(i))
                    {
                        if (text.IsLastIndex(i))
                        {
                            StringUtilitites
                                .AddSubStrToCollection(transactionDetails, 
                                text, j, null);
                        }
                        else if (text.IsSubStrEqualToSpecificStr(i, 
                            TextFileConstants.SeperatorKeyword))
                        {
                            StringUtilitites
                                .AddSubStrToCollection(transactionDetails, 
                                text, j, counterTable);

                            isTitleFinished = false;
                            counterTable = 0;
                            j = i;
                        }
                        else
                        {
                            counterTable++;
                        }
                    }
                }
            }
            List<Transaction> transactions = new ();

            //these are used to create unique entities without any duplicates
            List<SettlementCategory> settlementCategories = new ();
            List<FinancialInstitution> financialInstitutions = new ();

            // In the second loop we use simple string manipulations to
            // get all the needed data into dictionaries
            for (int i = 0; i < transactionTitles.Count; i++)
            {
                string[] titlePairs = transactionTitles[i]
                    .Trim()
                    .Split(new char[] { '\n', '\r' },
                    StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, string> transactionTitlesDict = new();
                
                for (int j = 0; j < titlePairs.Length; j++)
                {
                    string[] nameAndValue = titlePairs[j].Split(":");
                    transactionTitlesDict
                        .Add(nameAndValue[0].Trim(), nameAndValue[1].Trim());
                }
                Transaction transaction = _runtimeServices
                   .CreateCustomObject<Transaction>(transactionTitlesDict);

                transaction.FinancialInstitution.InstitutionName
                        = Regex.Replace
                        (transaction.FinancialInstitution.InstitutionName
                        , @"\s+", " ");

                FinancialInstitution financialInstitution 
                    = financialInstitutions
                    .FirstOrDefault(i =>String.Equals(i.InstitutionName
                    ,transaction?.FinancialInstitution?.InstitutionName
                    ,StringComparison.OrdinalIgnoreCase));

                if (financialInstitution != null)
                {
                    transaction.FinancialInstitution = financialInstitution;
                }
                else
                {
                    financialInstitutions.Add(transaction.FinancialInstitution);
                }

                string[] detailPairs = transactionDetails[i]
                    .Trim()
                    .Split(new char[] { '\n', '\r' },
                    StringSplitOptions.RemoveEmptyEntries);

                string[] detailTitlesLeftPart = detailPairs[1]
                    .Trim()
                    .Split(new char[] { '\n', '\r', '!' },
                    StringSplitOptions.RemoveEmptyEntries);

                string[] detailTitlesRightPart = detailPairs[2]
                    .Trim()
                    .Split(new char[] { '\n', '\r', '!' },
                    StringSplitOptions.RemoveEmptyEntries);

                List<string> transactionDetailsTitles = new ();

                if (detailTitlesLeftPart.Length != detailTitlesRightPart.Length)
                {
                    throw new Exception("Invalid format");
                }

                for (int p = 0; p < detailTitlesLeftPart.Length; p++)
                {
                    transactionDetailsTitles
                        .Add($"{detailTitlesLeftPart[p].Trim()} " +
                        $"{detailTitlesRightPart[p].Trim()}");
                }

                List<string[]> transactionDetailsData = new ();

                for (int k = 4; k < detailPairs.Count() - 2; k++)
                {
                    string[] data = detailPairs[k]
                        .Trim()
                        .Split(new[] { "  ", "!" },
                        StringSplitOptions.RemoveEmptyEntries);
                    transactionDetailsData.Add(data);
                }

                Dictionary<string, string> transactionDetailsDict = new();

                foreach (string[] transactionDetailDataRow in transactionDetailsData)
                {
                    for (int l = 0; l < transactionDetailsTitles.Count; l++)
                    {
                        if (transactionDetailDataRow.Count() != transactionDetailsTitles.Count)
                        {
                            throw new Exception("Invalid format");
                        }
                        transactionDetailsDict
                            .Add(transactionDetailsTitles[l].Trim()
                            , transactionDetailDataRow[l].Trim());
                    }

                    SettlementDetail settlementDetail = _runtimeServices
                        .CreateCustomObject<SettlementDetail>(transactionDetailsDict);

                    SettlementCategory settlementCategory = settlementCategories
                        .FirstOrDefault(s =>String.Equals(s.CategoryName
                        ,settlementDetail?.SettlementCategory?.CategoryName
                        ,StringComparison.OrdinalIgnoreCase));

                    if (settlementCategory != null)
                    {
                        settlementDetail.SettlementCategory = settlementCategory;
                    }
                    else
                    {
                        settlementCategories.Add(settlementDetail.SettlementCategory);
                    }

                    transaction.SettlementDetails.Add(settlementDetail);
                    transactionDetailsDict.Clear();
                }
                transactions.Add(transaction);
            }
            return transactions;
        }
    }
}
