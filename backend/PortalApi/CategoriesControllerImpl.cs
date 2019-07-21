using System.Linq;
using System.Threading.Tasks;
using Latitude55.Api.Models;
using Latitude55.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Latitude55.Api
{
    public partial class CategoriesController : ICategoriesController
    {
        private readonly RepositoryJson<Category> repo;

        public CategoriesController()
        {
            this.repo = new DAL.RepositoryJson<Category>(@".\Data\categories.json");
        }

        /// <summary>
        /// Получить список категорий услуг - /categories
        /// </summary>
        /// <returns>Category[]</returns>
        public async Task<IActionResult> Get()
            => Ok((await this.repo.GetAll()).OrderBy(x => x.Name));
    }
}