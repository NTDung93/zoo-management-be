using API.Models.Entities;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalSpecies> AnimalSpecies { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Cage> Cages { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<EmployeeCertificate> EmployeeCertificates { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<FeedingSchedule> FeedingSchedules { get; set; }    
        public DbSet<FeedingHistory> FeedingHistories { get; set; } 
        public DbSet<FoodInventory> FoodInventories { get; set; }
        public DbSet<ImportHistory> ImportHistories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
            return configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>()
                .Property(n => n.Content).HasColumnType("text");
            modelBuilder.Entity<News>()
                .Property(n => n.Image).HasColumnType("text");

            modelBuilder.Entity<Employee>()
                .Property(e => e.Image).HasColumnType("text");  
            modelBuilder.Entity<Animal>()
                .Property(a => a.Image).HasColumnType("text");  


            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<Order>().Property(o => o.OrderId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Ticket>().HasKey(t => t.TicketId);  
            
            modelBuilder.Entity<Ticket>()
                .Property(t => t.UnitPrice).HasConversion<double>();
            modelBuilder.Entity<TransactionHistory>()
                .Property(th => th.TotalPrice).HasConversion<double>();
            
            modelBuilder.Entity<OrderDetail>().HasKey(od => new {od.OrderId, od.TicketId});
            
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderId);
            
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Ticket)
                .WithMany(t => t.OrderDetails)
                .HasForeignKey(od => od.TicketId);

            modelBuilder.Entity<TransactionHistory>().HasKey(th => th.TransactionId);
            modelBuilder.Entity<TransactionHistory>().Property(th => th.TransactionId)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<TransactionHistory>()
                .HasOne(th => th.Order)
                .WithOne(o => o.TransactionHistory)
                .HasForeignKey<TransactionHistory>(th => th.OrderId);
            ////////////////////////////////////////////////////////////////////////
            modelBuilder.Entity<Certificate>().HasKey(c => c.CertificateCode);

            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);

            modelBuilder.Entity<EmployeeCertificate>()
                .HasKey(ec => ec.No);
            modelBuilder.Entity<EmployeeCertificate>()
                .Property(ec => ec.No).ValueGeneratedOnAdd();
            modelBuilder.Entity<EmployeeCertificate>()
                .HasOne(ec => ec.Employee)
                .WithMany(e => e.EmployeeCertificates)
                .HasForeignKey(ec => ec.EmployeeId);    
            modelBuilder.Entity<EmployeeCertificate>()
                .HasOne(ec => ec.Certificate)
                .WithMany(c => c.EmployeeCertificates)
                .HasForeignKey(ec => ec.CertificateCode);   

            modelBuilder.Entity<News>().HasKey(n => n.NewsId);
            modelBuilder.Entity<News>().Property(n => n.NewsId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<ImportHistory>().HasKey(ih => ih.No);
            modelBuilder.Entity<ImportHistory>().Property(ih => ih.No)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<FeedingSchedule>()
                .HasKey(fs => fs.ScheduleNo);
            
            modelBuilder.Entity<FoodInventory>()
                .HasKey(f => f.FoodId);

            modelBuilder.Entity<FeedingHistory>()
                .Property(fh => fh.HistoryNo).ValueGeneratedOnAdd();
            modelBuilder.Entity<FeedingHistory>()
                .HasKey(fh => fh.HistoryNo);

            modelBuilder.Entity<AnimalSpecies>().HasKey(aspecies => aspecies.SpeciesId);
            modelBuilder.Entity<AnimalSpecies>().Property(aspecies => aspecies.SpeciesId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Animal>()
                .HasKey(a => a.AnimalId);

            modelBuilder.Entity<Animal>()
                .Property(a => a.ScheduleNo).IsRequired(false);

            modelBuilder.Entity<Area>()
                .HasKey(area => area.AreaId);
            
            modelBuilder.Entity<Cage>()
                .HasKey(cage => cage.CageId);

            modelBuilder.Entity<Cage>()
                .HasOne(c => c.Area)
                .WithMany(a => a.Cages)
                .HasForeignKey(c => c.AreaId);
            
            modelBuilder.Entity<News>()
                .HasOne(n => n.Employee)
                .WithMany(emp => emp.News)
                .HasForeignKey(n => n.EmployeeId);

            modelBuilder.Entity<News>()
                .HasOne(n => n.AnimalSpecies)
                .WithMany(aspecies => aspecies.News)
                .HasForeignKey(n => n.SpeciesId);
            
            modelBuilder.Entity<News>()
                .HasOne(n => n.Animal)
                .WithMany(a => a.News)
                .HasForeignKey(n => n.AnimalId);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Employee)
                .WithMany(emp => emp.Animals)
                .HasForeignKey(a => a.EmployeeId);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.FeedingSchedule)
                .WithMany(fs => fs.Animals)
                .HasForeignKey(a => a.ScheduleNo);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Cage)
                .WithMany(c => c.Animals)
                .HasForeignKey(a => a.CageId);
            
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.AnimalSpecies)
                .WithMany(aspecies => aspecies.Animals)
                .HasForeignKey(a => a.SpeciesId);
            
            modelBuilder.Entity<ImportHistory>()
                .HasOne(ih => ih.FoodInventory)
                .WithMany(f => f.ImportHistories)
                .HasForeignKey(ih => ih.FoodId);

            modelBuilder.Entity<Cage>()
                .HasOne(c => c.FeedingSchedule)
                .WithMany(fs => fs.Cages)
                .HasForeignKey(c => c.ScheduleNo);

            modelBuilder.Entity<FeedingSchedule>()
                .HasOne(fs => fs.FoodInventory)
                .WithMany(f => f.FeedingSchedules)
                .HasForeignKey(fs => fs.FoodId);

            modelBuilder.Entity<FeedingHistory>()
                .HasOne(fh => fh.FeedingSchedule)
                .WithMany(fs => fs.FeedingHistories)
                .HasForeignKey(fh => fh.ScheduleNo);
        }
    }
}
