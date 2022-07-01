using DomainModels.Models.Enums;
using DomainModels.Models.ViewModels.Base;

namespace DomainModels.Models.ViewModels
{
    public class TransactionIndexViewModel : BaseModel
    {
        public FinancialInstitutionViewModel FinancialInstitution { get; set; }
        public DateTime FXSettlementDate { get; set; }
        public string ReconciliationFileID { get; set; }
        public CurrencyEnum TransactionCurrency { get; set; }
        public CurrencyEnum ReconciliationCurrency { get; set; }
        public ICollection<SettlementDetailViewModel> SettlementDetails { get; set; }
            = new List<SettlementDetailViewModel>();
        public decimal TransactionAmountCreditTotal { get; set; }
        public decimal TransactionAmountDebitTotal { get; set; }
        public decimal ReconciliationAmntCreditTotal { get; set; }
        public decimal ReconciliationAmntDebitTotal { get; set; }
        public decimal FeeAmountCreditTotal { get; set; }
        public decimal FeeAmountDebitTotal { get; set; }
        public int CountGrossTotal { get; set; }
        public decimal NetValueTotal { get; set; }

    }
}
