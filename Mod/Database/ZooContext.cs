using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Mod.Database.Models;

namespace Mod.Database;

public partial class ZooContext : DbContext
{
    public ZooContext()
    {
    }

    public ZooContext(DbContextOptions<ZooContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Animal> Animals { get; set; }

    public virtual DbSet<Enclosure> Enclosures { get; set; }

    public virtual DbSet<Feeding> Feedings { get; set; }

    public virtual DbSet<ParticipationInTour> ParticipationInTours { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketType> TicketTypes { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<UserAccount> UserAccounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=root");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresEnum("moo", new[] { "НаРассмотрении", "Одобрено", "Отказано" })
            .HasPostgresEnum("pl2", "request_status", new[] { "НаРассмотрении", "Принято", "Отказ" })
            .HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Animal>(entity =>
        {
            entity.HasKey(e => e.AnimalId).HasName("animal_pkey");

            entity.ToTable("animal", "mod");

            entity.Property(e => e.AnimalId)
                .ValueGeneratedNever()
                .HasColumnName("animal_id");
            entity.Property(e => e.Breed)
                .HasMaxLength(100)
                .HasColumnName("breed");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .HasColumnName("gender");
            entity.Property(e => e.HealthStatus).HasColumnName("health_status");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Species)
                .HasMaxLength(100)
                .HasColumnName("species");
        });

        modelBuilder.Entity<Enclosure>(entity =>
        {
            entity.HasKey(e => e.EnclosureId).HasName("enclosure_pkey");

            entity.ToTable("enclosure", "mod");

            entity.Property(e => e.EnclosureId)
                .ValueGeneratedNever()
                .HasColumnName("enclosure_id");
            entity.Property(e => e.Area)
                .HasPrecision(10, 2)
                .HasColumnName("area");
            entity.Property(e => e.Capacity).HasColumnName("capacity");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Feeding>(entity =>
        {
            entity.HasKey(e => e.FeedingId).HasName("feeding_pkey");

            entity.ToTable("feeding", "mod");

            entity.Property(e => e.FeedingId)
                .ValueGeneratedNever()
                .HasColumnName("feeding_id");
            entity.Property(e => e.AnimalId).HasColumnName("animal_id");
            entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
            entity.Property(e => e.FeedingTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("feeding_time");
            entity.Property(e => e.Notes).HasColumnName("notes");
            entity.Property(e => e.Quantity)
                .HasPrecision(10, 2)
                .HasColumnName("quantity");
            entity.Property(e => e.SupplierId).HasColumnName("supplier_id");

            entity.HasOne(d => d.Animal).WithMany(p => p.Feedings)
                .HasForeignKey(d => d.AnimalId)
                .HasConstraintName("feeding_animal_id_fkey");

            entity.HasOne(d => d.Employee).WithMany(p => p.FeedingEmployees)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("feeding_employee_id_fkey");

            entity.HasOne(d => d.Supplier).WithMany(p => p.FeedingSuppliers)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("feeding_supplier_id_fkey");
        });

        modelBuilder.Entity<ParticipationInTour>(entity =>
        {
            entity.HasKey(e => e.ParticipationId).HasName("participation_in_tour_pkey");

            entity.ToTable("participation_in_tour", "mod");

            entity.Property(e => e.ParticipationId)
                .ValueGeneratedNever()
                .HasColumnName("participation_id");
            entity.Property(e => e.AttendanceStatus)
                .HasMaxLength(50)
                .HasColumnName("attendance_status");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");
            entity.Property(e => e.TourId).HasColumnName("tour_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Tour).WithMany(p => p.ParticipationInTours)
                .HasForeignKey(d => d.TourId)
                .HasConstraintName("participation_in_tour_tour_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.ParticipationInTours)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("participation_in_tour_user_id_fkey");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("role_pkey");

            entity.ToTable("role", "mod");

            entity.HasIndex(e => e.Name, "role_name_key").IsUnique();

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("ticket_pkey");

            entity.ToTable("ticket", "mod");

            entity.Property(e => e.TicketId)
                .ValueGeneratedNever()
                .HasColumnName("ticket_id");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.PurchaseDate).HasColumnName("purchase_date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TicketTypeId).HasColumnName("ticket_type_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VisitDate).HasColumnName("visit_date");

            entity.HasOne(d => d.TicketType).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TicketTypeId)
                .HasConstraintName("ticket_ticket_type_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("ticket_user_id_fkey");
        });

        modelBuilder.Entity<TicketType>(entity =>
        {
            entity.HasKey(e => e.TicketTypeId).HasName("ticket_type_pkey");

            entity.ToTable("ticket_type", "mod");

            entity.Property(e => e.TicketTypeId)
                .ValueGeneratedNever()
                .HasColumnName("ticket_type_id");
            entity.Property(e => e.BasePrice)
                .HasPrecision(10, 2)
                .HasColumnName("base_price");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.TourId).HasName("tour_pkey");

            entity.ToTable("tour", "mod");

            entity.Property(e => e.TourId)
                .ValueGeneratedNever()
                .HasColumnName("tour_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Duration).HasColumnName("duration");
            entity.Property(e => e.GuideId).HasColumnName("guide_id");
            entity.Property(e => e.MaxParticipants).HasColumnName("max_participants");
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .HasColumnName("name");
            entity.Property(e => e.StartTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("start_time");

            entity.HasOne(d => d.Guide).WithMany(p => p.Tours)
                .HasForeignKey(d => d.GuideId)
                .HasConstraintName("tour_guide_id_fkey");
        });

        modelBuilder.Entity<UserAccount>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("user_account_pkey");

            entity.ToTable("user_account", "mod");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(150)
                .HasColumnName("full_name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("phone_number");
            entity.Property(e => e.RegistrationDate).HasColumnName("registration_date");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.UserAccounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("user_account_role_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
