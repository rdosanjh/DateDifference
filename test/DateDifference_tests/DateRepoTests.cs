using DateDifference;
using DateDifference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DateDifference_tests
{
    public class DateRepoTests
    {
        [Fact]
        public void Dates_Within_same_month_and_year()
        {
            var result =  new Date("2010-10-30") - new Date("2010-10-20");
            Assert.Equal(10, result);
        }

        [Fact]
        public void Dates_on_either_side_of_a_month()
        {
            var result = new Date("2010-11-01") - new Date("2010-10-30");
            Assert.Equal(2, result);
        }

        [Fact]
        public void First_date_after_second_date()
        {
            var result = new Date("2010-10-20") - new Date("2010-10-30");
            Assert.Equal(-10, result);
        }

        [Fact]
        public void Dates_in_diffrent_years()
        {
            var result = new Date("2010-10-20") - new Date("2009-10-30");
            Assert.Equal(355, result);
        }

        [Fact]
        public void Dates_in_diffrent_years_backwards()
        {
            var result = new Date("2010-10-20") - new Date("2009-10-30");
            Assert.Equal(355, result);
        }

        [Fact]
        public void In_leap_year_feb_has_extra_day()
        {
            var result = new Date("2016-3-1") - new Date("2016-2-28");
            Assert.Equal(2, result);
        }
    }
}
