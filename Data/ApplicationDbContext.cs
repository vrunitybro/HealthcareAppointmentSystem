using HealthcareAppointmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthcareAppointmentSystem.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Department> Departments => Set<Department>();

    public DbSet<Provider> Providers => Set<Provider>();

    public DbSet<Patient> Patients => Set<Patient>();

    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("departments");

            entity.HasKey(d => d.DepartmentId);

            entity.Property(d => d.Name)
                .HasMaxLength(100)
                .IsRequired();
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.ToTable("providers");

            entity.HasKey(p => p.ProviderId);

            entity.Property(p => p.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(p => p.LastName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(p => p.Specialty)
                .HasMaxLength(100)
                .IsRequired();

            entity.HasOne(p => p.Department)
                .WithMany()
                .HasForeignKey(p => p.DepartmentId);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("patients");

            entity.HasKey(p => p.PatientId);

            entity.Property(p => p.FirstName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(p => p.LastName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(p => p.DateOfBirth)
                .IsRequired();

            entity.Property(p => p.Email)
                .HasMaxLength(150);

            entity.Property(p => p.Phone)
                .HasMaxLength(30);
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("appointments");

            entity.HasKey(a => a.AppointmentId);

            entity.Property(a => a.AppointmentDate)
                .IsRequired();

            entity.Property(a => a.Status)
                .HasMaxLength(30)
                .IsRequired()
                .HasDefaultValue("Scheduled");

            entity.Property(a => a.Reason)
                .HasMaxLength(255)
                .IsRequired();

            entity.Property(a => a.CreatedAt)
                .IsRequired();

            entity.HasOne(a => a.Patient)
                .WithMany()
                .HasForeignKey(a => a.PatientId);

            entity.HasOne(a => a.Provider)
                .WithMany()
                .HasForeignKey(a => a.ProviderId);
        });
    }
}