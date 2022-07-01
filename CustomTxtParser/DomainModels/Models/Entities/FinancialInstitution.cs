using DomainModels.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.Models.Entities
{
    public class FinancialInstitution : Entity
    {
        [Display(Name = "Financial Institution")]
        public string InstitutionName { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
