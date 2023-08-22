
namespace Entities.Models
{
    public class RequestStatus : Catalogue
    {
        public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

        public virtual ICollection<TraceabilityRequests> Traceability { get; set; } =
            new List<TraceabilityRequests>();

    }
}
