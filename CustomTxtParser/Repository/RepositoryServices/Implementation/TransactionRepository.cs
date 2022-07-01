using DomainModels.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository.DAL;
using Repository.RepositoryServices.Abstraction;

namespace Repository.RepositoryServices.Implementation
{
    internal class TransactionRepository 
        : GenericRepository<Transaction>
        , ITransactionRepository
    {
        public TransactionRepository(AppDbContext context, ILogger logger) 
            : base(context, logger) { }

        public async Task<ICollection<Transaction>> GetAllWithItemsAsNoTrackingAsync()
        {
            return await dbSet
                .Where(r => !r.IsDeleted)
                .Include(t => t.FinancialInstitution)
                .Include(t => t.SettlementDetails)
                .ThenInclude(d => d.SettlementCategory)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
