using DomainModels.Models.Entities;
using DomainModels.Models.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace Repository.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext
            (DbContextOptions<AppDbContext> options) : base(options) { }

        public async override Task<int> SaveChangesAsync
            (bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entity in ChangeTracker.Entries<IEntity>())
            {
                if (entity.State == EntityState.Modified && !entity.Entity.IsDeleted)
                {
                    entity.Entity.UpdatedAt = DateTime.Now;
                }
                else if (entity.State == EntityState.Added)
                {
                    entity.Entity.CreatedAt = DateTime.Now;
                }
                else if (entity.Entity.IsDeleted)
                {
                    entity.Entity.DeletedAt = DateTime.Now;
                }
            }
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<SettlementDetail> SettlementDetails { get; set; }
        public DbSet<SettlementCategory> SettlementCategories { get; set; }
        public DbSet<FinancialInstitution> FinancialInstitutions { get; set; }
    }
}
