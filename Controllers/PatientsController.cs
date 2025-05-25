using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Exceptions;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(int id)
        {

            try
            {
                var patientDTO = await _patientService.GetPatient(id);
                return Ok(patientDTO);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                throw;
                return StatusCode(500, "Internal server error");
            }

        }
    }
}
