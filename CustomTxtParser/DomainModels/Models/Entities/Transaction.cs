using DomainModels.Models.Entities.Base;
using DomainModels.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.Models.Entities
{
    public class Transaction : Entity
    {
        [Display(Name = "Financial Institution")]
        public FinancialInstitution FinancialInstitution { get; set; }
        [Display(Name = "FX Settlement Date")]
        public DateTime FXSettlementDate { get; set; }
        [Display(Name = "Reconciliation File ID")]
        public string ReconciliationFileID { get; set; }
        [Display(Name = "Transaction Currency")]
        public CurrencyEnum TransactionCurrency { get; set; }
        [Display(Name = "Reconciliation Currency")]
        public CurrencyEnum ReconciliationCurrency { get; set; }
        public ICollection<SettlementDetail> SettlementDetails { get; set; }
            = new List<SettlementDetail>();
    }
}
