using System.Diagnostics;

namespace Entities.Models
{
    public class Request
    {
        public int    Id              { get; set; }
        public int    SupportTypeId   { get; set; }
        public int    ExamTypeId      { get; set; }
        public string SupportNumber   { get; set; } = string.Empty;
        public string Description     { get; set; } = string.Empty;
        public int    RequestStatusId { get; set; }
        public int    ClientId        { get; set; }
        public string Latitude        { get; set; } = string.Empty;
        public string Longitude       { get; set; } = string.Empty;
        public string CreatedAt       { get; set; } = string.Empty;

        public virtual RequestStatus? Status        { get; set; }
        public virtual User?          Client          { get; set; }
        public virtual SupportType? Support { get; set; }
        public virtual ExamType? ExamType { get; set; }
        public virtual ICollection<Sample> Samples { get; set; } = new List<Sample>();
        public virtual ICollection<TraceabilityRequests> TraceabilityRequests { get; set; } = new List<TraceabilityRequests>();
        public virtual ICollection<UserAssignments> UserAssignments { get; set; } = new List<UserAssignments>();
        public virtual ICollection<Documents> Documents { get; set; } = new List<Documents>();
    }
}
