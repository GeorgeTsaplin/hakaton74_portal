using Microsoft.AspNetCore.Mvc;

namespace Latitude55.Api
{
    /// <summary>
    /// Used for compatibility with RAMLGen, which generates ASP.Net WebApi instead of ASP.Net Core
    /// </summary>
    public class FromUriAttribute : FromRouteAttribute
    {
    }
}
