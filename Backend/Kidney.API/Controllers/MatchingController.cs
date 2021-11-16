using Kidney.Core.DTOs;
using Kidney.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidney.API.Controllers
{
    [Route("matching/")]
    [ApiController]
    public class MatchingController : ControllerBase
    {
        IMatchingService matchingService;
        

        public MatchingController(IMatchingService _matchingService)
        {
            matchingService = _matchingService;
            
        }

        [HttpPost]
        [Route("result")]
        public ActionResult MatchingResult([FromBody] AlgorithmDTO algorithmDTO)
        {
            return Ok(matchingService.Matching());
        }

    }
}
