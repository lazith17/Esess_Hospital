using AutoMapper;
using Esess.PatientAPI.Data;
using Esess.PatientAPI.Models;
using Esess.PatientAPI.Models.DTO;
using Esess.PatientAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Esess.PatientAPI.Controllers
{
    [Route("api/patient")]
    [ApiController]
    public class PatientAPIController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly PatientDbContext _patientcontext;
        private ResponseDTO _responseDTO;
        private readonly IMapper _mapper;
        //IPatientService patientService, 
        public PatientAPIController(IPatientService patientService, PatientDbContext patientDb, IMapper mapper)
        {
            _patientService = patientService;
            _patientcontext = patientDb;
            _mapper = mapper;
        }

        //[HttpGet]
        //public ResponseDTO GetAllPatients()
        //{
        //    try
        //    {
        //        IEnumerable<Patient> objList = _patientcontext.Patients.ToList();
        //        _responseDTO.Result = _mapper.Map<IEnumerable<PatientDTO>>(objList);
        //    }
        //    catch (Exception ex)
        //    {
        //        _responseDTO.IsSuccess = false;
        //        _responseDTO.Result = ex.Message;
        //    }
        //    return _responseDTO;
        //}

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var patients = await _patientService.GetAllPatientsAsync();
            return Ok(patients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null) return NotFound();
            return Ok(patient);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPatient([FromBody] PatientDTO patientDTO)
        {
            //Convert PatientDTO to Patient obj
            Patient patientobj = _mapper.Map<Patient>(patientDTO);
            var newPatient = await _patientService.RegisterPatientAsync(patientobj);
            return CreatedAtAction(nameof(GetPatientById), new { id = newPatient.Id }, newPatient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] Patient patient)
        {
            if (id != patient.Id) return BadRequest();
            var result = await _patientService.UpdatePatientAsync(patient);
            if (!result) return NotFound();
            return NoContent();
        }

        //[Authorize(Roles = "ADMIN")]
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var result = await _patientService.DeletePatientAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
