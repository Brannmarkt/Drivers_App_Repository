namespace WebApi_RepositoryPattern.Core
{
    public interface IUnitOfWork
    {
        IDriverRepository Drivers { get; }
        Task CompleteAsync();
    }
}
