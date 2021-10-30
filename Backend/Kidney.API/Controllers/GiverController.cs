using Kidney.Core.DTOs;
using Kidney.Core.Entities;
using Kidney.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidney.API.Controllers
{
    [Route("giver/")]
    [ApiController]
    public class GiverController : ControllerBase
    {
        private IGiverService _giverService;
        public GiverController(IGiverService giverService)
        {
            _giverService = giverService;
        }

        [HttpPost]
        [Route("register")]
        public ActionResult Register([FromBody] Giver giver)
        {
            if (!_giverService.Register(giver))
            {
                return BadRequest(giver);
            }

            return Ok(giver);
        }

        [HttpPost]
        [Route("info")]
        public ActionResult GiverInformation([FromBody] GiverDTO giverDTO)
        {
            return Ok(_giverService.GetInformations(giverDTO.Id));
        }

    }
}
