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
        public DbSet<Food> Foods { get; set; }
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
            modelBuilder.Entity<Ticket>().Property(t => t.TicketId)
                .ValueGeneratedOnAdd();

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

            modelBuilder.Entity<FeedingSchedule>().HasKey(fs => fs.ScheduleNo);
            modelBuilder.Entity<FeedingSchedule>().Property(fs => fs.ScheduleNo)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Food>().HasKey(f => f.FoodId);
            modelBuilder.Entity<Food>().Property(f => f.FoodId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<AnimalSpecies>().HasKey(aspecies => aspecies.SpeciesId);
            modelBuilder.Entity<AnimalSpecies>().Property(aspecies => aspecies.SpeciesId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Animal>().HasKey(a => a.AnimalId);

            modelBuilder.Entity<Area>().HasKey(area => area.AreaId);
            modelBuilder.Entity<Cage>().HasKey(cage => cage.CageId);

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

            modelBuilder.Entity<ImportHistory>()
                .HasOne(ih => ih.Food)
                .WithMany(f => f.ImportHistories)
                .HasForeignKey(ih => ih.FoodId);

            modelBuilder.Entity<FeedingSchedule>()
                .HasOne(fs => fs.Food)
                .WithMany(f => f.FeedingSchedules)
                .HasForeignKey(fs => fs.FoodId);

            modelBuilder.Entity<FeedingSchedule>()
                .HasOne(fs => fs.Employee)
                .WithMany(e => e.FeedingSchedules)
                .HasForeignKey(fs => fs.EmployeeId);

            modelBuilder.Entity<FeedingSchedule>()
                .HasOne(fs => fs.Animal)
                .WithMany(a => a.FeedingSchedules)
                .HasForeignKey(fs => fs.AnimalId);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Cage)
                .WithMany(c => c.Animals)
                .HasForeignKey(a => a.CageId);

            modelBuilder.Entity<AnimalSpecies>()
                .HasOne(aspecies => aspecies.Cage)
                .WithMany(c => c.AnimalSpecies)
                .HasForeignKey(aspecies => aspecies.CageId);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.AnimalSpecies)
                .WithMany(aspecies => aspecies.Animals)
                .HasForeignKey(a => a.SpeciesId);
        }

    }
}
