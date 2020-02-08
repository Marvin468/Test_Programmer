using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Test_WebAPI.Models
{
    public partial class DB_A54FC5_BDApptestsContext : DbContext
    {
        public DB_A54FC5_BDApptestsContext()
        {
        }

        public DB_A54FC5_BDApptestsContext(DbContextOptions<DB_A54FC5_BDApptestsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Profiles> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.EmployeeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Employees_Positions");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.ProfileId)
                    .HasConstraintName("FK_Employees_Profiles");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.PositionName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Profiles>(entity =>
            {
                entity.HasKey(e => e.ProfileId);

                entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

                entity.Property(e => e.ProfileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
