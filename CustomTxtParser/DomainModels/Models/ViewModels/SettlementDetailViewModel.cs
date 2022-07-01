using DomainModels.Models.ViewModels.Base;

namespace DomainModels.Models.ViewModels
{
    public class SettlementDetailViewModel : BaseModel
    {
        public SettlementCategoryViewModel SettlementCategory { get; set; }
        public decimal TransactionAmountCredit { get; set; }
        public decimal TransactionAmountDebit { get; set; }
        public decimal ReconciliationAmntCredit { get; set; }
        public decimal ReconciliationAmntDebit { get; set; }
        public decimal FeeAmountCredit { get; set; }
        public decimal FeeAmountDebit { get; set; }
        public int CountTotal { get; set; }
        public decimal NetValue { get; set; }
    }
}
