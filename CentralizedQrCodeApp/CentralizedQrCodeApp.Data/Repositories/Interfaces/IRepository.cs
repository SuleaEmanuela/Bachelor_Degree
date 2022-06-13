using System.Linq;
using System.Threading.Tasks;

namespace CentralizedQrCodeApp.Data.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class ,new()
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetAsync(int id);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity id);
    }
}
