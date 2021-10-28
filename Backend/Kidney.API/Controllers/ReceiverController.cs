using Kidney.Core.Entities;
using Kidney.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kidney.API.Controllers
{
    [Route("receiver/")]
    [ApiController]
    public class ReceiverController : ControllerBase
    {
        private IReceiverService _receiverService;
        public ReceiverController(IReceiverService receiverService)
        {
            _receiverService = receiverService;
        }
        [HttpPost]
        [Route("register")]
        public ActionResult Register([FromBody] Receiver receiver)
        {
            if (!_receiverService.Register(receiver))
            {
                return BadRequest(receiver);
            }

            return Ok(receiver);
        }
    }
}
