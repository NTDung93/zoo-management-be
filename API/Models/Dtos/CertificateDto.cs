namespace API.Models.Dtos
{
    public class CertificateDto
    {
        public string CertificateCode { get; set; }
        public string CertificateName { get; set; }
        public string Level { get; set; }
        public string TrainingInstitution { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

    }
}
