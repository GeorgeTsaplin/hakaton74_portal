using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Latitude55.DAL
{
    public class RepositoryJson<T> : IRepository<T>
        where T : class
    {
        private readonly string filePath;

        public RepositoryJson(string filePath)
        {
            this.filePath = filePath;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            // TODO g.tsaplin: implement cache
            using (StreamReader r = new StreamReader(this.filePath))
            {
                string json = await r.ReadToEndAsync();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
        }

        protected virtual async Task Save(IEnumerable<T> items)
        {
            using (StreamWriter w = new StreamWriter(this.filePath))
            {
                await w.WriteLineAsync('[');

                int i = items.Count();

                foreach (var item in items)
                {
                    await w.WriteLineAsync(JsonConvert.SerializeObject(item) + (--i > 0 ? "," : string.Empty));
                }

                await w.WriteLineAsync(']');
            }
        }
    }
}
