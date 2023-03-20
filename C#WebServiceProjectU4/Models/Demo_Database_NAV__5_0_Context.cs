using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Collections.Generic;
using static WebApplicationCronus.CronusWebService;
using System.Runtime.Remoting.Contexts;
using WebApplicationCronus;
using Microsoft.Extensions.Configuration;

namespace WebApplicationCronus.Models
{
    public partial class Demo_Database_NAV__5_0_Context : DbContext
    {
        public Demo_Database_NAV__5_0_Context()
        {
        }

        public Demo_Database_NAV__5_0_Context(DbContextOptions<Demo_Database_NAV__5_0_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CronusSverigeAbEmployee> CronusSverigeAbEmployee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = MyConfigurationHelper.GetConfiguration();
                string connectionString = configuration.GetConnectionString("Assignment4Connection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                                
            modelBuilder.Entity<CronusSverigeAbEmployee>(entity =>
            {
            entity.HasKey(e => e.No);

            entity.ToTable("CRONUS Sverige AB$Employee");

            entity.HasIndex(e => new { e.SearchName, e.No })
                .HasName("$1")
                .IsUnique();

            entity.HasIndex(e => new { e.Status, e.EmplymtContractCode, e.No })
                .HasName("$3")
                .IsUnique();

            entity.HasIndex(e => new { e.Status, e.UnionCode, e.No })
                .HasName("$2")
                .IsUnique();

            entity.HasIndex(e => new { e.LastName, e.FirstName, e.MiddleName, e.No })
                .HasName("$4")
                .IsUnique();

            entity.Property(e => e.No)
                .HasColumnName("No_")
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedNever();

            entity.Property(e => e.Address)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Address2)
                .IsRequired()
                .HasColumnName("Address 2")
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.AltAddressCode)
                .IsRequired()
                .HasColumnName("Alt_ Address Code")
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.AltAddressEndDate)
                .HasColumnName("Alt_ Address End Date")
                .HasColumnType("datetime");

            entity.Property(e => e.AltAddressStartDate)
                .HasColumnName("Alt_ Address Start Date")
                .HasColumnType("datetime");

            entity.Property(e => e.BirthDate)
                .HasColumnName("Birth Date")
                .HasColumnType("datetime");

            entity.Property(e => e.CauseOfInactivityCode)
                .IsRequired()
                .HasColumnName("Cause of Inactivity Code")
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.City)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.CompanyEMail)
                .IsRequired()
                .HasColumnName("Company E-Mail")
                .HasMaxLength(80)
                .IsUnicode(false);

            entity.Property(e => e.CountryRegionCode)
                .IsRequired()
                .HasColumnName("Country_Region Code")
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.Property(e => e.County)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.Property(e => e.EMail)
                .IsRequired()
                .HasColumnName("E-Mail")
                .HasMaxLength(80)
                .IsUnicode(false);

                entity.Property(e => e.EmploymentDate)
           .HasColumnName("Employment Date")
           .HasColumnType("datetime");

                entity.Property(e => e.EmplymtContractCode)
                    .IsRequired()
                    .HasColumnName("Emplymt_ Contract Code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Extension)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FaxNo)
                    .IsRequired()
                    .HasColumnName("Fax No_")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.GlobalDimension1Code)
                    .IsRequired()
                    .HasColumnName("Global Dimension 1 Code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GlobalDimension2Code)
                    .IsRequired()
                    .HasColumnName("Global Dimension 2 Code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.GroundsForTermCode)
                    .IsRequired()
                    .HasColumnName("Grounds for Term_ Code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.InactiveDate)
                    .HasColumnName("Inactive Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Initials)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasColumnName("Job Title")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.LastDateModified)
                    .HasColumnName("Last Date Modified")
                    .HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerNo)
                    .IsRequired()
                    .HasColumnName("Manager No_")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("Middle Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MobilePhoneNo)
                    .IsRequired()
                    .HasColumnName("Mobile Phone No_")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NoSeries)
                    .IsRequired()
                    .HasColumnName("No_ Series")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Pager)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo)
                    .IsRequired()
                    .HasColumnName("Phone No_")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Picture).HasColumnType("image");

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasColumnName("Post Code")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ResourceNo)
                    .IsRequired()
                    .HasColumnName("Resource No_")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SalespersPurchCode)
                    .IsRequired()
                    .HasColumnName("Salespers__Purch_ Code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SearchName)
                    .IsRequired()
                    .HasColumnName("Search Name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.SocialSecurityNo)
                    .IsRequired()
                    .HasColumnName("Social Security No_")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StatisticsGroupCode)
                    .IsRequired()
                    .HasColumnName("Statistics Group Code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TerminationDate)
                    .HasColumnName("Termination Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Timestamp)
                    .IsRequired()
                    .HasColumnName("timestamp")
                    .IsRowVersion();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UnionCode)
                    .IsRequired()
                    .HasColumnName("Union Code")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UnionMembershipNo)
                    .IsRequired()
                    .HasColumnName("Union Membership No_")
                    .HasMaxLength(30)
                    .IsUnicode(false);
                
                entity.Property(e => e.Sex)
                    .HasColumnName("Sex")
                    .IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
