using cw8.DAL;
using cw8.Models;
using Microsoft.AspNetCore.Mvc;

namespace cw8.Controllers
{
    [ApiController]
    [Route("api/doctors")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            return Ok(_doctorService.GetDoctors());
        }

        [HttpPut]
        public IActionResult AddDoctor(Doctor doctor)
        {
            _doctorService.AddDoctor(doctor);
            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult UpdateDoctor(int id, [FromBody] Doctor doctor)
        {
            var updatedDoctor = _doctorService.UpdateDoctor(id, doctor);

            if (updatedDoctor == null)
            {
                return NotFound("Doctor with given id doesn't exist!");
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var removedDoctor = _doctorService.DeleteDoctor(id);

            if (removedDoctor == null)
            {
                return NotFound("Doctor with given id doesn't exist!");
            }

            return Ok();
        }
    }
}