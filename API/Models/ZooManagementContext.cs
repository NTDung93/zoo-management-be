using System;
using System.Collections.Generic;
using API.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class ZooManagementContext : DbContext
{
    public ZooManagementContext()
    {
    }

    public ZooManagementContext(DbContextOptions<ZooManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<AnimalSpecy> AnimalSpecies { get; set; }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<Cage> Cages { get; set; }

    public virtual DbSet<Certificate> Certificates { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeCertificate> EmployeeCertificates { get; set; }

    public virtual DbSet<FeedingSchedule> FeedingSchedules { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<ImportHistory> ImportHistories { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TransactionHistory> TransactionHistories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-JQJSKQQD;uid=sa;pwd=12345;database=ZooManagement;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Animals__3213E83F101E48F9");

            entity.Property(e => e.Id)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Behavior)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("behavior");
            entity.Property(e => e.BirthDate)
                .HasColumnType("datetime")
                .HasColumnName("birthDate");
            entity.Property(e => e.CageId)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cageID");
            entity.Property(e => e.EmpId)
                .IsRequired()
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("empID");
            entity.Property(e => e.Gender)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("gender");
            entity.Property(e => e.HealthStatus).HasColumnName("healthStatus");
            entity.Property(e => e.Image)
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Rarity)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("rarity");
            entity.Property(e => e.Region)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("region");

            entity.HasOne(d => d.Cage).WithMany(p => p.Animals)
                .HasForeignKey(d => d.CageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAnimals343887");

            entity.HasOne(d => d.Emp).WithMany(p => p.Animals)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAnimals175197");
        });

        modelBuilder.Entity<AnimalSpecy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AnimalSp__3213E83F83FAEDA4");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CageId)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("cageID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Cage).WithMany(p => p.AnimalSpecies)
                .HasForeignKey(d => d.CageId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKAnimalSpec939317");
        });

        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Areas__3213E83F7A465A78");

            entity.Property(e => e.Id)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Cage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cages__3213E83FEB3275DB");

            entity.Property(e => e.Id)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.AreaId)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("areaID");
            entity.Property(e => e.MaxCapacity).HasColumnName("maxCapacity");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.Area).WithMany(p => p.Cages)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKCages158657");
        });

        modelBuilder.Entity<Certificate>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__Certific__357D4CF8C4279090");

            entity.Property(e => e.Code)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Level)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("level");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.TrainingInstitution)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("trainingInstitution");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83FA9BF16DF");

            entity.Property(e => e.Id)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.CitizenId)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("citizenID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.Image)
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("phoneNumber");
            entity.Property(e => e.Role)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        modelBuilder.Entity<EmployeeCertificate>(entity =>
        {
            entity.HasKey(e => e.No).HasName("PK__Employee__3214D4A8A68C8724");

            entity.Property(e => e.CerfCode)
                .IsRequired()
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("cerfCode");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.EmpId)
                .IsRequired()
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("empID");

            entity.HasOne(d => d.CerfCodeNavigation).WithMany(p => p.EmployeeCertificates)
                .HasForeignKey(d => d.CerfCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKEmployeeCe355275");

            entity.HasOne(d => d.Emp).WithMany(p => p.EmployeeCertificates)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKEmployeeCe279067");
        });

        modelBuilder.Entity<FeedingSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleNo).HasName("PK__FeedingS__A532F46FC0D367B7");

            entity.Property(e => e.ScheduleNo).HasColumnName("scheduleNo");
            entity.Property(e => e.AnimalId)
                .IsRequired()
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("animalID");
            entity.Property(e => e.EmployeeId)
                .IsRequired()
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("employeeID");
            entity.Property(e => e.FeedStatus).HasColumnName("feedStatus");
            entity.Property(e => e.FeedTime)
                .HasColumnType("datetime")
                .HasColumnName("feedTime");
            entity.Property(e => e.FoodId).HasColumnName("foodID");

            entity.HasOne(d => d.Animal).WithMany(p => p.FeedingSchedules)
                .HasForeignKey(d => d.AnimalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFeedingSch255596");

            entity.HasOne(d => d.Employee).WithMany(p => p.FeedingSchedules)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFeedingSch604322");

            entity.HasOne(d => d.Food).WithMany(p => p.FeedingSchedules)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKFeedingSch65873");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Foods__3213E83FD46DFC3B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ImportHistory>(entity =>
        {
            entity.HasKey(e => e.No).HasName("PK__ImportHi__3214D4A836475736");

            entity.ToTable("ImportHistory");

            entity.Property(e => e.FoodId).HasColumnName("foodID");
            entity.Property(e => e.ImportDate)
                .HasColumnType("datetime")
                .HasColumnName("importDate");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Food).WithMany(p => p.ImportHistories)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKImportHist755200");
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__News__3213E83FCB6C94AA");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AnimalId)
                .IsRequired()
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("animalID");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.EmpId)
                .IsRequired()
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("empID");
            entity.Property(e => e.Image)
                .HasColumnType("text")
                .HasColumnName("image");
            entity.Property(e => e.SpeciesId).HasColumnName("speciesID");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.WritingDate)
                .HasColumnType("datetime")
                .HasColumnName("writingDate");

            entity.HasOne(d => d.Animal).WithMany(p => p.News)
                .HasForeignKey(d => d.AnimalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKNews933514");

            entity.HasOne(d => d.Emp).WithMany(p => p.News)
                .HasForeignKey(d => d.EmpId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKNews881619");

            entity.HasOne(d => d.Species).WithMany(p => p.News)
                .HasForeignKey(d => d.SpeciesId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKNews885351");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3213E83F5750C22B");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.PhoneNumber).HasColumnName("phoneNumber");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.TicketId }).HasName("PK__OrderDet__1B3A0F1AEBC692A7");

            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.TicketId).HasColumnName("ticketID");
            entity.Property(e => e.EntryDate)
                .HasColumnType("datetime")
                .HasColumnName("entryDate");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKOrderDetai933386");

            entity.HasOne(d => d.Ticket).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.TicketId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKOrderDetai157073");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tickets__3213E83F30666FF5");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Type)
                .HasMaxLength(75)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("unitPrice");
        });

        modelBuilder.Entity<TransactionHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Transact__3213E83F18EE43BB");

            entity.ToTable("TransactionHistory");

            entity.HasIndex(e => e.OrderId, "UQ__Transact__0809337C2CB95720").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("orderID");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("paymentMethod");
            entity.Property(e => e.PaymentStatus).HasColumnName("paymentStatus");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("datetime")
                .HasColumnName("purchaseDate");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("totalPrice");

            entity.HasOne(d => d.Order).WithOne(p => p.TransactionHistory)
                .HasForeignKey<TransactionHistory>(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTransactio989133");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
