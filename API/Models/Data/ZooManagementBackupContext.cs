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
        public DbSet<FeedingMenu> FeedingMenus { get; set; }    
        public DbSet<FeedingSchedule> FeedingSchedules { get; set; } 
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

            modelBuilder.Entity<Ticket>()
                .Property(t => t.Image).HasColumnType("text");

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

            modelBuilder.Entity<FoodInventory>()
                .Property(fi => fi.InventoryQuantity)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<ImportHistory>()
                .Property(ih => ih.ImportQuantity)
                .HasColumnType("decimal(5,2)");
        
            modelBuilder.Entity<FeedingSchedule>()
                .Property(fs => fs.FeedingAmount)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<OrderDetail>()
                .Property(od => od.UnitTotalPrice)
                .HasColumnType("decimal(10,3)");

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

            modelBuilder.Entity<News>()
                .HasKey(n => n.NewsId);

            modelBuilder.Entity<News>()
                .Property(n => n.NewsId)
                .ValueGeneratedOnAdd();
            
            modelBuilder.Entity<ImportHistory>()
                .HasKey(ih => ih.No);

            modelBuilder.Entity<ImportHistory>()
                .Property(ih => ih.No)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<FeedingMenu>()
                .HasKey(fs => fs.MenuNo);
            
            modelBuilder.Entity<FoodInventory>()
                .HasKey(f => f.FoodId);

            modelBuilder.Entity<FeedingSchedule>()
                .Property(fs => fs.No).ValueGeneratedOnAdd();
            modelBuilder.Entity<FeedingSchedule>()
                .HasKey(fs => fs.No);

            modelBuilder.Entity<AnimalSpecies>()
                .HasKey(aspecies => aspecies.SpeciesId);

            modelBuilder.Entity<AnimalSpecies>()
                .Property(aspecies => aspecies.SpeciesId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Animal>()
                .HasKey(a => a.AnimalId);
            
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
                .HasOne(n => n.Animal)
                .WithMany(a => a.News)
                .HasForeignKey(n => n.AnimalId);

            modelBuilder.Entity<News>()
                .HasOne(n => n.AnimalSpecies)
                .WithMany(a => a.News)
                .HasForeignKey(n => n.SpeciesId);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Employee)
                .WithMany(emp => emp.Animals)
                .HasForeignKey(a => a.EmployeeId);
            
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

            modelBuilder.Entity<FeedingSchedule>()
                .Property(fs => fs.CageId)
                .IsRequired(false);

            modelBuilder.Entity<FeedingSchedule>()
                .Property(fs => fs.AnimalId)
                .IsRequired(false);

            modelBuilder.Entity<FeedingMenu>()
                .HasOne(fs => fs.FoodInventory)
                .WithMany(f => f.FeedingSchedules)
                .HasForeignKey(fs => fs.FoodId);

            modelBuilder.Entity<FeedingSchedule>()
                .HasOne(fs => fs.FeedingMenu)
                .WithMany(fm => fm.FeedingSchedules)
                .HasForeignKey(fs => fs.MenuNo);

            modelBuilder.Entity<FeedingSchedule>()
                .HasOne(fs => fs.Animal)
                .WithMany(fm => fm.FeedingSchedules)
                .HasForeignKey(fs => fs.AnimalId);

            modelBuilder.Entity<FeedingSchedule>()
                .HasOne(fs => fs.Cage)
                .WithMany(fm => fm.FeedingSchedules)
                .HasForeignKey(fs => fs.CageId);

            modelBuilder.Entity<FeedingSchedule>()
                .HasOne(fs => fs.Employee)
                .WithMany(fm => fm.FeedingSchedules)
                .HasForeignKey(fs => fs.EmployeeId);

            modelBuilder.Entity<EmployeeCertificate>()
                .Property(ec => ec.CertificateImage)
                .HasColumnType("text");

            modelBuilder.Entity<Area>()
                .HasOne(a => a.Employee)
                .WithOne(e => e.Area)
                .HasForeignKey<Area>(a => a.EmployeeId);

            modelBuilder.Entity<Animal>()
                .Property(a => a.MaxFeedingQuantity)
                .HasColumnType("decimal(5,2)");

            modelBuilder.Entity<FeedingSchedule>()
                .Property(fs => fs.Note)
                .HasColumnType("nvarchar(250)");

            modelBuilder.Entity<FeedingMenu>()
                .HasOne(fm => fm.AnimalSpecies)
                .WithMany(species => species.FeedingMenus)
                .HasForeignKey(fm => fm.SpeciesId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
