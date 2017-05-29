using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Common.Service.Dictionary.Controllers
{
    [Route("api/[controller]")]
    public class MarginTradingAssetController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

       
    }
}
