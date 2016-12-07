using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateDifference.Models
{
    public class Date
    {
        private static List<int> cumDays = new List<int> { 0, 31, 59, 90, 120, 151, 181, 212, 243, 273, 304, 334 }; //cumulative Days by month
        private static List<int> leapcumDays = new List<int> { 0, 31, 60, 91, 121, 152, 182, 213, 244, 274, 305, 335 }; // Cumulative Days by month for leap year

        /// <summary>
        /// This will take a string and set props.
        /// </summary>
        /// <param name="input">YYYY-MM-dd</param>
        public Date(string input)
        {
            var dateParts = input.Split('-');
            Day = int.Parse(dateParts[2]);
            Month = int.Parse(dateParts[1]);
            Year = int.Parse(dateParts[0]);
        }
        
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public static int operator -(Date date1, Date date2)
        {
            var orderCorrect = IsCorrectOrder(date2, date1);
            if (!orderCorrect)
            {
                var oldDateA = date2;
                var oldDateB = date1;
                date2 = oldDateB;
                date1 = oldDateA;
            }
            var totalDays = 0;
            if (date2.Year == date1.Year)
            {
                if (IsLeapYear(date2.Year))
                {
                    totalDays = (leapcumDays[date1.Month - 1] + date1.Day) - (leapcumDays[date2.Month - 1] + date2.Day);
                }
                else
                {
                    totalDays = (cumDays[date1.Month - 1] + date1.Day) - (cumDays[date2.Month - 1] + date2.Day);
                }
                return CorrectSubtractionSign(orderCorrect, totalDays);
            }

            if (IsLeapYear(date2.Year))
            {
                totalDays += 366 - (leapcumDays[date2.Month - 1] + date2.Day);
            }
            else
            {
                totalDays += 365 - (cumDays[date2.Month - 1] + date2.Day);
            }

            var year = date2.Year + 1;
            while (year < date1.Year)
            {
                if (IsLeapYear(year))
                {
                    totalDays += 366;
                }
                else
                {
                    totalDays += 365;
                }
                year++;
            }

            if (IsLeapYear(date1.Year))
            {
                totalDays += (leapcumDays[date1.Month - 1] + date1.Day);
            }
            else
            {
                totalDays += (cumDays[date1.Month - 1] + date1.Day);
            }

            return CorrectSubtractionSign(orderCorrect, totalDays);
        }

        private static int CorrectSubtractionSign(bool correctOrder, int total)
        {
            total = Math.Abs(total);
            if (!correctOrder)
            {
                total *= -1;
            }
            return total;
        }

        private static bool IsCorrectOrder(Date dateA, Date dateB)
        {
            if(dateA.Year != dateB.Year)
            {
                return dateB.Year > dateA.Year;
            }

            if(dateA.Month != dateB.Month)
            {
                return dateB.Month > dateA.Month;
            }

            return dateB.Day > dateA.Day;
        }

        private static bool IsLeapYear(int year)
        {
            if (year % 4 > 0) { return false; }
            if (year % 100 > 0) { return true; }
            if (year % 400 > 0) { return false; }
            return true;
        }
    }
}
