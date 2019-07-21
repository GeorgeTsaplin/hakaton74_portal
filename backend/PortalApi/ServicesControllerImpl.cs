using System;
using System.Linq;
using System.Threading.Tasks;
using Latitude55.Api.Models;
using Latitude55.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Latitude55.Api
{
    public partial class ServicesController : IServicesController
    {
        private readonly ServicesRepository repo;

        public ServicesController()
        {
            this.repo = new DAL.ServicesRepository(@".\Data\services.json");
        }

        /// <summary>
        /// Получить перечень Государственных услуг - /services
        /// </summary>
        /// <returns>Service[]</returns>
        public async Task<IActionResult> Get()
            => Ok((await this.repo.GetAll()).Cast<Service>().OrderBy(x => x.Name));

		/// <summary>
		/// Добавить новую услугу - /services
		/// </summary>
		/// <param name="service"></param>
        public async Task<IActionResult> Put(Models.Service service)
        {
            throw new NotImplementedException();
            // TODO: implement Put - route: services/
			return Ok();
        }

        /// <summary>
        /// Получить сведения о Государственной услуге - /{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ServiceItem</returns>
        public async Task<IActionResult> GetById([FromUri] string id)
            => Ok((await this.repo.GetAll()).Where(x => x.Id == id));

        public async Task<IActionResult> PostSearches(ServiceFilter servicefilter)
            => Ok((await this.repo.GetAll())
                .Where(x => (servicefilter.CategoryId == null || x.Category == servicefilter.CategoryId)
                    && (servicefilter.IsConfigured == null
                        || (servicefilter.IsConfigured.Value && x.Attributes?.Any() == true)
                        || (!servicefilter.IsConfigured.Value && !x.Attributes?.Any() != true)))
                .OrderBy(x => x.Name));

        public async Task<IActionResult> Post(ServiceItemSettings serviceitemsettings, [FromUri] string id)
        {
            // TODO g.tsaplin: must be .Single()
            var item = (await this.repo.GetAll()).First(x => x.Id == id);

            item.Attributes = serviceitemsettings?.Attributes.OrderBy(x => x.Value).ToArray();

            await this.repo.Save(item);

            return Ok(item);
        }
    }
}