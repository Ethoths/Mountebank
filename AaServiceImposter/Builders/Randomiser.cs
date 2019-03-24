using System;
using System.Text;

namespace AaServiceImposter.Builders
{
    public static class Randomiser
    {
        private static readonly Random Ticks;

        private static readonly string[] AlphaNumerics = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

        static Randomiser()
        {
            Ticks = new Random((int)DateTime.Now.Ticks);
        }

        public static string CardNumber
        {
            get
            {
                var cardNumber = new StringBuilder();

                for (var i = 0; i < 16; i++)
                {
                    cardNumber.Append(Int(9));
                }

                return cardNumber.ToString();
            }
        }

        public static decimal Decimal
        {
            get { return (decimal)Int() / 100; }
        }

        public static decimal Mileage
        {
            get { return (decimal)Int(9999, 1) / 10; }
        }

        public static decimal EndMileage(decimal startMilage)
        {
            return startMilage + Mileage;
        }

        public static string String
        {
            get { return Guid.NewGuid().ToString(); }
        }

        public static string FixedString(int length)
        {
            var fixedStringStringBuilder = new StringBuilder();

            for (var i = 0; i < length; i++)
            {
                fixedStringStringBuilder.Append(AlphaNumerics[Ticks.Next(AlphaNumerics.Length)]);
            }

            return fixedStringStringBuilder.ToString();
        }

        public static string ShortString(int length)
        {
            length = length > 20 ? 20 : length;

            return String.Replace("-", string.Empty).Substring(0, length);
        }

        public static int Int(int maxValue = int.MaxValue, int minValue = 0)
        {
            return Ticks.Next(minValue, maxValue);
        }

        public static string Long
        {
            get { return Int().ToString() + Int(); }
        }

        public static string EmailAddress
        {
            get { return string.Format("{0}@{1}.com", ShortString(20), ShortString(20)); }
        }

        public static DateTime Date
        {
            get { return DateTime.Now; }
        }

        public static DateTime PastDate
        {
            get { return Date.AddDays(-Int(28)); }
        }

        public static DateTime PastDateAfter(DateTime afterDate)
        {
            var maxDays = (DateTime.Now - afterDate).Days;

            return Date.AddDays(-Int(maxDays));
        }

        public static DateTime FutureDate
        {
            get { return Date.AddDays(Int(28)); }
        }

        public static string LandlineNumber
        {
            get { return "01" + Ticks.Next(0, 999999999).ToString("000000000"); }
        }

        public static string MobileNumber
        {
            get { return "07" + Ticks.Next(0, 999999999).ToString("000000000"); }
        }

        public static string RegistrationNo
        {
            get { return FixedString(2).ToUpper() + Int(9) + Int(9) + " " + FixedString(3).ToUpper(); }
        }
        
        public static DateTime MonthStartDate(MonthOrdinal monthOrdinal)
        {
            var now = DateTime.Now;
            var month = now.AddMonths((int)monthOrdinal).Month;
            var year = now.AddYears((int)monthOrdinal / 12).Year;

            return new DateTime(year, month, 1);
        }

        public static DateTime MonthEndDate(MonthOrdinal monthOrdinal)
        {
            var now = DateTime.Now;
            var month = now.AddMonths((int)monthOrdinal).Month;
            var year = now.AddYears((int)monthOrdinal / 12).Year;

            return new DateTime(year, month + 1, 1).AddDays(-1);
        }

        public enum MonthOrdinal
        {
            Ancient = -120,
            VeryOld = -24,
            Old = -12,
            Retrospective = -3,
            Past = -1,
            Current = 0,
            Future = 1,
            NextYear = 12,
            SomeYears = 24,
            Eons = 120
        }
    }
}
