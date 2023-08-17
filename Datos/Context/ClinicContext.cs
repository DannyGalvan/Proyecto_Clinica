using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public partial class ClinicContext : DbContext
    {
        #pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ClinicContext() { }
       
        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("server=DESKTOP-4L7JSNJ; Database=Clinic;User Id=sa; Password=andrea2911; Trust Server Certificate=true");

        public virtual DbSet<Rol>          Roles         { get; set; }
        public virtual DbSet<User>         Users         { get; set; }
        public virtual DbSet<Module>       Modules       { get; set; }
        public virtual DbSet<Operation>    Operations    { get; set; }
        public virtual DbSet<RolOperation> RolOperations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Users");

                entity.Property(e => e.Active)
                    .HasDefaultValueSql("((1))");
                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.RolId)
                    .HasDefaultValueSql("((2))");
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Number)
                    .HasMaxLength(15)
                    .IsUnicode(false);
                entity.Property(e => e.Reset)
                    .HasDefaultValueSql("((0))");
                entity.Property(e => e.RecoveryToken)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasDefaultValue("");

                entity.HasOne(d => d.Rol).WithMany(p => p.Users)
                    .HasForeignKey(d => d.RolId);

                entity.HasData(
                   new User
                   {
                       Id = 1,
                       Name = "System",
                       Email = "pruebas.test29111999@gmail.com",
                       Password = "b20b0f63ce2ed361e8845d6bf2e59811aaa06ec96bcdb92f9bc0c5a25e83c9a6",
                       RolId = 1,
                       Number = "Sin registro",
                   }
                );
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Rols");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasData(
                    new Rol
                    {
                        Id = 1,
                        Name = "Manager"
                    },
                    new Rol
                    {
                        Id = 2,
                        Name = "Usuario Interno"
                    },
                    new Rol
                    {
                        Id = 3,
                        Name = "Usuario Externo"
                    }
                );
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Modules");

                entity.Property(e => e.Name)
                   .HasMaxLength(150);
                entity.Property(e => e.Description)
                  .HasMaxLength(500);
                entity.Property(e => e.Image)
                  .HasMaxLength(50);
                entity.Property(e => e.Path)
                  .HasMaxLength(100);

                entity.HasData(
                               new Module
                               {
                                   Name = "Mantenimiento Usuarios",
                                   Description = "Mantenimiento de usuarios",
                                   Image = "users",
                                   Path = "/Users",
                                   Id = 1
                               }
                               );
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("Operations");

                entity.Property(e => e.Name)
                .HasMaxLength(150);

                entity.HasOne(d => d.Modulo).WithMany(p => p.Operations)
                  .HasForeignKey(d => d.IdModule);

                entity.HasData(
                               new Operation
                               {
                                   Name = "Crear Usuarios",
                                   IdModule = 1,
                                   Id = 1,
                               },
                               new Operation
                               {
                                   Name     = "Actualizar Usuarios",
                                   IdModule = 1,
                                   Id       = 2,
                               },
                               new Operation
                               {
                                   Name     = "Listar Usuarios",
                                   IdModule = 1,
                                   Id       = 3,
                               },
                               new Operation
                               {
                                   Name     = "Actualizar Usuarios Parcialmente",
                                   IdModule = 1,
                                   Id       = 4,
                               }
                              );

            });

            modelBuilder.Entity<RolOperation>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("RolOperations");

                entity.Property(e => e.CreatedAt)
                   .HasDefaultValueSql("getDate()")
                   .HasColumnType("datetime");

                entity.HasOne(d => d.Rol).WithMany(p => p.RolOperations)
                  .HasForeignKey(d => d.IdRol);

                entity.HasOne(d => d.Operation).WithMany(p => p.RolOperations)
                 .HasForeignKey(d => d.IdOperation);

                entity.HasData(
                               new RolOperation
                               {
                                   Id = 1,
                                   IdOperation = 1,
                                   IdRol = 1,
                               },
                               new RolOperation
                               {
                                   Id          = 2,
                                   IdOperation = 2,
                                   IdRol       = 1,
                               },
                               new RolOperation
                               {
                                   Id          = 3,
                                   IdOperation = 3,
                                   IdRol       = 1,
                               },
                               new RolOperation
                               {
                                   Id          = 4,
                                   IdOperation = 4,
                                   IdRol       = 1,
                               }
                              );
            });
        }
    }
}
