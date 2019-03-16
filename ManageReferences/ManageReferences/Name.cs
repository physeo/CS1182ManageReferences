//---------------------------------------------------------------------
// Name Class
// Written by Bryce Graham
// CS 1182
// Store name data and transform it into several different formats
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageReferences
{
    [Serializable]
    class Name : IComparable
    {
        private string firstName;
        private string middleInitial;
        private string lastName;

        //------------------------------------------------------------------
        // Constructors
        //------------------------------------------------------------------

        public Name()
        {
            FirstName = "";
            MiddleInitial = "";
            LastName = "";
        }

        public Name(string _firstName, string _middleInitial, string _lastName)
        {
            FirstName = _firstName;
            MiddleInitial = _middleInitial;
            LastName = _lastName;
        }

        public Name(string _firstName, string _lastName)
        {
            FirstName = _firstName;
            MiddleInitial = "";
            LastName = _lastName;
        }

        //------------------------------------------------------------------
        // Properties
        //------------------------------------------------------------------

        //------------------------------------------------------------------
        // Returns the first name and allows it to be set
        // as long as the validName method is satisfied.
        // Otherwise it is set to an empty string
        //------------------------------------------------------------------
        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (validName(value))
                {
                    firstName = value.Trim();
                }
                else
                {
                    firstName = "";
                }

            }
        }

        //------------------------------------------------------------------
        // Returns the middle initial and allows it to be set if
        // it follows the Regular expression for a single capital or
        // lowercase letter. Otherwise it is set to an empty string.
        //------------------------------------------------------------------
        public string MiddleInitial
        {
            get { return middleInitial; }
            set
            {

                if (System.Text.RegularExpressions.Regex.IsMatch(value, "^[A-Za-z{1}]$"))
                {
                    middleInitial = value;
                }
                else
                {
                    middleInitial = "";
                }

            }
        }

        //------------------------------------------------------------------
        // Returns the last name and allows it to be set as long as it
        // satisfies the validName method. Otherwise it is set as
        // an empty string.
        //------------------------------------------------------------------
        public string LastName
        {
            get { return lastName; }
            set
            {
                if (validName(value))
                {
                    lastName = value.Trim();
                }
                else
                {
                    lastName = "";
                }

            }
        }

        //--------------------------------------------------------------------------------------------------------
        // Validation Method
        // Requires a name to be comprised of any capital or lowercase letter, dashes, spaces or apostrophes
        //--------------------------------------------------------------------------------------------------------
        private bool validName(string testName)
        {
            bool valid;

            valid = System.Text.RegularExpressions.Regex.IsMatch(testName, "^[a-zA-Z '-]");

            return valid;
        }

        //------------------------------------------------------------------
        // Formatting methods
        //------------------------------------------------------------------

        //------------------------------------------------------------------
        // Formants the name as: F.M. Last
        //------------------------------------------------------------------
        public string initialsPeriodsLastName()
        {
            string nameFormat = null;

            if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(MiddleInitial) && string.IsNullOrEmpty(LastName))
            {
                nameFormat = "";
            }
            else if (string.IsNullOrEmpty(MiddleInitial))
            {
                nameFormat = getFirstInitial() + ". " + lastName;
            }
            else
            {
                nameFormat = getFirstInitial() + ". " + middleInitial + ". " + lastName;
            }

            return nameFormat;
        }

        //------------------------------------------------------------------
        // Formants the name as: F M Last
        //------------------------------------------------------------------
        public string initialsSpacesLastName()
        {
            string nameFormat = null;

            if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(MiddleInitial) && string.IsNullOrEmpty(LastName))
            {
                nameFormat = "";
            }
            else if (string.IsNullOrEmpty(MiddleInitial))
            {
                nameFormat = getFirstInitial() + " " + lastName;
            }
            else
            {
                nameFormat = getFirstInitial() + " " + middleInitial + " " + lastName;
            }

            return nameFormat;
        }

        //------------------------------------------------------------------
        // Formants the name as: First M Last
        //------------------------------------------------------------------
        public string firstMiLast()
        {
            string nameFormat = null;

            if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(MiddleInitial) && string.IsNullOrEmpty(LastName))
            {
                nameFormat = "";
            }
            else if (string.IsNullOrEmpty(MiddleInitial))
            {
                nameFormat = firstName + " " + lastName;
            }
            else
            {
                nameFormat = firstName + " " + middleInitial + " " + lastName;
            }

            return nameFormat;
        }

        //------------------------------------------------------------------
        // Formants the name as: First M. Last
        //------------------------------------------------------------------
        public string firstMiPeriodLast()
        {
            string nameFormat = null;

            if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(MiddleInitial) && string.IsNullOrEmpty(LastName))
            {
                nameFormat = "";
            }
            else if (string.IsNullOrEmpty(MiddleInitial))
            {
                nameFormat = firstName + " " + lastName;
            }
            else
            {
                nameFormat = firstName + " " + middleInitial + ". " + lastName;
            }

            return nameFormat;
        }

        //------------------------------------------------------------------
        // Formants the name as: Last, F.M.
        //------------------------------------------------------------------
        public string lastCommaInitialsPeriods()
        {
            string nameFormat = null;

            if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(MiddleInitial) && string.IsNullOrEmpty(LastName))
            {
                nameFormat = "";
            }
            else if (string.IsNullOrEmpty(MiddleInitial))
            {
                nameFormat = lastName + ", " + getFirstInitial() + ".";
            }
            else
            {
                nameFormat = lastName + ", " + getFirstInitial() + ". " + middleInitial + ".";
            }

            return nameFormat;
        }

        //------------------------------------------------------------------
        // Formants the name as: Last, First M.
        //------------------------------------------------------------------
        public string lastCommaFirstMiPeriod()
        {
            string nameFormat = null;

            if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(MiddleInitial) && string.IsNullOrEmpty(LastName))
            {
                nameFormat = "";
            }
            else if (string.IsNullOrEmpty(MiddleInitial))
            {
                nameFormat = lastName + ", " + firstName;
            }
            else
            {
                nameFormat = lastName + ", " + firstName + " " + middleInitial + ".";
            }

            return nameFormat;
        }

        //------------------------------------------------------------------
        // Formats the name as: Last FM
        //------------------------------------------------------------------
        public string lastSpaceInitials()
        {
            string nameFormat = null;

            if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(MiddleInitial) && string.IsNullOrEmpty(LastName))
            {
                nameFormat = "";
            }
            else if (string.IsNullOrEmpty(MiddleInitial))
            {
                nameFormat = lastName + " " + getFirstInitial();
            }
            else
            {
                nameFormat = lastName + " " + getFirstInitial() + middleInitial;
            }

            return nameFormat;
        }

        //------------------------------------------------------------------
        // Retrieves the first letter of the first name
        //------------------------------------------------------------------
        private string getFirstInitial()
        {
            string firstInitial;

            if (string.IsNullOrEmpty(FirstName))
            {
                firstInitial = "";
            }
            else
            {
                firstInitial = firstName.Substring(0, 1);
            }

            return firstInitial;
        }

        //------------------------------------------------------------------
        // Allows Name objects to be compared and sorted in this priority:
        // First name, Last name, middle initial
        //------------------------------------------------------------------

        public int CompareTo(object obj)
        {
            Name tempObj = (Name)obj;

            string thisName = this.lastCommaFirstMiPeriod();
            string parameterName = tempObj.lastCommaFirstMiPeriod();
            return String.Compare(thisName, parameterName);

        }

    }
}
