using DomainModels.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.Models.Entities
{
    public class SettlementDetail : Entity
    {
        [Display(Name = "Settlement Category")]
        public SettlementCategory SettlementCategory { get; set; }
        [Display(Name = "Transaction Amount Credit")]
        public decimal TransactionAmountCredit { get; set; }
        [Display(Name = "Transaction Amount Debit")]
        public decimal TransactionAmountDebit { get; set; }
        [Display(Name = "Reconciliation Amnt Credit")]
        public decimal ReconciliationAmntCredit { get; set; }
        [Display(Name = "Reconciliation Amnt Debit")]
        public decimal ReconciliationAmntDebit { get; set; }
        [Display(Name = "Fee Amount Credit")]
        public decimal FeeAmountCredit { get; set; }
        [Display(Name = "Fee Amount Debit")]
        public decimal FeeAmountDebit { get; set; }
        [Display(Name = "Count Total")]
        public int CountTotal { get; set; }
        [Display(Name = "Net Value")]
        public decimal NetValue { get; set; }
        public Transaction Transaction { get; set; }
    }
}
