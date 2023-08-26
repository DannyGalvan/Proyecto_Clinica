
using System.Text.Json.Serialization;

namespace Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool Active { get; set; }
        public bool Confirm { get; set; }
        public bool Reset { get; set; }
        public string CreatedAt { get; set; } = string.Empty;
        public string DateToken { get; set; } = string.Empty;
        public int Number { get; set; }
        public string? RecoveryToken { get; set; }
        [JsonIgnore] 
        public virtual ICollection<Employee> AssigningEmployees { get; set; } = new List<Employee>();
        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
        public virtual ICollection<UserAssignments> AssignedUsers { get; set; } = new List<UserAssignments>();
        public virtual ICollection<UserAssignments> AssigningUsers { get; set; } = new List<UserAssignments>();
        public virtual ICollection<Request> Requests { get; set; } = new List<Request>();
        public virtual ICollection<LogHeader> LogHeaders { get; set; } = new List<LogHeader>();
        public virtual ICollection<Departments> DepartmentsCreator { get; set; } = new List<Departments>();
        public virtual ICollection<Departments> DepartmentsUpdater { get; set; } = new List<Departments>();
        public virtual ICollection<DocumentTypeAnalysis> DocumentTypeAnalysisCreator { get; set; } =
            new List<DocumentTypeAnalysis>();
        public virtual ICollection<DocumentTypeAnalysis> DocumentTypeAnalysisUpdater { get; set; } =
            new List<DocumentTypeAnalysis>();
        public virtual ICollection<ExamType> ExamTypeCreator { get; set; } = new List<ExamType>();
        public virtual ICollection<ExamType> ExamTypeUpdater { get; set; } = new List<ExamType>();
        public virtual ICollection<Item> ItemCreator { get; set; } = new List<Item>();
        public virtual ICollection<Item> ItemUpdater { get; set; } = new List<Item>();
        [JsonIgnore] 
        public virtual ICollection<Module> ModuleCreator { get; set; } = new List<Module>();
        public virtual ICollection<Module> ModuleUpdater { get; set; } = new List<Module>();
        public virtual ICollection<RequestStatus> RequestStatusCreator { get; set; } = new List<RequestStatus>();
        public virtual ICollection<RequestStatus> RequestStatusUpdater { get; set; } = new List<RequestStatus>();
        [JsonIgnore] 
        public virtual ICollection<Rol> RolCreator { get; set; } = new List<Rol>();
        public virtual ICollection<Rol> RolUpdater { get; set; } = new List<Rol>();
        public virtual ICollection<SampleType> SampleTypeCreator { get; set; } = new List<SampleType>();
        public virtual ICollection<SampleType> SampleTypeUpdater { get; set; } = new List<SampleType>();
        public virtual ICollection<SupportType> SupportTypeCreator { get; set; } = new List<SupportType>();
        public virtual ICollection<SupportType> SupportTypeUpdater { get; set; } = new List<SupportType>();
        public virtual ICollection<UnitMeasure> UnitMeasureCreator { get; set; } = new List<UnitMeasure>();
        public virtual ICollection<UnitMeasure> UnitMeasureUpdater { get; set; } = new List<UnitMeasure>();

    }
}
