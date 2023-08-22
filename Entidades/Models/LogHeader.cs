
namespace Entities.Models
{
    public class LogHeader
    {
        public int    Id            { get; set; }
        public string IpMachine     { get; set; } = string.Empty;
        public string RegisterId    { get; set; } = string.Empty;
        public string TableName     { get; set; } = string.Empty;
        public string OperationType { get; set; } = string.Empty;
        public int    UserId        { get; set; }
        public string CreatedAt     { get; set; } = string.Empty;

        public virtual User? User { get; set; }
        public virtual ICollection<LogBookDetail> Details { get; set; } = new List<LogBookDetail>();
    }
}
