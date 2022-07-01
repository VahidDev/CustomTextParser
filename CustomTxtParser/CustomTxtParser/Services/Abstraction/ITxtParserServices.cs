using DomainModels.Models.Entities;

namespace CustomTxtParser.Services.Abstraction
{
    public interface ITxtParserServices
    {
        Task<ICollection<Transaction>> ReadFileAndGetTransactionsAsync(IFormFile file);
    }
}
