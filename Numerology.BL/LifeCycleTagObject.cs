namespace Numerology.BL
{
    public class LifeCycleTagObject
    {
        public int LifeWayNumber { get; set; }
        public int PeriodFloor { get; set; }
        public int PeriodCeiling { get; set; }
        public int Cycle { get; set; }
        public int Number { get; set; }
        public bool IsMaster { get; set; }
        public bool IsSelected { get; set; }

        public LifeCycleTagObject(
            int lifeWayNumber,
            int periodFloor,
            int periodCeiling,
            int cycle,
            int number,
            bool isMaster)
        {
            LifeWayNumber = lifeWayNumber;
            PeriodFloor = periodFloor;
            PeriodCeiling = periodCeiling;
            Cycle = cycle;
            Number = number;
            IsMaster = isMaster;
        }
    }
}
