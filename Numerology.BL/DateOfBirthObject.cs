using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Numerology.BL
{
    public class DateOfBirthObject
    {
        private bool isMasterNumberDOB = false;
        private int masterNumberDOB = 0;
        private int lifeWayNumber = 0;
        private int dobSum = 0;
        private int dobSumSubstructed = 0;
        private int dobSumSubstructedSimplified = 0;
        private int everyDayStabilityNumber = 0;
        private int spiritualStabilityNumber = 0;
        private const int DOB_SUM_SUBSTRUCT_CONST = 2;

        private const int PEAK_YEAR_CONST = 36;

        public DateTime DOB { get; set; }

        /// <summary>
        /// Readonly Day
        /// </summary>
        public int GetDay
        {
            get { return DOB.Day; }
        }

        /// <summary>
        /// Readonly Day string
        /// </summary>
        public string GetDayString
        {
            get { return GetString(DOB.Day, 2); }
        }
        /// <summary>
        /// Readonly Month
        /// </summary>
        public int GetMonth
        {
            get { return DOB.Month; }
        }
        /// <summary>
        /// Readonly Month string
        /// </summary>
        public string GetMonthString
        {
            get { return GetString(DOB.Month, 2); }
        }
        /// <summary>
        /// Readonly Year
        /// </summary>
        public int GetYear
        {
            get { return DOB.Year; }
        }
        /// <summary>
        /// Readonly Year string
        /// </summary>
        public string GetYearString
        {
            get { return GetString(DOB.Year, 4); }
        }
        public string GetDOBSumString
        {
            get { return dobSum.ToString(); }
        }
        public string GetMasterNumberDOBString
        {
            get { return masterNumberDOB.ToString(); }
        }
        public bool IsMasterNumberDOB
        {
            get { return isMasterNumberDOB; }
        }
        public string GetLifeWayNumberString
        {
            get { return lifeWayNumber.ToString(); }
        }
        public int GetLifeWayNumber
        {
            get { return lifeWayNumber; }
        }
        public int GetEveryDayStabilityNumber
        {
            get { return everyDayStabilityNumber; }
        }
        public int GetSpiritualStabilityNumber
        {
            get { return spiritualStabilityNumber; }
        }
        public string GetDOBSumSubstructedString
        {
            get { return dobSumSubstructed.ToString(); }
        }
        public string GetDOBSumSubstructedSimplifiedString
        {
            get { return dobSumSubstructedSimplified.ToString(); }
        }
        public Matrix DOBMatrix { get; set; }
        public List<PeakObject> Peaks { get; set; }
        public void SetDateOfBirth(int day, int month, int year)
        {
            try
            {
                DOB = new DateTime(year, month, day);
                dobSum = GetDOBSum(GetDayString, GetMonthString, GetYearString);
                lifeWayNumber = GetLifeWayNumberMethod(GetDayString, GetMonthString, GetYearString, out isMasterNumberDOB, out masterNumberDOB);
                dobSumSubstructed = GetDOBSumSubstructed(GetDayString, GetMonthString, GetYearString);
                dobSumSubstructedSimplified = int.Parse(NarrowToOneNumber(dobSumSubstructed.ToString(), out _, out _));

                InitMatrix();
                InitPeaks();
            }
            catch
            {
                throw new ArgumentOutOfRangeException("Impossible combination of day, month, year.");
            }
        }
        private void InitMatrix()
        {
            var input = GetDayString +
                GetMonthString +
                GetYearString +
                dobSum +
                lifeWayNumber.ToString() +
                dobSumSubstructed.ToString() +
                dobSumSubstructedSimplified.ToString();

            DOBMatrix = new Matrix();
            for (int i = 0; i < Matrix.Capacity; i++)
            {
                var count = CountNumber(input, (i + 1).ToString());
                DOBMatrix.AddCell(i + 1, i + 1, count);
            }

            everyDayStabilityNumber = DOBMatrix.GetEdgeValue(Matrix.Edge.DiagonalLeftBottomToRightTop) * DOBMatrix.GetEdgeValue(Matrix.Edge.Horizontal3) * DOBMatrix.GetEdgeValue(Matrix.Edge.Horizontal2);
            spiritualStabilityNumber = DOBMatrix.GetEdgeValue(Matrix.Edge.DiagonalLeftTopToRightBottom) * DOBMatrix.GetEdgeValue(Matrix.Edge.Vertical1) * DOBMatrix.GetEdgeValue(Matrix.Edge.Horizontal1);
        }
        private void InitPeaks()
        {
            Peaks = new List<PeakObject>(4);

            var peak1 = new PeakObject();
            peak1.Index = 1;
            var isMasterNumberPeakPlus_1 = false;
            var masterNumberPeakPlus_1 = 0;
            peak1.Peak = int.Parse(NarrowToOneNumber(GetDayString + GetMonthString, out isMasterNumberPeakPlus_1, out masterNumberPeakPlus_1));
            peak1.IsPeakMaster = isMasterNumberPeakPlus_1;
            peak1.PeakMaster = masterNumberPeakPlus_1;
            peak1.Bottom = Math.Abs(int.Parse(NarrowToOneNumber(DOB.Day.ToString(), out _, out _)) -
                int.Parse(NarrowToOneNumber(DOB.Month.ToString(), out _, out _)));
            peak1.StartYear = DOB;
            peak1.EndYear = new DateTime(DOB.Year + (PEAK_YEAR_CONST - lifeWayNumber), 1, 1);
            peak1.Age = PEAK_YEAR_CONST - lifeWayNumber;

            Peaks.Add(peak1);

            var peak2 = new PeakObject();
            peak2.Index = 2;
            var isMasterNumberPeakPlus_2 = false;
            var masterNumberPeakPlus_2 = 0;
            peak2.Peak = int.Parse(NarrowToOneNumber(GetDayString + GetYearString, out isMasterNumberPeakPlus_2, out masterNumberPeakPlus_2));
            peak2.IsPeakMaster = isMasterNumberPeakPlus_2;
            peak2.PeakMaster = masterNumberPeakPlus_2;
            peak2.Bottom = Math.Abs(int.Parse(NarrowToOneNumber(DOB.Day.ToString(), out _, out _)) -
                int.Parse(NarrowToOneNumber(DOB.Year.ToString(), out _, out _)));
            peak2.StartYear = peak1.EndYear.AddYears(1);
            peak2.EndYear = peak1.EndYear.AddYears(9);
            peak2.Age = peak1.Age + 9;

            Peaks.Add(peak2);

            var peak3 = new PeakObject();
            peak3.Index = 3;
            var isMasterNumberPeakPlus_3 = false;
            var masterNumberPeakPlus_3 = 0;
            peak3.Peak = int.Parse(NarrowToOneNumber(GetDayString + GetMonthString + GetDayString + GetYearString, out isMasterNumberPeakPlus_3, out masterNumberPeakPlus_3));
            peak3.IsPeakMaster = isMasterNumberPeakPlus_3;
            peak3.PeakMaster = masterNumberPeakPlus_3;
            peak3.Bottom = Math.Abs(Math.Abs(int.Parse(NarrowToOneNumber(DOB.Day.ToString(), out _, out _)) -
                int.Parse(NarrowToOneNumber(DOB.Month.ToString(), out _, out _))) -
                Math.Abs(int.Parse(NarrowToOneNumber(DOB.Day.ToString(), out _, out _)) -
                int.Parse(NarrowToOneNumber(DOB.Year.ToString(), out _, out _))));
            peak3.StartYear = peak2.EndYear.AddYears(1);
            peak3.EndYear = peak2.EndYear.AddYears(9);
            peak3.Age = peak2.Age + 9;

            Peaks.Add(peak3);

            var peak4 = new PeakObject();
            peak4.Index = 4;
            var isMasterNumberPeakPlus_4 = false;
            var masterNumberPeakPlus_4 = 0;
            peak4.Peak = int.Parse(NarrowToOneNumber(GetMonthString + GetYearString, out isMasterNumberPeakPlus_4, out masterNumberPeakPlus_4));
            peak4.IsPeakMaster = isMasterNumberPeakPlus_4;
            peak4.PeakMaster = masterNumberPeakPlus_4;
            peak4.Bottom = Math.Abs(int.Parse(NarrowToOneNumber(DOB.Month.ToString(), out _, out _)) - int.Parse(NarrowToOneNumber(DOB.Year.ToString(), out _, out _)));
            peak4.StartYear = peak3.EndYear.AddYears(1);
            peak4.EndYear = peak3.EndYear.AddYears(100);
            peak4.Age = peak3.Age + 100;

            Peaks.Add(peak4);
        }
        private int CountNumber(string input, string sample)
        {
            return input.Count(x => x.ToString() == sample);
        }
        private int GetDOBSum(string day, string month, string year)
        {
            return int.Parse(SimplifyString(day + month + year, out _, out _));
        }
        private int GetDOBSumSubstructed(string day, string month, string year)
        {
            int dayFirstDigit = int.Parse(day.Substring(0, 1));
            return (int.Parse(SimplifyString(day + month + year, out _, out _)) - (DOB_SUM_SUBSTRUCT_CONST * dayFirstDigit));
        }
        private int GetLifeWayNumberMethod(string day, string month, string year, out bool isMaster, out int masterNumber)
        {
            isMaster = false;
            masterNumber = 0;
            return int.Parse(NarrowToOneNumber(day + month + year, out isMaster, out masterNumber));
        }
        private string NarrowToOneNumber(string input, out bool isMaster, out int masterNumber)
        {
            string result = input;
            isMaster = false;
            masterNumber = 0;
            var isMasterLocal = false;
            var masterNumberLocal = 0;
            while (result.Length > 1)
            {
                result = SimplifyString(result, out isMasterLocal, out masterNumberLocal);
                if (!isMaster)
                {
                    isMaster = isMasterLocal;
                    masterNumber = masterNumberLocal;
                }
            }
            return result;
        }
        private string SimplifyString(string input, out bool isMaster, out int masterNumber)
        {
            isMaster = false;
            masterNumber = 0;
            if (input.Length == 1) return input;

            int result = 0;
            char[] splitted = input.ToCharArray();
            for (int i = 0; i < splitted.Length; i++)
            {
                result += int.Parse(splitted[i].ToString());
            }
            if (result == 11 || result == 22 || result == 33)
            {
                isMaster = true;
                masterNumber = result;
            }
            return result.ToString();
        }
        private string GetString(int value, int stringLength)
        {
            string strValue = value.ToString();
            if (strValue.Length < stringLength)
            {
                return (Zeros(stringLength - strValue.Length) + strValue);
            }
            return strValue;
        }

        private string Zeros(int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++) sb.Append('0');

            return sb.ToString();
        }
    }
}
