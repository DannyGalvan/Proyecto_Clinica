using System.Diagnostics;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Data.Context
{
    public partial class ClinicContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ClinicContext() { }

        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("server=DESKTOP-4L7JSNJ; Database=Clinic;User Id=sa; Password=andrea2911; Trust Server Certificate=true");

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<RolOperation> RolOperations { get; set; }
        public virtual DbSet<RequestStatus> RequestStatus { get; set; }
        public virtual DbSet<SupportType> SupportTypes { get; set; }
        public virtual DbSet<ExamType> ExamTypes { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<TraceabilityRequests> TraceabilityRequests { get; set; }
        public virtual DbSet<Documents> Documents { get; set; }
        public virtual DbSet<UserAssignments> UserAssignments { get; set; }
        public virtual DbSet<SampleType> SampleTypes { get; set; }
        public virtual DbSet<UnitMeasure> UnitMeasurements { get; set; }
        public virtual DbSet<Sample> Samples { get; set; }
        public virtual DbSet<DocumentTypeAnalysis> DocumentTypesAnalysis { get; set; }
        public virtual DbSet<AnalysisDocument> AnalysisDocuments { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<SamplesItem> SamplesItems { get; set; }
        public virtual DbSet<LogHeader> LogHeaders { get; set; }
        public virtual DbSet<LogBookDetail> LogBookDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Roles");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Description)
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));
                entity.Property(e => e.UpdatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : (DateTime?)null,
                                     v => v.HasValue ? v.Value.ToString("yyyy-MM-dd") : null);

                entity.HasOne(d => d.Creator).WithMany(p => p.RolCreator)
                      .HasForeignKey(d => d.CreatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Updater).WithMany(p => p.RolUpdater)
                      .HasForeignKey(d => d.UpdatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasData(
                    new Rol
                    {
                        Id = 1,
                        Name = "Manager",
                        CreatedBy = 1,
                    },
                    new Rol
                    {
                        Id        = 2,
                        Name      = "Centralizador",
                        CreatedBy = 1,
                    },
                    new Rol
                    {
                        Id        = 3,
                        Name      = "Técnico",
                        CreatedBy = 1,
                    },
                    new Rol
                    {
                        Id        = 4,
                        Name      = "Analista",
                        CreatedBy = 1,
                    }
                );
            });

            modelBuilder.Entity<User>(entity =>
                                      {
                                          entity.HasKey(e => e.Id);

                                          entity.ToTable("Users");

                                          entity.Property(e => e.Active)
                                                .HasDefaultValueSql("((1))");
                                          entity.Property(e => e.Confirm)
                                                .HasDefaultValueSql("((0))");
                                          entity.Property(e => e.Password)
                                                .HasMaxLength(100)
                                                .IsUnicode(false);
                                          entity.Property(e => e.Email)
                                                .HasMaxLength(100)
                                                .IsUnicode(false);
                                          entity.Property(e => e.CreatedAt)
                                                .HasColumnType("datetime")
                                                .HasConversion(
                                                               v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                                               v => v.ToString("yyyy-MM-dd"));
                                          entity.Property(e => e.Number)
                                                .HasMaxLength(8)
                                                .IsUnicode(false);
                                          entity.Property(e => e.Reset)
                                                .HasDefaultValueSql("((0))");
                                          entity.Property(e => e.RecoveryToken)
                                                .HasMaxLength(255)
                                                .IsUnicode(false)
                                                .HasDefaultValue("");


                                          entity.HasData(
                                                         new User
                                                         {
                                                             Id = 1,
                                                             Email = "pruebas.test29111999@gmail.com",
                                                             Password = "b20b0f63ce2ed361e8845d6bf2e59811aaa06ec96bcdb92f9bc0c5a25e83c9a6",
                                                             Number = "51995142",
                                                             Active = true,
                                                             Confirm = true,
                                                         }
                                                        );
                                      });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Modules");

                entity.Property(e => e.Name)
                   .HasMaxLength(50);
                entity.Property(e => e.Description)
                  .HasMaxLength(255);
                entity.Property(e => e.Image)
                  .HasMaxLength(50);
                entity.Property(e => e.Path)
                  .HasMaxLength(100);

                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));
                entity.Property(e => e.UpdatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : (DateTime?)null,
                                     v => v.HasValue ? v.Value.ToString("yyyy-MM-dd") : null);

                entity.HasOne(d => d.Creator).WithMany(p => p.ModuleCreator)
                      .HasForeignKey(d => d.CreatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Updater).WithMany(p => p.ModuleUpdater)
                      .HasForeignKey(d => d.UpdatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasData(
                               new Module
                               {
                                   Name = "Mantenimiento Analistas",
                                   Description = "Mantenimiento de usuarios",
                                   Image = "users",
                                   Path = "/Users",
                                   Id = 1,
                                   CreatedBy = 1
                               }
                               );
            });

            modelBuilder.Entity<Departments>(entity =>
             {
                 entity.HasKey(e => e.Id);

                 entity.Property(e => e.Name)
                       .HasMaxLength(50)
                       .IsUnicode(false);
                 entity.Property(e => e.Description)
                       .HasMaxLength(255)
                       .IsUnicode(false);
                 entity.Property(e => e.CreatedAt)
                       .HasColumnType("datetime")
                       .HasConversion(
                                      v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                      v => v.ToString("yyyy-MM-dd"));
                 entity.Property(e => e.UpdatedAt)
                       .HasColumnType("datetime")
                       .HasConversion(
                                      v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : (DateTime?)null,
                                      v => v.HasValue ? v.Value.ToString("yyyy-MM-dd") : null);

                 entity.HasOne(d => d.Creator).WithMany(p => p.DepartmentsCreator)
                       .HasForeignKey(d => d.CreatedBy)
                       .OnDelete(DeleteBehavior.ClientSetNull);

                 entity.HasOne(d => d.Updater).WithMany(p => p.DepartmentsUpdater)
                       .HasForeignKey(d => d.UpdatedBy)
                       .OnDelete(DeleteBehavior.ClientSetNull);

                 entity.HasData(
                                new Departments
                                {
                                    Name = "Administrador",
                                    Description = "Administrador",
                                    Id = 1,
                                    CreatedBy = 1,
                                }
                               );


             });

            modelBuilder.Entity<Employee>(entity =>
              {
                  entity.HasKey(e => e.Id);

                  entity.Property(e => e.UserName)
                        .HasMaxLength(255);
                  entity.Property(e => e.CreatedAt)
                        .HasColumnType("datetime")
                        .HasConversion(
                                       v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                       v => v.ToString("yyyy-MM-dd"));

                  entity.HasOne(d => d.Creator).WithMany(p => p.AssigningEmployees)
                        .HasForeignKey(d => d.CreatedBy)
                        .OnDelete(DeleteBehavior.ClientSetNull);

                  entity.HasOne(d => d.User).WithMany(p => p.Employees)
                        .HasForeignKey(d => d.UserId)
                        .OnDelete(DeleteBehavior.ClientSetNull);

                  entity.HasOne(d => d.Departments).WithMany(p => p.Employees)
                        .HasForeignKey(d => d.DepartmentId)
                        .OnDelete(DeleteBehavior.ClientSetNull);

                  entity.HasData(
                                 new Employee
                                 {
                                     Id = 1,
                                     RolId = 1,
                                     CreatedBy = 1,
                                     UserId = 1,
                                     UnitId = 1,
                                     UserName = "System",
                                     Name = "Usuario Manager",
                                     DepartmentId = 1,
                                 }
                                );

              });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .HasMaxLength(150);
                entity.Property(e => e.LastName)
                      .HasMaxLength(150);
                entity.Property(e => e.Nit)
                      .HasMaxLength(8);
                entity.Property(e => e.Cui)
                      .HasMaxLength(13);
                entity.Property(e => e.Number)
                      .HasMaxLength(8);
                entity.Property(e => e.Address)
                      .HasMaxLength(255);
                entity.Property(e => e.Profession)
                      .HasMaxLength(150);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));

                entity.HasOne(d => d.User).WithMany(p => p.Clients)
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<RequestStatus>(entity =>
             {
                 entity.HasKey(e => e.Id);

                 entity.Property(e => e.Name)
                       .HasMaxLength(50)
                       .IsUnicode(false);
                 entity.Property(e => e.Description)
                       .HasMaxLength(255)
                       .IsUnicode(false);
                 entity.Property(e => e.CreatedAt)
                       .HasColumnType("datetime")
                       .HasConversion(
                                      v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                      v => v.ToString("yyyy-MM-dd"));
                 entity.Property(e => e.UpdatedAt)
                       .HasColumnType("datetime")
                       .HasConversion(
                                      v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : (DateTime?)null,
                                      v => v.HasValue ? v.Value.ToString("yyyy-MM-dd") : null);

                 entity.HasOne(d => d.Creator).WithMany(p => p.RequestStatusCreator)
                       .HasForeignKey(d => d.CreatedBy)
                       .OnDelete(DeleteBehavior.ClientSetNull);

                 entity.HasOne(d => d.Updater).WithMany(p => p.RequestStatusUpdater)
                       .HasForeignKey(d => d.UpdatedBy)
                       .OnDelete(DeleteBehavior.ClientSetNull);

                 entity.HasData(
                                new RequestStatus
                                {
                                    Name = "Cr",
                                    Description = "Creada",
                                    Id = 1,
                                    CreatedBy = 1,
                                },
                                new RequestStatus
                                {
                                    Name = "EN",
                                    Description = "Enviada",
                                    Id = 2,
                                    CreatedBy = 1,
                                },
                                new RequestStatus
                                {
                                    Name = "RV",
                                    Description = "Revisada",
                                    Id = 3,
                                    CreatedBy = 1,
                                },
                                new RequestStatus
                                {
                                    Name = "AN",
                                    Description = "Análisis",
                                    Id = 4,
                                    CreatedBy = 1,
                                },
                                new RequestStatus
                                {
                                    Name = "AS",
                                    Description = "Asignada",
                                    Id = 5,
                                    CreatedBy = 1,
                                },
                                new RequestStatus
                                {
                                    Name = "AU",
                                    Description = "Autorizada",
                                    Id = 6,
                                    CreatedBy = 1,
                                },
                                new RequestStatus
                                {
                                    Name = "RE",
                                    Description = "Rechazada",
                                    Id = 7,
                                    CreatedBy = 1,
                                },
                                new RequestStatus
                                {
                                    Name = "EL",
                                    Description = "Eliminada",
                                    Id = 8,
                                    CreatedBy = 1,
                                }
                               );


             });

            modelBuilder.Entity<SupportType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .HasMaxLength(50)
                      .IsUnicode(false);
                entity.Property(e => e.Description)
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));
                entity.Property(e => e.UpdatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : (DateTime?)null,
                                     v => v.HasValue ? v.Value.ToString("yyyy-MM-dd") : null);

                entity.HasOne(d => d.Creator).WithMany(p => p.SupportTypeCreator)
                      .HasForeignKey(d => d.CreatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Updater).WithMany(p => p.SupportTypeUpdater)
                      .HasForeignKey(d => d.UpdatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasData(
                               new SupportType
                               {
                                   Name = "CP",
                                   Description = "Comprobante de Pago",
                                   Id = 1,
                                   CreatedBy = 1,
                               },
                               new SupportType
                               {
                                   Name = "SE",
                                   Description = "Seguro Médico",
                                   Id = 2,
                                   CreatedBy = 1,
                               },
                               new SupportType
                               {
                                   Name = "SM",
                                   Description = "Solicitud Médica",
                                   Id = 3,
                                   CreatedBy = 1,
                               },
                               new SupportType
                               {
                                   Name = "ET",
                                   Description = "Examen Externo",
                                   Id = 4,
                                   CreatedBy = 1,
                               }
                              );

            });

            modelBuilder.Entity<ExamType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .HasMaxLength(50)
                      .IsUnicode(false);
                entity.Property(e => e.Description)
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));
                entity.Property(e => e.UpdatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : (DateTime?)null,
                                     v => v.HasValue ? v.Value.ToString("yyyy-MM-dd") : null);

                entity.HasOne(d => d.Creator).WithMany(p => p.ExamTypeCreator)
                      .HasForeignKey(d => d.CreatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Updater).WithMany(p => p.ExamTypeUpdater)
                      .HasForeignKey(d => d.UpdatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasData(
                               new ExamType
                               {
                                   Name = "HE",
                                   Description = "Hematología",
                                   Id = 1,
                                   CreatedBy = 1,
                               },
                               new ExamType
                               {
                                   Name = "QC",
                                   Description = "Química Clínica",
                                   Id = 2,
                                   CreatedBy = 1,
                               },
                               new ExamType
                               {
                                   Name = "IN",
                                   Description = "Inmunología",
                                   Id = 3,
                                   CreatedBy = 1,
                               },
                               new ExamType
                               {
                                   Name = "MC",
                                   Description = "Microbiología",
                                   Id = 4,
                                   CreatedBy = 1,
                               },
                               new ExamType
                               {
                                   Name = "SR",
                                   Description = "Serología",
                                   Id = 5,
                                   CreatedBy = 1,
                               },
                               new ExamType
                               {
                                   Name = "HM",
                                   Description = "Hormonas",
                                   Id = 6,
                                   CreatedBy = 1,
                               },
                               new ExamType
                               {
                                   Name = "GB",
                                   Description = "Genética y Biología Molecular",
                                   Id = 7,
                                   CreatedBy = 1,
                               },
                               new ExamType
                               {
                                   Name = "CT",
                                   Description = "Citología",
                                   Id = 8,
                                   CreatedBy = 1,
                               },
                               new ExamType
                               {
                                   Name = "MC",
                                   Description = "Microbiología",
                                   Id = 9,
                                   CreatedBy = 1,
                               },
                               new ExamType
                               {
                                   Name = "GS",
                                   Description = "Gases en Sangre",
                                   Id = 10,
                                   CreatedBy = 1,
                               }
                              );

            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.SupportNumber)
                      .HasMaxLength(50);
                entity.Property(e => e.Description)
                      .HasMaxLength(255);
                entity.Property(e => e.Latitude)
                      .HasMaxLength(20);
                entity.Property(e => e.Longitude)
                      .HasMaxLength(20);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));

                entity.HasOne(d => d.Status).WithMany(p => p.Requests)
                      .HasForeignKey(d => d.RequestStatusId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Client).WithMany(p => p.Requests)
                      .HasForeignKey(d => d.ClientId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Support).WithMany(p => p.Requests)
                      .HasForeignKey(d => d.SupportTypeId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.ExamType).WithMany(p => p.Requests)
                      .HasForeignKey(d => d.ExamTypeId)
                      .OnDelete(DeleteBehavior.ClientSetNull);


            });

            modelBuilder.Entity<TraceabilityRequests>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Observations)
                      .HasMaxLength(255);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));

                entity.HasOne(d => d.Status).WithMany(p => p.Traceability)
                      .HasForeignKey(d => d.StatusRequestId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Request).WithMany(p => p.TraceabilityRequests)
                      .HasForeignKey(d => d.RequestId)
                      .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<Documents>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Observations)
                      .HasMaxLength(255);
                entity.Property(e => e.Path)
                      .HasMaxLength(100);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));

                entity.HasOne(d => d.Request).WithMany(p => p.Documents)
                      .HasForeignKey(d => d.RequestId)
                      .OnDelete(DeleteBehavior.ClientSetNull);


            });

            modelBuilder.Entity<UserAssignments>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));

                entity.HasOne(d => d.Request).WithMany(p => p.UserAssignments)
                      .HasForeignKey(d => d.RequestId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Assigned).WithMany(p => p.AssignedUsers)
                      .HasForeignKey(d => d.AssignedUserId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Assigner).WithMany(p => p.AssigningUsers)
                      .HasForeignKey(d => d.AssignerUserId)
                      .OnDelete(DeleteBehavior.ClientSetNull);


            });

            modelBuilder.Entity<SampleType>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .HasMaxLength(50)
                      .IsUnicode(false);
                entity.Property(e => e.Description)
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));
                entity.Property(e => e.UpdatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : (DateTime?)null,
                                     v => v.HasValue ? v.Value.ToString("yyyy-MM-dd") : null);

                entity.HasOne(d => d.Creator).WithMany(p => p.SampleTypeCreator)
                      .HasForeignKey(d => d.CreatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Updater).WithMany(p => p.SampleTypeUpdater)
                      .HasForeignKey(d => d.UpdatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasData(
                               new SampleType
                               {
                                   Name = "CL",
                                   Description = "Cultivo",
                                   Id = 1,
                                   CreatedBy = 1,
                               },
                               new SampleType
                               {
                                   Name = "PL",
                                   Description = "Plaquetas",
                                   Id = 2,
                                   CreatedBy = 1,
                               },
                               new SampleType
                               {
                                   Name = "ES",
                                   Description = "Eses",
                                   Id = 3,
                                   CreatedBy = 1,
                               },
                               new SampleType
                               {
                                   Name = "OR",
                                   Description = "Orina",
                                   Id = 4,
                                   CreatedBy = 1,
                               }
                              );

            });

            modelBuilder.Entity<UnitMeasure>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .HasMaxLength(50)
                      .IsUnicode(false);
                entity.Property(e => e.Description)
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));
                entity.Property(e => e.UpdatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : (DateTime?)null,
                                     v => v.HasValue ? v.Value.ToString("yyyy-MM-dd") : null);

                entity.HasOne(d => d.Creator).WithMany(p => p.UnitMeasureCreator)
                      .HasForeignKey(d => d.CreatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Updater).WithMany(p => p.UnitMeasureUpdater)
                      .HasForeignKey(d => d.UpdatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasData(
                               new UnitMeasure
                               {
                                   Name = "MG",
                                   Description = "Miligramos",
                                   Id = 1,
                                   CreatedBy = 1,
                               },
                               new UnitMeasure
                               {
                                   Name = "GR",
                                   Description = "Gramos",
                                   Id = 2,
                                   CreatedBy = 1,
                               },
                               new UnitMeasure
                               {
                                   Name = "MI",
                                   Description = "Mililitros",
                                   Id = 3,
                                   CreatedBy = 1,
                               }
                              );

            });

            modelBuilder.Entity<Sample>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Presentation)
                      .HasMaxLength(2000);
                entity.Property(e => e.Label)
                      .HasMaxLength(255);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));
                entity.Property(e => e.ExpiresAt)
                      .HasDefaultValueSql("(GetDate())")
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture),
                                     v => v.ToString("dd-MM-yyyy"));

                entity.HasOne(d => d.SampleType).WithMany(p => p.Samples)
                      .HasForeignKey(d => d.TypeSampleId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.UnitMeasure).WithMany(p => p.Samples)
                      .HasForeignKey(d => d.UnitMeasurementId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(d => d.Request).WithMany(p => p.Samples)
                      .HasForeignKey(d => d.RequestId)
                      .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<DocumentTypeAnalysis>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .HasMaxLength(50)
                      .IsUnicode(false);
                entity.Property(e => e.Description)
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));
                entity.Property(e => e.UpdatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : (DateTime?)null,
                                     v => v.HasValue ? v.Value.ToString("yyyy-MM-dd") : null);

                entity.HasOne(d => d.Creator).WithMany(p => p.DocumentTypeAnalysisCreator)
                      .HasForeignKey(d => d.CreatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Updater).WithMany(p => p.DocumentTypeAnalysisUpdater)
                      .HasForeignKey(d => d.UpdatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);


                entity.HasData(
                               new DocumentTypeAnalysis
                               {
                                   Name = "PE-01",
                                   Description = "Certificación de Muestra Médica",
                                   Id = 1,
                                   CreatedBy = 1,
                               },
                               new DocumentTypeAnalysis
                               {
                                   Name = "PE-02",
                                   Description = "Dictamen de Muestra Médica",
                                   Id = 2,
                                   CreatedBy = 1,
                               }
                              );

            });

            modelBuilder.Entity<AnalysisDocument>(entity =>
            {
                entity.HasKey(e => e.Id);


                entity.Property(e => e.Conclusion)
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));


                entity.HasOne(d => d.Sample).WithMany(p => p.AnalysisDocuments)
                      .HasForeignKey(d => d.SampleId)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.DocumentTypeAnalysis).WithMany(p => p.AnalysisDocuments)
                      .HasForeignKey(d => d.DocumentTypeAnalysisId)
                      .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                      .HasMaxLength(50)
                      .IsUnicode(false);
                entity.Property(e => e.Description)
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));
                entity.Property(e => e.UpdatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : (DateTime?)null,
                                     v => v.HasValue ? v.Value.ToString("yyyy-MM-dd") : null);

                entity.HasOne(d => d.Creator).WithMany(p => p.ItemCreator)
                      .HasForeignKey(d => d.CreatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Updater).WithMany(p => p.ItemUpdater)
                      .HasForeignKey(d => d.UpdatedBy)
                      .OnDelete(DeleteBehavior.ClientSetNull);


            });

            modelBuilder.Entity<SamplesItem>(entity =>
            {
                entity.HasKey(e => e.Id);


                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));


                entity.HasOne(d => d.Item).WithMany(p => p.Items)
                      .HasForeignKey(d => d.ItemId)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Sample).WithMany(p => p.SamplesItems)
                      .HasForeignKey(d => d.SampleId)
                      .OnDelete(DeleteBehavior.ClientSetNull);


            });

            modelBuilder.Entity<LogHeader>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.IpMachine)
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(e => e.RegisterId)
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(e => e.TableName)
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(e => e.OperationType)
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));


                entity.HasOne(d => d.User).WithMany(p => p.LogHeaders)
                      .HasForeignKey(d => d.UserId)
                      .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<LogBookDetail>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FieldName)
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(e => e.PreviousValue)
                      .HasMaxLength(255)
                      .IsUnicode(false);
                entity.Property(e => e.LastValue)
                      .HasMaxLength(255)
                      .IsUnicode(false);


                entity.HasOne(d => d.Header).WithMany(p => p.Details)
                        .HasForeignKey(d => d.IdLog)
                        .OnDelete(DeleteBehavior.ClientSetNull);

            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Operations");

                entity.Property(e => e.Name)
                .HasMaxLength(50);
                entity.Property(e => e.Description)
                      .HasMaxLength(255);
                entity.Property(e => e.Icon)
                      .HasMaxLength(50);
                entity.Property(e => e.Path)
                      .HasMaxLength(100);
                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));

                entity.HasOne(d => d.Modulo).WithMany(p => p.Operations)
                  .HasForeignKey(d => d.IdModule)
                  .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasData(
                               new Operation
                               {
                                   Name = "Crear Analista",
                                   IdModule = 1,
                                   Id = 1,
                                   Icon = "plus",
                                   Description = "Creación de nuevo analista",
                                   IsVisible = true,
                                   Path = "/User/Create",
                               },
                               new Operation
                               {
                                   Name = "Actualizar Analista",
                                   IdModule = 1,
                                   Id = 2,
                                   Icon = "",
                                   Description = "Actualización de analista",
                                   IsVisible = false,
                                   Path = "/User/Update"
                               },
                               new Operation
                               {
                                   Name = "Listar Analistas",
                                   IdModule = 1,
                                   Id = 3,
                                   Icon = "",
                                   Description = "Listado de Analistas Existentes",
                                   IsVisible = true,
                                   Path = "/User"
                               },
                               new Operation
                               {
                                   Name = "Actualizar Analista Parcialmente",
                                   IdModule = 1,
                                   Id = 4,
                                   Icon = "",
                                   Description = "Actualización de analista",
                                   IsVisible = false,
                                   Path = "/User/Patch"
                               }
                              );

            });

            modelBuilder.Entity<RolOperation>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("RolOperations");

                entity.Property(e => e.CreatedAt)
                      .HasColumnType("datetime")
                      .HasConversion(
                                     v => !string.IsNullOrEmpty(v) ? DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture) : DateTime.Now,
                                     v => v.ToString("yyyy-MM-dd"));

                entity.HasOne(d => d.Rol).WithMany(p => p.RolOperations)
                  .HasForeignKey(d => d.RolId)
                  .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Operation).WithMany(p => p.RolOperations)
                 .HasForeignKey(d => d.OperationId)
                 .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasData(
                               new RolOperation
                               {
                                   Id = 1,
                                   OperationId = 1,
                                   RolId = 1,
                               },
                               new RolOperation
                               {
                                   Id = 2,
                                   OperationId = 2,
                                   RolId = 1,
                               },
                               new RolOperation
                               {
                                   Id = 3,
                                   OperationId = 3,
                                   RolId = 1,
                               },
                               new RolOperation
                               {
                                   Id = 4,
                                   OperationId = 4,
                                   RolId = 1,
                               }
                              );
            });
        }
    }
}
