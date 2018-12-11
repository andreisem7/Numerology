using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Numerology.BL
{
    public class NumerologyObject
    {
        public DateOfBirthObject DOBObject { get; set; }
        public NameSurnameManager NameObject { get; set; }

        public NumerologyObject()
        {
            DOBObject = new DateOfBirthObject();
            NameObject = new NameSurnameManager();
        }

        public bool SavePersonalData(string pathToSave, out string message)
        {
            message = string.Empty;

            if (string.IsNullOrEmpty(NameObject.GetNameRaw.Trim()) ||
                string.IsNullOrEmpty(NameObject.GetSurnameRaw.Trim()))
            {
                message = "Can't save without name and surname!";
                return false;
            }

            if (string.IsNullOrEmpty(NameObject.GetLifeWayNumberString) ||
                string.IsNullOrEmpty(NameObject.GetVowelsOfNameAndSurnameString) ||
                string.IsNullOrEmpty(NameObject.GetConsonantsOfNameAndSurnameString) ||
                string.IsNullOrEmpty(NameObject.GetVowelsAndConsonantsOfNameAndSurnameString) ||
                string.IsNullOrEmpty(NameObject.GetVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberString))
            {
                message = "Important personal numbers are not initialized. operation aborted!";
                return false;
            }

            var comparisonObject = new Comparison();

            comparisonObject.Language = NameObject.GetLanguageString;

            comparisonObject.Name = NameObject.GetNameRaw;
            comparisonObject.Surname = NameObject.GetSurnameRaw;
            comparisonObject.Fathername = NameObject.GetfathersnameRaw;

            comparisonObject.DOB = DOBObject.DOB;

            comparisonObject.LifeWayNumber = int.Parse(NameObject.GetLifeWayNumberString);
            comparisonObject.SoulNumber = int.Parse(NameObject.GetVowelsOfNameAndSurnameString);
            comparisonObject.PersonalityNumber = int.Parse(NameObject.GetConsonantsOfNameAndSurnameString);
            comparisonObject.DestinyNumber = int.Parse(NameObject.GetVowelsAndConsonantsOfNameAndSurnameString);
            comparisonObject.PowerNumber = int.Parse(NameObject.GetVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberString);
            comparisonObject.Peaks = DOBObject.Peaks;
            comparisonObject.EveryDayStabilityNumber = DOBObject.GetEveryDayStabilityNumber;
            comparisonObject.SpiritualStabilityNumber = DOBObject.GetSpiritualStabilityNumber;

            var fileName = GetFileName(comparisonObject);
            using (var writer = new System.IO.StreamWriter(Path.Combine(pathToSave, fileName)))
            {
                var serializer = new XmlSerializer(typeof(Comparison), new[] { typeof(List<PeakObject>), typeof(PeakObject) });
                serializer.Serialize(writer, comparisonObject);
                writer.Flush();
            }

            return true;
        }

        public Comparison ReadPersonalData(string pathToFile)
        {
            Comparison comparisonObject = null;
            using (var reader = new System.IO.StreamReader(pathToFile))
            {
                var serializer = new XmlSerializer(typeof(Comparison), new[] { typeof(List<PeakObject>), typeof(PeakObject) });
                comparisonObject = (Comparison)serializer.Deserialize(reader);
            }
            return comparisonObject;
        }

        private string GetFileName(Comparison comparisonObject)
        {
            return comparisonObject.Name + "_" + comparisonObject.Surname + (!string.IsNullOrEmpty(comparisonObject.Fathername) ? "_" + comparisonObject.Fathername : "") + ".xml";
        }
    }
}
