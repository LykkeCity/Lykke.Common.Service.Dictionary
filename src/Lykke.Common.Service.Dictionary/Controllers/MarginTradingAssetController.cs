using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lykke.Common.Entities.Dictionaries;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Common.Service.Dictionary.Controllers
{
    [Route("api/[controller]")]
    public class MarginTradingAssetController : Controller
    {
        private readonly IMarginTradingAssetsRepository _marginTradingAssetsRepository;

        public MarginTradingAssetController(IMarginTradingAssetsRepository marginTradingAssetsRepository)
        {
            _marginTradingAssetsRepository = marginTradingAssetsRepository;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<MarginTradingAsset>> Get()
        {
            return (await _marginTradingAssetsRepository.GetAllAsync()).Select(MarginTradingAsset.Create);
        }

       
    }
}
