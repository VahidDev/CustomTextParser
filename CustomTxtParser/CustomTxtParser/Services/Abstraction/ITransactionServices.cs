using DomainModels.Models.ViewModels;

namespace CustomTxtParser.Services.Abstraction
{
    public interface ITransactionServices
    {
        Task ImportTransactionsAsync(TransactionImportViewModel model);
        Task<ICollection<TransactionIndexViewModel>> GetAllTransactionsAsync();
    }
}
