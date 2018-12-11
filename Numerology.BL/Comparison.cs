using System;
using System.Collections.Generic;
using System.Linq;

namespace Numerology.BL
{
    public class Comparison
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fathername { get; set; }
        public DateTime DOB { get; set; }
        public int LifeWayNumber { get; set; } // GetLifeWayNumberString //p.10
        public int SoulNumber { get; set; } // GetVowelsOfNameAndSurnameString //p.7
        public int PersonalityNumber { get; set; } // GetConsonantsOfNameAndSurnameString //p.8
        public int DestinyNumber { get; set; } // GetVowelsAndConsonantsOfNameAndSurnameString //p.9
        public int PowerNumber { get; set; } // GetVowelsAndConsonantsOfNameAndSurnameAndlifeWayNumberString //p.11
        public int EveryDayStabilityNumber { get; set; }
        public int SpiritualStabilityNumber { get; set; }
        public string Language { get; set; }
        public List<PeakObject> Peaks { get; set; }

        public int GetPeakByYear(int year)
        {
            var result = 0;

            if (Peaks != null && year > 0)
            {
                var peak = Peaks.FirstOrDefault(x => x.StartYear.Year <= year && x.EndYear.Year >= year);
                if (peak != null) result = peak.Peak;
            }
            return result;
        }
        public int GetBottomByYear(int year)
        {
            var result = 0;

            if (Peaks != null && year > 0)
            {
                var peak = Peaks.FirstOrDefault(x => x.StartYear.Year <= year && x.EndYear.Year >= year);
                if (peak != null) result = peak.Bottom;
            }
            return result;
        }
    }
}
