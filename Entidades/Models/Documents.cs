
namespace Entities.Models
{
    public class Documents
    {
        public int    Id           { get; set; }
        public int    RequestId    { get; set; }
        public string Observations { get; set; } = string.Empty;
        public string Path         { get; set; } = string.Empty;
        public string CreatedAt    { get; set; } = string.Empty;

        public virtual Request? Request { get; set; }
    }
}
