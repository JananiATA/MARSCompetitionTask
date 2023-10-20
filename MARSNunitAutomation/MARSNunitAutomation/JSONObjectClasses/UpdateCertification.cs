using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARSNunitAutomation.JasonObjectClasses
{
    public class UpdateCertification
    {
        public string CertificationName { get; set; } = string.Empty;
        public string CertifiedFrom { get; set; } = string.Empty;
        public string Year { get; set; }
        public string CertificationNameNew { get; set; } = string.Empty;
        public string CertifiedFromNew { get; set; } = string.Empty;
        public string YearNew { get; set; }

    }
}
