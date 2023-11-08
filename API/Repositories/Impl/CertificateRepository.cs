using API.Models.Data;
using API.Models.Dtos;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System.Text.Json;

namespace API.Repositories.Impl
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly ZooManagementBackupContext _dbContext;

        public CertificateRepository(ZooManagementBackupContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EmployeeCertificate>> GetEmployeeCertificates()
        {
            return await _dbContext.EmployeeCertificates.Include(x => x.Employee).Include(y => y.Certificate).ToListAsync();
        }

        public async Task<IEnumerable<Certificate>> GetCertificates()
        {
            return await _dbContext.Certificates.OrderByDescending(x => x.CreatedDate).ToListAsync();
        }

        public async Task<IEnumerable<EmployeeCertificate>> GetEmployeeCertificatesByEmpId(string empId)
        {
            return await _dbContext.EmployeeCertificates.Include(x => x.Employee).Include(y => y.Certificate).Where(emp => emp.EmployeeId.Equals(empId)).ToListAsync();
        }

        public async Task<IEnumerable<EmployeeCertificate>> GetEmployeeCertificatesByCertiCode(string certiCode)
        {
            return await _dbContext.EmployeeCertificates.Include(x => x.Employee).Include(y => y.Certificate).Where(certi => certi.CertificateCode.Equals(certiCode)).ToListAsync();
        }

        public async Task CreateNewCertificate(Certificate certificate)
        {
            certificate.CreatedDate = DateTimeOffset.Now;
            await _dbContext.Certificates.AddAsync(certificate);
            await _dbContext.SaveChangesAsync();
        }
        public async Task CreateNewEmployeeCertificate(EmployeeCertificate employeeCertificate)
        {
            await _dbContext.EmployeeCertificates.AddAsync(employeeCertificate);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<EmployeeCertificate> GetEmployeeCertificateById(int id)
        {
            return await _dbContext.EmployeeCertificates.Include(x => x.Employee).Include(y => y.Certificate).SingleOrDefaultAsync(certificate => certificate.No == id);
        }
        public async Task<Certificate> GetCertificateById(string id)
        {
            return await _dbContext.Certificates.SingleAsync(certificate => certificate.CertificateCode.Equals(id));
        }

        public async Task UpdateCertificate(string certificateId, CertificateDto certificateDto)
        {
            var currentCertificate = GetCertificateById(certificateId);
            currentCertificate.Result.CertificateName = certificateDto.CertificateName;
            currentCertificate.Result.TrainingInstitution = certificateDto.TrainingInstitution;
            currentCertificate.Result.Level = certificateDto.Level;
            currentCertificate.Result.CreatedDate = DateTimeOffset.Now;
            await _dbContext.SaveChangesAsync();
        }
        public async Task UpdateEmployeeCertificate(int no, EmployeeCertificateDto employeeCertificateDto)
        {
            var currentEmployeeCertificate = GetEmployeeCertificateById(no);
            currentEmployeeCertificate.Result.CertificateCode = employeeCertificateDto.CertificateCode;
            currentEmployeeCertificate.Result.Description = employeeCertificateDto.Description;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCertificate(string id)
        {
            var currentCertificate = GetCertificateById(id);
            _dbContext.Certificates.Remove(currentCertificate.Result);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteEmployeeCertificate(int id)
        {
            var currentEmployeeCertificate = GetEmployeeCertificateById(id);
            _dbContext.EmployeeCertificates.Remove(currentEmployeeCertificate.Result);
            await _dbContext.SaveChangesAsync();
        }

        //public  Task<IEnumerable<University>> ReadJsonFile(string filePath)
        //{
        //    try
        //    {
        //        // Read the JSON file as a string
        //        string jsonContent = System.IO.File.ReadAllText(filePath);

        //        // Deserialize the JSON string into a list of Person objects
        //        var people = JsonSerializer.Deserialize<IEnumerable<University>>(jsonContent);
        //        return await people;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"An error occurred: {ex.Message}");
        //    }
        //    return new List<University>(); // Return an empty list in case of file not found
        //}
    }
}
