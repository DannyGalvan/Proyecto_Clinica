
namespace Entities.Models
{
    public class LogBookDetail
    {
        public int    Id            { get; set; }
        public int    IdLog         { get; set; }
        public string FieldName     { get; set; } = string.Empty;
        public string PreviousValue { get; set; } = string.Empty;
        public string LastValue     { get; set; } = string.Empty;

        public virtual LogHeader? Header { get; set; }
    }
}
