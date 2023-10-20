using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARSNunitAutomation.JasonObjectClasses
{
    public class AddCertificationInvalidInput
    {
        public string CertificationName { get; set; }
        public string CertifiedFrom { get; set; }
        public string Year { get; set; }

        public string PopUpMessage { get; set; } = string.Empty;
    }
}
