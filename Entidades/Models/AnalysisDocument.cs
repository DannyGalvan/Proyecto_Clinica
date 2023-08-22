
namespace Entities.Models
{
    public class AnalysisDocument
    {
        public int     Id                     { get; set; }
        public int     SampleId               {get;  set; }
        public int     DocumentTypeAnalysisId { get; set; }
        public string? Conclusion             { get; set; }
        public string  CreatedAt              { get; set; } = string.Empty;

        public virtual Sample?               Sample               { get; set; }
        public virtual DocumentTypeAnalysis? DocumentTypeAnalysis { get; set; }
    }
}
