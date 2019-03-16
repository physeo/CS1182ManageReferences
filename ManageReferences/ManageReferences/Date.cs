//------------------------------------------------------------------
// Date Class
// Written by Bryce Graham
// CS 1182
// Store and format information for a given date
//------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageReferences
{
    [Serializable]
    class Date
    {
        private int day;
        private int month;
        private int year;

        //------------------------------------------------------------------
        // Constructors
        //------------------------------------------------------------------

        public Date()
        {
            Month = 0;
            Day = 0;
            Year = 0;
        }

        public Date(int _year, int _month, int _day)
        {
            setDate(_year, _month, _day);
        }

        public Date(int _year, int _month)
        {
            setDate(_year, _month, 0);
        }

        public Date(int _year)
        {
            setDate(_year, 0, 0);

        }

        //------------------------------------------------------------------
        // Properties
        //------------------------------------------------------------------

        //------------------------------------------------------------------
        // Returns the day and allows it to be privately set as long as
        // the validDay methos is satisfied. If the month is 0 the day
        // will also be set to 0
        //------------------------------------------------------------------
        public int Day
        {
            get { return day; }
            private set
            {
                if (validDay(value))
                {
                    day = value;
                }
                if (Month == 0)
                {
                    day = 0;
                }
            }
        }

        //--------------------------------------------------------------------------------
        // Returns the month and allows it to be privately set as long as the validMonth
        // method is satisfied. If the year is 0 the month will be set to 0.
        //--------------------------------------------------------------------------------
        public int Month
        {
            get { return month; }
            private set
            {
                if (validMonth(value))
                {
                    month = value;
                }
                if (year == 0)
                {
                    month = 0;
                }
            }
        }

        //-----------------------------------------------------------------------------
        // Returns the year and allows it to be privately set as long as the
        // validYear method is satisfied otherwise it will be set to the current year
        //-----------------------------------------------------------------------------
        public int Year
        {
            get { return year; }
            private set
            {
                if (validYear(value))
                {
                    year = value;
                }
                else
                {
                    year = DateTime.Today.Year;
                }
            }
        }

        //------------------------------------------------------------------
        // Public method to allow setting of date
        //------------------------------------------------------------------
        public void setDate(int _year, int _month, int _day)
        {
            Year = _year;
            Month = _month;
            Day = _day;


        }

        //------------------------------------------------------------------
        // Validation methods
        //------------------------------------------------------------------

        //-----------------------------------------------------------------------------------
        // Day must adhere to calender rules including different size months and leap years
        // in order to be considered valid.
        //-----------------------------------------------------------------------------------
        private bool validDay(int _day)
        {
            bool valid = false;

            if (Month == 4 || Month == 6 || Month == 9 || Month == 11)
            {
                if (_day >= 0 && _day <= 30)
                {
                    valid = true;
                }
            }
            else if (Month == 2)
            {
                if (leapYear())
                {
                    if (_day >= 0 && _day <= 29)
                    {
                        valid = true;
                    }
                }
                else
                {
                    if (_day >= 0 && _day <= 28)
                    {
                        valid = true;
                    }
                }
            }
            else
            {
                if (_day >= 0 && _day <= 31)
                {
                    valid = true;
                }
            }

            return valid;
        }

        //------------------------------------------------------------------
        // Month must not be less than 0 or greater than 12
        //------------------------------------------------------------------
        private bool validMonth(int _month)
        {
            bool valid = false;

            if (_month >= 0 && _month <= 12)
            {
                valid = true;
            }

            return valid;
        }

        //------------------------------------------------------------------
        // Year must be in ccyy between 1700 and 9999
        //------------------------------------------------------------------
        private bool validYear(int _year)
        {
            bool valid = false;

            if (_year >= 1700 && _year <= 9999)
            {
                valid = true;
            }

            return valid;
        }

        //------------------------------------------------------------------
        // Determine if the year is a leap year
        //------------------------------------------------------------------
        private bool leapYear()
        {
            bool isLeapYear = false;

            if (year % 4 == 0)
            {
                isLeapYear = true;

                if (year % 100 == 0 && year % 400 != 0)
                {
                    isLeapYear = false;
                }
            }

            return isLeapYear;
        }

        //------------------------------------------------------------------
        // Formatter methods
        //------------------------------------------------------------------

        //------------------------------------------------------------------
        // Format input to "mm/dd/ccyy"
        //------------------------------------------------------------------
        public string monthSlashDaySlashYear()
        {
            string dateFormat = null;

            if (day == 0 && month == 0)
            {
                dateFormat = year.ToString();
            }
            else if (day == 0)
            {
                dateFormat = month + "/" + year;
            }
            else
            {
                dateFormat = month + "/" + day + "/" + year;
            }

            return dateFormat;
        }

        //------------------------------------------------------------------
        // Format input to "Month dd, ccyy"
        //------------------------------------------------------------------
        public string monthDayCommaYear()
        {
            string dateFormat = null;

            if (day == 0 && month == 0)
            {
                dateFormat = monthSlashDaySlashYear();
            }
            else if (day == 0)
            {
                dateFormat = findMonthName(month) + ", " + year;
            }
            else
            {
                dateFormat = findMonthName(month) + " " + day + ", " + year;
            }


            return dateFormat;
        }

        //------------------------------------------------------------------
        // Convert the month number into the month name
        //------------------------------------------------------------------
        private string findMonthName(int monthNumber)
        {
            string monthName = null;

            switch (monthNumber)
            {
                case 1:
                    monthName = "January";
                    break;
                case 2:
                    monthName = "February";
                    break;
                case 3:
                    monthName = "March";
                    break;
                case 4:
                    monthName = "April";
                    break;
                case 5:
                    monthName = "May";
                    break;
                case 6:
                    monthName = "June";
                    break;
                case 7:
                    monthName = "July";
                    break;
                case 8:
                    monthName = "August";
                    break;
                case 9:
                    monthName = "September";
                    break;
                case 10:
                    monthName = "October";
                    break;
                case 11:
                    monthName = "November";
                    break;
                case 12:
                    monthName = "December";
                    break;
            }

            return monthName;
        }

    }
}
