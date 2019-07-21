
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Latitude55.Api.Models;
using Latitude55.DAL;
using System.Linq;

namespace Latitude55.Api
{
    public partial class AttributesController : IAttributesController
    {
        private readonly RepositoryJson<Models.Attribute> repo;

        public AttributesController()
        {
            this.repo = new DAL.RepositoryJson<Models.Attribute>(@".\Data\attributes.json");
        }

        /// <summary>
        /// Получить список всех атрибутов Портрета пользователя - /attributes
        /// </summary>
        /// <returns>Attribute[]</returns>
        public async Task<IActionResult> Get()
            => Ok((await this.repo.GetAll()).OrderBy(x => x.Value));
    }
}