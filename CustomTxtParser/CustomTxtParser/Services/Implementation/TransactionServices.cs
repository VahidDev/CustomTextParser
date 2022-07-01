using AutoMapper;
using CustomTxtParser.Services.Abstraction;
using DomainModels.Models.Entities;
using DomainModels.Models.ViewModels;
using Repository.RepositoryServices.Abstraction;

namespace CustomTxtParser.Services.Implementation
{
    public class TransactionServices : ITransactionServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITxtParserServices _txtParserServices;
        private readonly IMapper _mapper;

        public TransactionServices
            (IUnitOfWork unitOfWork
            , ITxtParserServices txtParserServices
            , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _txtParserServices = txtParserServices;
            _mapper = mapper;
        }

        public async Task<ICollection<TransactionIndexViewModel>> GetAllTransactionsAsync()
        {
            ICollection<TransactionIndexViewModel> transactions = _mapper
                .Map<ICollection<TransactionIndexViewModel>>
                (await _unitOfWork.TransactionRepository
                .GetAllWithItemsAsNoTrackingAsync());

            foreach (TransactionIndexViewModel transaction in transactions)
            {
                foreach (SettlementDetailViewModel settlementDetail in transaction.SettlementDetails)
                {
                    transaction.NetValueTotal += settlementDetail.NetValue;
                    transaction.CountGrossTotal += settlementDetail.CountTotal;
                    transaction.FeeAmountCreditTotal += settlementDetail.FeeAmountCredit;
                    transaction.FeeAmountDebitTotal += settlementDetail.FeeAmountDebit;
                    transaction.ReconciliationAmntCreditTotal += settlementDetail.ReconciliationAmntCredit;
                    transaction.ReconciliationAmntDebitTotal += settlementDetail.ReconciliationAmntDebit;
                    transaction.TransactionAmountCreditTotal += settlementDetail.TransactionAmountCredit;
                    transaction.TransactionAmountDebitTotal += settlementDetail.TransactionAmountDebit;
                }
            }
            return transactions;
        }

        public async Task ImportTransactionsAsync(TransactionImportViewModel model)
        {
           IReadOnlyCollection<Transaction> transactions = (await _txtParserServices
                .ReadFileAndGetTransactionsAsync(model.TextFile)).ToList();

            await _unitOfWork.TransactionRepository.AddRangeAsync(transactions);
            await _unitOfWork.CompleteAsync();
        }
    }
}
