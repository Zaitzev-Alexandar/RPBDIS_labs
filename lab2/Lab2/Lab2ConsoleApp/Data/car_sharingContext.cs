using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Lab2ConsoleApp
{
    public partial class car_sharingContext : DbContext
    {
        public car_sharingContext()
        {
        }

        public car_sharingContext(DbContextOptions<car_sharingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdditionalServices> AdditionalServices { get; set; }
        public virtual DbSet<CarModels> CarModels { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Rents> Rents { get; set; }
        public virtual DbSet<Services> Services { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("SQLConnection");
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdditionalServices>(entity =>
            {
                entity.HasOne(d => d.Rent)
                    .WithMany(p => p.AdditionalServices)
                    .HasForeignKey(d => d.RentId)
                    .HasConstraintName("FK__Additiona__RentI__34C8D9D1");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.AdditionalServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__Additiona__Servi__35BCFE0A");
            });

            modelBuilder.Entity<CarModels>(entity =>
            {
                entity.HasKey(e => e.CarModelId);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.HasKey(e => e.CarId);

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.RentalPrice).HasColumnType("money");

                entity.Property(e => e.Specs)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TechnicalMaintenanceDate).HasColumnType("datetime");

                entity.Property(e => e.Vincode)
                    .HasColumnName("VINCode")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.CarModel)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CarModelId)
                    .HasConstraintName("FK__Cars__CarModelId__286302EC");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Cars__EmployeeId__29572725");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.Address)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PassportInfo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNum)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmploymentDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Post)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Rents>(entity =>
            {
                entity.HasKey(e => e.RentId);

                entity.Property(e => e.DeliveryDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Rents__CarId__2E1BDC42");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Rents__CustomerI__2F10007B");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Rents__EmployeeI__300424B4");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");
            });
        }
    }
}
