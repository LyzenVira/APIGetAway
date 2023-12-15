using Aggregation.Models;
using Aggregation.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Aggregation.Controllers
{
    [Route("getaway/aggregation")]
    [ApiController]
    public class AggregationController : ControllerBase
    {
        private readonly IDoctorService doctorService;
        private readonly IDocumentService documentService;
        private readonly IPatientService patientService;
        private readonly IJwtService jwtService;

        public AggregationController(IDoctorService doctorService, IDocumentService documentService, IPatientService patientService, IJwtService jwtService)
        {
            this.doctorService = doctorService;
            this.documentService = documentService;
            this.patientService = patientService;
            this.jwtService = jwtService;
        }

        public async Task<ActionResult<ResponseEntity<IEnumerable<Patient>>>> GetShoppingGetPatientsByDoctorRole(string role)
        {
            var doctors = await doctorService.GetDoctorsByRole(role);
            var doctorsId = doctors.Result.Select(doctor => doctor.Id);
            var result = await patientService.GetPatientsByDoctors(doctorsId);

            return Ok(result);
        }
    }

}

