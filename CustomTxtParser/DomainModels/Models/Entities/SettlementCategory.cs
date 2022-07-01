using DomainModels.Models.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.Models.Entities
{
    public class SettlementCategory : Entity
    {
        [Display(Name = "Settlement Category")]
        public string CategoryName { get; set; }
        public ICollection<SettlementDetail> SettlementDetails { get; set; }
    }
}
