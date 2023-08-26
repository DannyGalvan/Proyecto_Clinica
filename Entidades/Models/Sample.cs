
namespace Entities.Models
{
    public class Sample
    {
        public int    Id                { get; set; }
        public int    TypeSampleId      { get; set; }
        public string Presentation      { get; set; } = string.Empty;
        public int    QuantityUnits     {get;  set; }
        public int    UnitMeasurementId { get; set; }
        public bool   Active            { get; set; }
        public string Label             { get; set; } = string.Empty;
        public int    RequestId         { get; set; }
        public string CreatedAt         { get; set; } = string.Empty;
        public string ExpiresAt         { get; set; } = string.Empty;

        public virtual SampleType?                   SampleType        { get; set; }
        public virtual UnitMeasure?                  UnitMeasure       { get; set; }
        public virtual Request?                      Request           { get; set; }
        public virtual ICollection<AnalysisDocument> AnalysisDocuments { get; set; } = new List<AnalysisDocument>();
        public virtual ICollection<SamplesItem>      SamplesItems      { get; set; } = new List<SamplesItem>();
    }
}
