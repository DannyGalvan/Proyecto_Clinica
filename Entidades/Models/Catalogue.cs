
namespace Entities.Models
{
    public abstract class Catalogue : ICatalogue
    {
        public         int     Id          { get; set; }
        public         string  Name        { get; set; } = string.Empty;    
        public         string  Description { get; set; } = string.Empty;
        public         string  CreatedAt   { get; set; } = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        public         string? UpdatedAt   { get; set; }
        public         int     CreatedBy   { get; set; }
        public         int?    UpdatedBy   { get; set; }
        public virtual User?   Creator     { get; set; }
        public virtual User?   Updater     { get; set; }
    }
}
