namespace Numerology.UI
{
    public class TagObject
    {
        public int SourceDayNumber { get; set; }
        public int SourceMonthNumber { get; set; }
        public string SourceMonthName { get; set; }
        public int TargetMonthNumber { get; set; }
        public string TargetMonthName { get; set; }
        public int TargetYear { get; set; }
        public int MonthSimple { get; set; }
        public int MonthExtended { get; set; }
        public TagObject(int sourceDayNumber, int sourceMonthNumber, string sourceMonthName, int targetMonthNumber, string targetMonthName, int targetYear, int monthSimple, int monthExtended)
        {
            SourceDayNumber = sourceDayNumber;
            SourceMonthNumber = sourceMonthNumber;
            SourceMonthName = sourceMonthName;
            TargetMonthNumber = targetMonthNumber;
            TargetMonthName = targetMonthName;
            TargetYear = targetYear;
            MonthSimple = monthSimple;
            MonthExtended = monthExtended;
        }
    }
}
