using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MARSNunitAutomation.JasonObjectClasses
{
    public class AddCertifications
    {
        public string CertificationName { get; set; } = string.Empty;
        public string CertifiedFrom { get; set; } = string.Empty;
        public string Year { get; set; }
    }






}