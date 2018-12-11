using System;

namespace Numerology.BL
{
    public class PeakObject
    {
        public int Index { get; set; }
        public DateTime StartYear { get; set; }
        public DateTime EndYear { get; set; }
        public int Age { get; set; }
        public int Peak { get; set; }
        public bool IsPeakMaster { get; set; }
        public int PeakMaster { get; set; }
        public int Bottom { get; set; }
    }
}
