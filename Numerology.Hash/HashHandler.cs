using System;
using System.Text;

namespace Numerology.Hash
{
    public class HashHandler
    {
        private short maxLength = 25;
        private static Random random = new Random();
        public string ConvertFromStartEnd(DateTime startInterval, DateTime endInterval)
        {
            var start = FixLength(DateTimeToUnixTimestamp(startInterval), maxLength);
            var end = FixLength(DateTimeToUnixTimestamp(endInterval), maxLength);

            return Convert.ToBase64String(Encoding.ASCII.GetBytes(start + end));
        }
        public HashHandlerIntervals ConvertFromHash(string hash)
        {
            try
            {
                var fromBase64 = Convert.FromBase64String(hash);
                var ascii = Encoding.ASCII.GetString(fromBase64);

                var start = ascii.Substring(0, maxLength);
                var end = ascii.Substring(maxLength, maxLength);

                var startUnixLength = Int32.Parse(start.Substring(start.Length - 2, 2));
                var endUnixLength = Int32.Parse(end.Substring(end.Length - 2, 2));

                var startUnix = start.Substring(0, startUnixLength);
                var endUnix = end.Substring(0, endUnixLength);

                var result = new HashHandlerIntervals();

                DateTime dtStart = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                result.Start = dtStart.AddSeconds(Double.Parse(startUnix)).ToLocalTime();

                DateTime dtEnd = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                result.End = dtEnd.AddSeconds(Double.Parse(endUnix)).ToLocalTime();

                return result;
            }
            catch { return null; }
        }
        private string DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
                     new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds.ToString();
        }
        private string FixLength(string source, short maxLength)
        {
            var loops = maxLength - 2 - source.Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < loops; i++)
            {
                var value = RandomNumber(0, 10);
                sb.Append(value);
            }

            return source + sb.ToString() + AdjustUnixLength(source.Length);
        }
        private string AdjustUnixLength(int source)
        {
            return (source < 10) ? "0" + source.ToString() : source.ToString();
        }
        public int RandomNumber(short min, short max)
        {
            return random.Next(min, max);
        }
        public string Encode(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            StringBuilder sb = new StringBuilder();
            var chars = input.ToCharArray();
            var next = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (i > 0) sb.Append("|");
                next = (byte)chars[i] + 1;
                sb.Append(next.ToString());
            }
            return Convert.ToBase64String(Encoding.ASCII.GetBytes(sb.ToString()));
        }
        public string Decode(string input)
        {
            if (string.IsNullOrEmpty(input)) return null;

            try
            {
                var fromBase64 = Convert.FromBase64String(input);
                var ascii = Encoding.ASCII.GetString(fromBase64);
                var splitted = ascii.Split('|');

                StringBuilder sb = new StringBuilder();
                var prev = 0;
                for (int i = 0; i < splitted.Length; i++)
                {
                    prev = Byte.Parse(splitted[i]) - 1;
                    sb.Append((char)prev);
                }
                return sb.ToString();
            }
            catch { return null; }
        }
    }
    public class HashHandlerIntervals
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public HashHandlerIntervals(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
        public HashHandlerIntervals()
        {

        }
    }
}
