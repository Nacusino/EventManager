using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
namespace MVCApp.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<ApplicationForEvent> ApplicationsForEvents { get; set; }
        public DbSet<Space> Spaces { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServicesList> ServicesLists { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationForEvent>(entity =>
            {
                entity.HasKey(e => e.ApplicationId).HasName("PK__Applicat__3BCBDCF296513CD5");

                entity.ToTable("Applications_for_events");

                entity.Property(e => e.ApplicationId).HasColumnName("application_id");
                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.DesiredEndDate)
                    .HasColumnType("date")
                    .HasColumnName("desired_end_date");
                entity.Property(e => e.DesiredEndTime).HasColumnName("desired_end_time");
                entity.Property(e => e.DesiredStartDate)
                    .HasColumnType("date")
                    .HasColumnName("desired_start_date");
                entity.Property(e => e.DesiredStartTime).HasColumnName("desired_start_time");
                entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
                entity.Property(e => e.OtherRequests)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("other_requests");
                entity.Property(e => e.ServicesDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("services_description");
                entity.Property(e => e.SpaceDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("space_description");

                entity.HasOne(d => d.Customer).WithMany(p => p.ApplicationsForEvent)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Applicati__custo__656C112C");

                entity.HasOne(d => d.EventType).WithMany(p => p.ApplicationsForEvent)
                    .HasForeignKey(d => d.EventTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Applicati__event__66603565");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId).HasName("PK__Customer__CD65CB854FEB7818");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");
                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .HasColumnType("nvarchar")
                    .HasColumnName("firstname");
                entity.Property(e => e.NameOfOrganization)
                    .HasMaxLength(255)
                    .HasColumnType("nvarchar")
                    .HasColumnName("name_of_organization");
                entity.Property(e => e.Patronymic)
                    .HasMaxLength(30)
                    .HasColumnType("nvarchar")
                    .HasColumnName("patronymic");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .HasColumnType("nvarchar")
                    .IsFixedLength()
                    .HasColumnName("phone_number");
                entity.Property(e => e.Surname)
                    .HasMaxLength(30)
                    .HasColumnType("nvarchar")
                    .HasColumnName("surname");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__C52E0BA822384AF7");

                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                entity.Property(e => e.Birthdate)
                    .HasColumnType("date")
                    .HasColumnName("birthdate");
                entity.Property(e => e.EventCarryingCost)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("event_carrying_cost");
                entity.Property(e => e.Firstname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("firstname");
                entity.Property(e => e.PassportDateOfIssue)
                    .HasColumnType("date")
                    .HasColumnName("passport_date_of_issue");
                entity.Property(e => e.PassportIssuedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("passport_issued_by");
                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("passport_number");
                entity.Property(e => e.PassportSeries)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("passport_series");
                entity.Property(e => e.Patronymic)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("patronymic");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("phone_number");
                entity.Property(e => e.Photo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("photo");
                entity.Property(e => e.PostId).HasColumnName("post_id");
                entity.Property(e => e.Surname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.HasOne(d => d.Post).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Employees__post___6D0D32F4");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => e.EventId).HasName("PK__Events__2370F72706BA2120");

                entity.Property(e => e.EventId).HasColumnName("event_id");
                entity.Property(e => e.ApplicationId).HasColumnName("application_id");
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");
                entity.Property(e => e.EndTime).HasColumnName("end_time");
                entity.Property(e => e.GradeAfterEvent).HasColumnName("grade_after_event");
                entity.Property(e => e.HostId).HasColumnName("host_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.ReviewAfterEvent)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("review_after_event");
                entity.Property(e => e.SpaceId).HasColumnName("space_id");
                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");
                entity.Property(e => e.StartTime).HasColumnName("start_time");

                entity.HasOne(d => d.Application).WithMany(p => p.Events)
                    .HasForeignKey(d => d.ApplicationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Events__applicat__70DDC3D8");

                entity.HasOne(d => d.Employee).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Events__employee__73BA3083");

                entity.HasOne(d => d.Host).WithMany(p => p.Hosts)
                    .HasForeignKey(d => d.HostId)
                    .HasConstraintName("FK__Events__host_id__72C60C4A");

                entity.HasOne(d => d.Space).WithMany(p => p.Events)
                    .HasForeignKey(d => d.SpaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Events__space_id__71D1E811");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.HasKey(e => e.EventTypeId).HasName("PK__Event_ty__BB84C6F33E5D2284");

                entity.ToTable("Event_types");

                entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
                entity.Property(e => e.ExtraCharge).HasColumnName("extra_charge");
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(e => e.PostId).HasName("PK__Posts__3ED78766795E23AB");

                entity.Property(e => e.PostId).HasColumnName("post_id");
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.ServiceId).HasName("PK__Services__3E0DB8AFD430C370");

                entity.Property(e => e.ServiceId).HasColumnName("service_id");
                entity.Property(e => e.Cost)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("cost");
                entity.Property(e => e.Description)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("description");
                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("name");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("phone_number");
            });

            modelBuilder.Entity<ServicesList>(entity =>
            {
                entity.HasKey(e => e.ServiceListId).HasName("PK__Services__E44AC9B05D881D24");

                entity.ToTable("Services_lists");

                entity.Property(e => e.ServiceListId).HasColumnName("service_list_id");
                entity.Property(e => e.EventId).HasColumnName("event_id");
                entity.Property(e => e.ServiceId).HasColumnName("service_id");

                entity.HasOne(d => d.Event).WithMany(p => p.ServicesLists)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Services___event__797309D9");

                entity.HasOne(d => d.Service).WithMany(p => p.ServicesLists)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Services___servi__7A672E12");
            });

            modelBuilder.Entity<Space>(entity =>
            {
                entity.HasKey(e => e.SpaceId).HasName("PK__Spaces__793ECA55FBB438F4");

                entity.Property(e => e.SpaceId).HasColumnName("space_id");
                entity.Property(e => e.Apartment).HasColumnName("apartment");
                entity.Property(e => e.City)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("city");
                entity.Property(e => e.Corpus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("corpus");
                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country");
                entity.Property(e => e.CountrySubject)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("country_subject");
                entity.Property(e => e.House).HasColumnName("house");
                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasColumnName("phone_number");
                entity.Property(e => e.Photo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("photo");
                entity.Property(e => e.RentCostPerDay)
                    .HasColumnType("numeric(10, 2)")
                    .HasColumnName("rent_cost_per_day");
                entity.Property(e => e.Street)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("street");
            });



        }
        
    }
    

}

