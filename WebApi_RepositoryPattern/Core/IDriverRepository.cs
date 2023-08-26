using WebApi_RepositoryPattern.Models;

namespace WebApi_RepositoryPattern.Core
{
    public interface IDriverRepository : IGenericRepository<Driver>
    {
        Task<Driver?> GetDriverNumber(int number);
    }
}
