using System.Collections.Generic;
using System.Threading.Tasks;

namespace Latitude55.DAL
{
    public interface IRepository<T> where T: class
    {
        Task<IEnumerable<T>> GetAll();
    }
}
