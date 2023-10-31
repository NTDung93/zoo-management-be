namespace API.Models.Entities
{
    public class Certificate
    {
        public string CertificateCode { get; set; }
        public string CertificateName { get; set; }
        public string Level { get; set; }
        public string TrainingInstitution { get; set; }
        public DateTimeOffset CreatedDate { get; set;}
        public ICollection<EmployeeCertificate> EmployeeCertificates { get; set; }
        
    }
}
