using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Latitude55.Api.Models;

namespace Latitude55.DAL
{
    public class ServicesRepository : RepositoryJson<ServiceItem>
    {
        public ServicesRepository(string filePath) : base(filePath)
        {
        }

        public async Task Save(ServiceItem item)
        {
            var allItems = (await this.GetAll()).ToList();

            // TODO g.tsaplin: must be .SingleOrDefault()
            var transientItem = allItems.FirstOrDefault(x => x.Id == item.Id);
            if (transientItem != null)
            {
                transientItem.Attributes = item.Attributes;
            }
            else
            {
                allItems.Add(item);
            }

            await this.Save(allItems);
        }
    }
}
