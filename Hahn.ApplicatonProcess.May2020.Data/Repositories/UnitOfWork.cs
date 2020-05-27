
namespace Hahn.ApplicatonProcess.May2020.Data.Repositories
{
    using System.Threading.Tasks;
    using Domain.IRepository;
    
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context.ApplicationProcessContext _context;
        public UnitOfWork(Context.ApplicationProcessContext _context)
        {
            this._context = _context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
