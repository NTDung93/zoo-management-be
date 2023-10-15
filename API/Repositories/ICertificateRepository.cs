using API.Models.Entities;

namespace API.Repositories
{
    public interface ICertificateRepository
    {
        Task<IEnumerable<Certificate>> GetCertificates();
        Task<Certificate> GetCertificate(string id);
        Task<bool> UpdateCertificate();
        Task<bool> CreateCertificate();
        Task<bool> DeleteCertificate(string id);
        Task<bool> Save();
    }
}
