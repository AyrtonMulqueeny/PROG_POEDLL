using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PROG_POEDLL.Models
{
    public partial class StudentContext : DbContext
    {
        public StudentContext()
        {
        }

        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<SUser> SUsers { get; set; }
        public virtual DbSet<Semester> Semesters { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server='ML-RefVm-631348\\SQLEXPRESS';Database='Student';Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>(entity =>
            {
                entity.ToTable("Module");

                entity.Property(e => e.ModuleId)
                    .ValueGeneratedNever()
                    .HasColumnName("ModuleID");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HoursPerWeek).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.SelfStudyHours).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SemesterId).HasColumnName("SemesterID");

                entity.HasOne(d => d.Semester)
                    .WithMany(p => p.Modules)
                    .HasForeignKey(d => d.SemesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Module__Semester__3B75D760");
            });

            modelBuilder.Entity<SUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__sUser__1788CCAC67DA5651");

                entity.ToTable("sUser");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Semester>(entity =>
            {
                entity.ToTable("Semester");

                entity.Property(e => e.SemesterId)
                    .ValueGeneratedNever()
                    .HasColumnName("SemesterID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Semesters)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Semester__UserID__38996AB5");
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("session");

                entity.Property(e => e.SessionId)
                    .ValueGeneratedNever()
                    .HasColumnName("SessionID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Hours)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("hours");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__session__ModuleI__3E52440B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
