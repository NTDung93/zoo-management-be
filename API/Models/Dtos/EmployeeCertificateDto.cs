using API.Models.Entities;

namespace API.Models.Dtos
{
    public class EmployeeCertificateDto
    {
        public int No { get; set; }
        public string EmployeeId { get; set; }
        public string CertificateCode { get; set; }
        public string Description { get; set; }
        public EmployeeDto Employee { get; set; }
        public CertificateDto Certificate { get; set; }
    }
}
