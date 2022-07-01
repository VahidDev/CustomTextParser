using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DomainModels.Models.ViewModels
{
    public class TransactionImportViewModel
    {
        [Required(ErrorMessage = "You must include the transactions file")]
        public IFormFile TextFile { get; set; }
    }
}
