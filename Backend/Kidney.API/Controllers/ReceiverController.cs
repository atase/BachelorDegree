using Kidney.Business.Models;
using Kidney.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<IActionResult> Register([FromBody] Receiver receiver)
        {
            try
            {
                var result = await _receiverService.Register(receiver);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
        [HttpGet]
        [Route("info")]
        public async Task<IActionResult> ReceiverInformations([FromQuery] int id)
        {
            try
            {
                var result = await _receiverService.GetInformations(id);
                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
