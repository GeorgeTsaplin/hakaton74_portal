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
        private readonly RepositoryJson<Service> repo;

        public ServicesController()
        {
            this.repo = new DAL.RepositoryJson<Service>(@".\Data\services.json");
        }

        /// <summary>
        /// Получить перечень Государственных услуг - /services
        /// </summary>
        /// <returns>Service[]</returns>
        public async Task<IActionResult> Get()
            => Ok((await this.repo.GetAll()).OrderBy(x => x.Name));

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
        {
            // TODO: implement GetById - route: services/{id}
			// var result = new ServiceItem();
			// return Ok(result);
			return Ok();
        }

    }
}