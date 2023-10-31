using API.Models.Dtos;
using API.Models.Entities;
using API.Repositories.Impl;

namespace API.Repositories
{
    public interface ICertificateRepository
    {
        Task<IEnumerable<EmployeeCertificate>> GetEmployeeCertificates();
        Task<IEnumerable<Certificate>> GetCertificates();
        Task<IEnumerable<EmployeeCertificate>> GetEmployeeCertificatesByEmpId(string empId);
        Task<IEnumerable<EmployeeCertificate>> GetEmployeeCertificatesByCertiCode(string certiCode);
        Task CreateNewCertificate(Certificate certificate);
        Task CreateNewEmployeeCertificate(EmployeeCertificate employeeCertificate);
        Task<EmployeeCertificate> GetEmployeeCertificateById(int id);
        Task<Certificate> GetCertificateById(string id);
        Task UpdateCertificate(string certificateId, CertificateDto certificateDto);
        Task UpdateEmployeeCertificate(int no, EmployeeCertificateDto employeeCertificateDto);
        Task DeleteCertificate(string id);
        Task DeleteEmployeeCertificate(int id);
        //Task<List<University>> ReadJsonFile(string filePath);
    }


}
