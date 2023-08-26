
namespace Entities.Models
{
    public class Employee
    {
        public int    Id           { get; set; }
        public string UserName     { get; set; } = string.Empty;
        public string Name         { get; set; } = string.Empty;
        public int    UserId       { get; set; }
        public int    RolId        { get; set; }
        public int    UnitId       { get; set; }
        public int    DepartmentId { get; set; }
        public int    CreatedBy    { get; set; }
        public string CreatedAt    { get; set; } = string.Empty;

        public virtual User?        User        { get; set; }
        public virtual User?        Creator     { get; set; }
        public virtual Rol?         Rol         { get; set; }
        public virtual Departments? Departments { get; set; }
    }
}
