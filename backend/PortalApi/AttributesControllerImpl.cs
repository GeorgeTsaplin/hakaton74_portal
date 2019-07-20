
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Latitude55.Api.Models;

namespace Latitude55.Api
{
    public partial class AttributesController : IAttributesController
    {

		/// <summary>
		/// Получить список всех атрибутов Портрета пользователя - /attributes
		/// </summary>
		/// <returns>Attribute[]</returns>
        public async Task<IActionResult> Get()
        {
            // TODO: implement Get - route: attributes/
			// var result = new Attribute[]();
			// return Ok(result);
			return Ok();
        }

    }
}