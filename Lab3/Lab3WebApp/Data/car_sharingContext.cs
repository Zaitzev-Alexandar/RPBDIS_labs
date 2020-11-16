using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Lab3WebApp.Models;

namespace Lab3WebApp.Data
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

        public virtual DbSet<CarModel> CarModels { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=car_sharing;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<CarModel>(entity =>
            {
                entity.HasKey(e => e.CarModelId)
                    .HasName("PK__CarModel__C585C08FF46F5230");

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("PK__Cars__68A0342E060286E5");

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

            

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PK__Employee__7AD04F119618475A");

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

           
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
