﻿using DomainModels.Models.Entities;

namespace Repository.RepositoryServices.Abstraction
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Task<ICollection<Transaction>> GetAllWithItemsAsNoTrackingAsync();
    }
}
