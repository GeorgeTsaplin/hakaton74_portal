﻿
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Latitude55.Api.Models;

// Do not modify this file. This code was generated by RAML Web Api 2 Scaffolder

namespace Latitude55.Api
{
    [Route("api/[controller]")]
    public partial class ServicesController : Controller
    {


        /// <summary>
		/// Получить перечень Государственных услуг - /services
		/// </summary>
		/// <returns>Service[]</returns>
        [HttpGet]
        [Route("")]
        public virtual async Task<IActionResult> GetBase()
        {
            // Do not modify this code
            return await ((IServicesController)this).Get();
        }

        /// <summary>
		/// Добавить новую услугу - /services
		/// </summary>
		/// <param name="service"></param>
        [HttpPut]
        [Route("")]
        public virtual async Task<IActionResult> PutBase(Models.Service service)
        {
            // Do not modify this code
            return await ((IServicesController)this).Put(service);
        }

        /// <summary>
		/// Получить сведения о Государственной услуге - /{id}
		/// </summary>
		/// <param name="id"></param>
		/// <returns>ServiceItem</returns>
        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> GetByIdBase([FromRoute] string id)
        {
            // Do not modify this code
            return await ((IServicesController)this).GetById(id);
        }
    }
}
