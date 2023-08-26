using Microsoft.EntityFrameworkCore;
using WebApi_RepositoryPattern.Data;
using WebApi_RepositoryPattern.Models;

namespace WebApi_RepositoryPattern.Core.Repositories
{
    public class DriverRepository : GenericRepository<Driver>, IDriverRepository
    {
        public DriverRepository(ApiDbContext context, ILogger logger) : base(context, logger)
        {

        }

        public override async Task<IEnumerable<Driver>> GetAll()
        {
            try
            {
                return await _dbContext.Drivers.ToListAsync();
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public override async Task<Driver?> GetById(int Id)
        {
            try
            {
                return await _dbContext.Drivers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<Driver?> GetDriverNumber(int number)
        {
            try
            {
                return await _dbContext.Drivers.FirstOrDefaultAsync(x => x.DriverNumber == number);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
