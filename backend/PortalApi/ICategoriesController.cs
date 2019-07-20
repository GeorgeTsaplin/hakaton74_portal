
using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Latitude55.Api.Models;


namespace Latitude55.Api
{
    public interface ICategoriesController
    {

        Task<IActionResult> Get();
    }
}