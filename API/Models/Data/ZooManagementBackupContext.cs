using Microsoft.EntityFrameworkCore;

namespace API.Models.Data
{
    public class ZooManagementBackupContext : DbContext
    {
        public ZooManagementBackupContext()
        {
            
        }

        public ZooManagementBackupContext(DbContextOptions<ZooManagementBackupContext> options) : base(options)
        {
        }
    }
}
