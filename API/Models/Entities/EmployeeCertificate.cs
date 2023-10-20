namespace API.Models.Entities
{
    public class EmployeeCertificate
    {
        public int No { get; set; }
        public string EmployeeId { get; set; }
        public string CertificateCode { get; set; }
        public string Description { get; set; } 
        public string CertificateImage { get; set; }
        public Employee Employee { get; set; }
        public Certificate Certificate { get; set; }
    }
}
