using API.Models.Data;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Impl
{
    public class CertificateRepository : ICertificateRepository
    {
        private readonly ZooManagementBackupContext _dbContext;

        public CertificateRepository(ZooManagementBackupContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> CreateCertificate()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteCertificate(string id)
        {
            var certificate = await GetCertificate(id);
            if (certificate == null) return false;
            // more validation: if a certificate has haved many trainers, it can't be deleted
            _dbContext.Certificates.Remove(certificate);
            return await Save();
        }

        public Task<Certificate> GetCertificate(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Certificate>> GetCertificates()
        {
            return await _dbContext.Certificates
                .OrderBy(cer => cer.CertificateCode)
                .ToListAsync();
        }

        public async Task<bool> Save()
        {
            var saved = _dbContext.SaveChangesAsync();
            return await saved > 0;
        }

        public Task<bool> UpdateCertificate()
        {
            throw new NotImplementedException();
        }
    }
}
