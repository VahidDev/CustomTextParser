namespace Repository.RepositoryServices.Abstraction
{
    public interface IUnitOfWork
    {
        ITransactionRepository TransactionRepository { get; }
        Task CompleteAsync();
        void Dispose();
    }
}
