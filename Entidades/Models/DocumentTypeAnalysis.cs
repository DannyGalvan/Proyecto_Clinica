using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class DocumentTypeAnalysis : Catalogue
    {
        public virtual ICollection<AnalysisDocument> AnalysisDocuments { get; set; } = new List<AnalysisDocument>();
    }
}
