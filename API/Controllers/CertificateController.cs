using API.Models.Dtos;
using API.Models.Entities;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class CertificateController : BaseApiController
    {
        private readonly ICertificateRepository _certiRepo;
        private readonly IMapper _mapper;

        public CertificateController(ICertificateRepository certiRepo, IMapper mapper)
        {
            _certiRepo = certiRepo;
            _mapper = mapper;
        }

        [HttpGet("load-certificates", Name = "GetCertificates")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Trainer")]
        public async Task<ActionResult<IEnumerable<CertificateDto>>> GetCertificates()
        {
            var certificates = await _certiRepo.GetCertificates();
            if (!ModelState.IsValid)
                return BadRequest();
            var certificatesDto = _mapper.Map<IEnumerable<CertificateDto>>(certificates);
            return Ok(certificatesDto);
        }

        //[HttpGet("load-university")]
        //[ProducesResponseType(200)]
        ////[Authorize(Roles = "Trainer")]
        //public async Task<ActionResult<IEnumerable<University>>> GetUniversity()
        //{
        //    var certificates = await _certiRepo.ReadJsonFile("world_universities_and_domains.json");
        //    if (!ModelState.IsValid)
        //        return BadRequest();
        //    return Ok(certificates);
        //}

        [HttpGet("load-certificateById")]
        public async Task<ActionResult<CertificateDto>> GetCertificate(string id)
        {
            var certificate = await _certiRepo.GetCertificateById(id);

            if (certificate == null)
            {
                return NotFound();
            }
            var certificateDto = _mapper.Map<CertificateDto>(certificate);
            return certificateDto;
        }

        [HttpGet("load-empCertificateById")]
        public async Task<ActionResult<EmployeeCertificateDto>> GetEmpCertificate(int id)
        {
            var empCertificate = await _certiRepo.GetEmployeeCertificateById(id);

            if (empCertificate == null)
            {
                return NotFound();
            }
            var empCertificateDto = _mapper.Map<EmployeeCertificateDto>(empCertificate);
            return empCertificateDto;
        }

        [HttpGet("load-empCertificates", Name = "GetEmpCertificates")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Trainer")]
        public async Task<ActionResult<IEnumerable<EmployeeCertificateDto>>> GetEmpCertificates()
        {
            var empCertificates = await _certiRepo.GetEmployeeCertificates();
            if (!ModelState.IsValid)
                return BadRequest();
            var empCertificatesDto = _mapper.Map<IEnumerable<EmployeeCertificateDto>>(empCertificates);
            return Ok(empCertificatesDto);
        }

        [HttpGet("load-certificatesbyemp", Name = "GetCertificatesOfEmp")]
        [ProducesResponseType(200)]
        //[Authorize(Roles = "Trainer")]
        public async Task<ActionResult<IEnumerable<EmployeeCertificateDto>>> GetCertificatesOfEmp([FromQuery] string empId)
        {
            var empCertificates = await _certiRepo.GetEmployeeCertificatesByEmpId(empId);
            if (!ModelState.IsValid)
                return BadRequest();
            var empCertificatesDto = _mapper.Map<IEnumerable<EmployeeCertificateDto>>(empCertificates);
            return Ok(empCertificatesDto);
        }

        [HttpDelete("delete-certificate")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<CertificateDto>> DeleteCertificate([FromQuery] string certificateCode)
        {
            var empCertificate = _certiRepo.GetEmployeeCertificatesByCertiCode(certificateCode);
            if(empCertificate.Result.Any())
            {
                return BadRequest(new ProblemDetails { Title = "Certificate has Employee do not allow Delete!" });
            }
            else
            {
                await _certiRepo.DeleteCertificate(certificateCode);
                var certificates = await _certiRepo.GetCertificates();
                var certificatesDto = _mapper.Map<IEnumerable<CertificateDto>>(certificates);
                if (!ModelState.IsValid)
                    BadRequest(ModelState);
                return CreatedAtRoute("GetCertificates", certificatesDto);
            }         
        }

        [HttpDelete("delete-empCertificate")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<EmployeeCertificateDto>> DeleteEmployeeCerti([FromQuery] int no)
        {
            await _certiRepo.DeleteEmployeeCertificate(no);
            var empCertificates = await _certiRepo.GetEmployeeCertificates();
            var empCertificatesDto = _mapper.Map<IEnumerable<EmployeeCertificateDto>>(empCertificates);
            if (!ModelState.IsValid)
                BadRequest(ModelState);
            return CreatedAtRoute("GetEmpCertificates", empCertificatesDto);
        }

        [HttpPost("create-certificate")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<CertificateDto>> CreateNewCertificate([FromBody] CertificateDto certificateDto)
        {
            var certificates = await _certiRepo.GetCertificates();
            if (certificates.SingleOrDefault(certificate => certificate.CertificateCode.Equals(certificateDto.CertificateCode)) != null)
            {
                return BadRequest(new ProblemDetails { Title = "CertificateCode is exist" });
            }
            else
            {
                var certificate = _mapper.Map<Certificate>(certificateDto);
                certificate.CreatedDate = DateTimeOffset.Now;
                await _certiRepo.CreateNewCertificate(certificate);
                
            }
            //var certificates = await _certiRepo.GetCertificates();
            //var certificatesDto = _mapper.Map<IEnumerable<CertificateDto>>(certificates);
            //return CreatedAtRoute("GetCertificates", certificatesDto);
            return NoContent();
        }

        [HttpPost("create-empCertificate")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<EmployeeCertificateDto>> CreateNewEmpCertificate([FromBody] EmployeeCertificateDto employeeCertificateDto)
        {
            var empCertificate = _mapper.Map<EmployeeCertificate>(employeeCertificateDto);
            await _certiRepo.CreateNewEmployeeCertificate(empCertificate);
            var empCertificates = await _certiRepo.GetEmployeeCertificates();
            var empCertificateDto = _mapper.Map<IEnumerable<EmployeeCertificateDto>>(empCertificates);
            return CreatedAtRoute("GetEmpCertificates", empCertificateDto);
        }

        [HttpPut("update-certificate")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateCertificate([FromQuery] string certificateCode, [FromBody] CertificateDto certificateDto)
        {
            var currCerti = await _certiRepo.GetCertificateById(certificateCode);
            if (currCerti != null)
            {
                await _certiRepo.UpdateCertificate(certificateCode, certificateDto);
                return Ok("Update Certificate Success!");
            }
            return NotFound();
        }

        [HttpPut("update-empCertificate")]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateEmployeeCertificate([FromQuery] int no, [FromBody] EmployeeCertificateDto employeeCertificateDto)
        {
            var currEmpCerti = await _certiRepo.GetEmployeeCertificateById(no);
            if (currEmpCerti != null)
            {
                await _certiRepo.UpdateEmployeeCertificate(no, employeeCertificateDto);
                return Ok("Update EmpCertificate Success!");
            }
            return NotFound();
        }
    }
}
