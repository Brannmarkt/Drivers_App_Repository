using WebApi_RepositoryPattern.Core;
using WebApi_RepositoryPattern.Core.Repositories;

namespace WebApi_RepositoryPattern.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiDbContext _context;

        public IDriverRepository Drivers { get; private set; }

        public UnitOfWork(ApiDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            var _logger = loggerFactory.CreateLogger("logs");

            Drivers = new DriverRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
