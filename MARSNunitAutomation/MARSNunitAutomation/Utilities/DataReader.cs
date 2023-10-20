using MARSNunitAutomation.JasonObjectClasses;
using MARSNunitAutomation.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARSNunitAutomation.Utilities
{
    public class DataReader
    {
        private readonly string _sampleJsonFilePath;
        public DataReader(string sampleJsonFilePath)
        {
            _sampleJsonFilePath = sampleJsonFilePath;
        }

        public List<Login> ReadLoginFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<Login> list = JsonConvert.DeserializeObject<List<Login>>(json);
            return list;

        }

        public List<AddCertifications> ReadCertificationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddCertifications> list = JsonConvert.DeserializeObject<List<AddCertifications>>(json);
            return list;

        }

        public List<AddCertificationInvalidInput> ReadCertificationInvalidInputFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddCertificationInvalidInput> list = JsonConvert.DeserializeObject<List<AddCertificationInvalidInput>>(json);
            return list;

        }

        public List<AddExistingCertification> ReadExistingCertificationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddExistingCertification> list = JsonConvert.DeserializeObject<List<AddExistingCertification>>(json);
            return list;

        }
        public List<AddExistingCertificationWithDifferentYear> ReadExistingCertificationWithDifferentYearFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddExistingCertificationWithDifferentYear> list = JsonConvert.DeserializeObject<List<AddExistingCertificationWithDifferentYear>>(json);
            return list;

        }

        public List<UpdateCertification> ReadUpdareCertificationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<UpdateCertification> list = JsonConvert.DeserializeObject<List<UpdateCertification>>(json);
            return list;

        }

       

        public List<DeleteCertification> ReadDeleteCertificationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<DeleteCertification> list = JsonConvert.DeserializeObject<List<DeleteCertification>>(json);
            return list;

        }

        public List<AddEducation> ReadAddEducationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddEducation> list = JsonConvert.DeserializeObject<List<AddEducation>>(json);
            return list;

        }

       public List<AddEducationInvalidInput> ReadEducationInvalidInputFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddEducationInvalidInput> list = JsonConvert.DeserializeObject<List<AddEducationInvalidInput>>(json);
           return list;

        }

        public List<AddExistingEducation> ReadAddExistingEducationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddExistingEducation> list = JsonConvert.DeserializeObject<List<AddExistingEducation>>(json);
            return list;

        }

        public List<AddExistingEducationwWithDifferentYear> ReadAddExistingEducationWithDifferentYearFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<AddExistingEducationwWithDifferentYear> list = JsonConvert.DeserializeObject<List<AddExistingEducationwWithDifferentYear>>(json);
           return list;

        }

        public List<UpdateEducation> ReadUpdateEducationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<UpdateEducation> list = JsonConvert.DeserializeObject<List<UpdateEducation>>(json);
            return list;

        }

        public List<DeleteEducation> ReadDeleteEducationFile()
        {
            using StreamReader reader = new(_sampleJsonFilePath);
            var json = reader.ReadToEnd();
            List<DeleteEducation> list = JsonConvert.DeserializeObject<List<DeleteEducation>>(json);
            return list;

        }

    }
}
