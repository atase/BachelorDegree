using Kidney.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kidney.API.Controllers
{
    [Route("matching/")]
    [ApiController]
    public class MatchingController : ControllerBase
    {
        IMatchingService _matchingService;
        

        public MatchingController(IMatchingService matchingService)
        {
            _matchingService = matchingService;
            
        }
    }
}
