
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Latitude55.Api.Models;

namespace Latitude55.Api
{
    public partial class PredictionController : IPredictionController
    {

		/// <summary>
		/// Получение статистики с группировкой по Категориям услуг - /byCategories
		/// </summary>
		/// <returns>Statistics[]</returns>
        public async Task<IActionResult> Get()
        {
            // TODO: implement Get - route: prediction/byCategories
			// var result = new Statistics[]();
			// return Ok(result);
			return Ok();
        }

		/// <summary>
		/// Получение статистики с группировкой по Услугам указанной Категории - /{category}
		/// </summary>
		/// <param name="category">ID Категории услуг</param>
		/// <returns>Statistics[]</returns>
        public async Task<IActionResult> GetByCategory([FromUri] int category)
        {
            // TODO: implement GetByCategory - route: prediction/byCategories/{category}
			// var result = new Statistics[]();
			// return Ok(result);
			return Ok();
        }

    }
}