
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Latitude55.Api.Models;


namespace Latitude55.Api
{
    public interface IServicesController
    {

        Task<IActionResult> Get();
        Task<IActionResult> Put(Models.Service service);
        Task<IActionResult> GetById([FromUri] string id);
        Task<IActionResult> Post(Models.ServiceItemSettings serviceitemsettings,[FromUri] string id);
        Task<IActionResult> PostSearches(Models.ServiceFilter servicefilter);
    }
}