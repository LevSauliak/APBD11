using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Exceptions;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController(IPrescriptionService _prescriptionService) : ControllerBase
    {

        private readonly IPrescriptionService _prescriptionService;
        
        
        [HttpPost]
        public async Task<IActionResult> AddPrescription([FromBody] PrescriptionDTO prescriptionDto)
        {
            try
            {
                await _prescriptionService.AddPrescription(prescriptionDto);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (BadRequestException e)
            {
                return BadRequest(e.Message);
            }
            catch
            {
                return StatusCode(500, new { error = "Internal server Error" });
            }
            return Ok();
        }
    }
}
