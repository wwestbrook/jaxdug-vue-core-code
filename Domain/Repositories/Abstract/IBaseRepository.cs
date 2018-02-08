using System.Linq;
using System.Threading.Tasks;

namespace VueDemo.Domain.Repositories.Abstract
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> Get();
        Task<T> Find(int id);
        Task Save(T entity);
        Task Save(T entity, int id);
        Task Remove(int id);
    }
}
