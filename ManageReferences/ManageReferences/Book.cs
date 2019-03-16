//------------------------------------------------------------------
// Book Class
// Written by Bryce Graham
// CS 1182
// Stores the publisher, state, city and country of a book 
// and uses methods to return them in different formats
//------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageReferences
{
    [Serializable]

    class Book : Reference
    {
        private string publisher;
        private string city;
        private string state;
        private string country;

        public Book()
            : base()
        {
            publisher = null;
            city = null;
            state = null;
            country = null;
        }

        public Book(string _bookTitle, int _year, int _month, int _day, 
            string _publisher, string _city, string _state, string _country)
            : base(_bookTitle, _year, _month, _day)
        {
            Publisher = _publisher;
            City = _city;
            State = _state;
            Country = _country;
        }

        //------------------------------------------------------------------
        // Returns the publisher and allows it to be set.
        // If the publisher is null or empty it is set to "No Publisher"
        //------------------------------------------------------------------
        public string Publisher
        {
            get { return publisher; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    publisher = "No Publisher";
                }
                else
                {
                    publisher = value;
                }
              
            }
        }

        //------------------------------------------------------------------
        // Returns the city and allows it to be set.
        // If the city is null or empty it is set to "No City"
        //------------------------------------------------------------------
        public string City
        {
            get { return city; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    city = "No City";
                }
                else
                {
                    city = value;
                }
               
            }
        }

        //------------------------------------------------------------------
        // Returns the state and allows it to be set.
        // If the state is null or empty it is set to "No state"
        //------------------------------------------------------------------
        public string State
        {
            get { return state; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    state = "No State";
                }
                else
                {
                    state = value;
                }
                
            }
        }

        //------------------------------------------------------------------
        // Returns the country and allows it to be set.
        // If the country is null or empty it is set to "No Country"
        //------------------------------------------------------------------
        public string Country
        {
            get { return country; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    country = "No Country";
                }
                else
                {
                    country = value;
                }
                
            }
        }

        //------------------------------------------------------------------
        // Returns the reference information in MLA format
        //------------------------------------------------------------------
        public override string formatMLA()
        {
            string bookMLA = null;

            //------------------------------------------------------------------
            // Allows for no authors
            // Fixes redundant period if there is only one name
            //------------------------------------------------------------------

            if (NameList.Count == 1)
            {
                bookMLA = getLastFirstMi_FirstMiLast(this.NameList) + " " + ReferenceTitle.eachFirstLetterCaps(true) +
                    ". " + City + ": " + Publisher + ", " + ReferenceDate.Year + ".";
            }
            else if (NameList.Count == 0)
            {
                bookMLA = ReferenceTitle.eachFirstLetterCaps(true) + ". " + City + ": " + Publisher 
                    + ", " + ReferenceDate.Year + ".";
            }
            else
            {
                bookMLA = getLastFirstMi_FirstMiLast(this.NameList) + ". " + ReferenceTitle.eachFirstLetterCaps(true)
                    + ". " + City + ": " + Publisher + ", " + ReferenceDate.Year + ".";
            }

            return bookMLA;
        }

        //------------------------------------------------------------------
        // Returns the reference information in APA format
        // Allows for no author
        //------------------------------------------------------------------
        public override string formatAPA()
        {
            string bookAPA = null;

            if (NameList.Count != 0)
            {
                bookAPA = this.getLastFiMi(this.NameList) + " (" + ReferenceDate.Year + "). " + 
                    ReferenceTitle.firstLetterCap(true) + ". " + City + ": " + Publisher + ".";
            }
            else
            {
                bookAPA = "(" + ReferenceDate.Year + "). " + ReferenceTitle.firstLetterCap(true) + ". " +
                    City + ": " + Publisher + ".";
            }

            return bookAPA;
        }

        //------------------------------------------------------------------
        // Returns the reference information in Library of Medicine format
        // Allows for no author
        //------------------------------------------------------------------
        public override string formatLibMed()
        {
            string bookLibMed = null;

            if (NameList.Count != 0)
            {
                bookLibMed = this.getLastFiMiNoCommaNoDot(this.NameList) + ". " + ReferenceTitle.eachFirstLetterCaps(false) + ". " + City + ": " + Publisher + "; " + ReferenceDate.Year + ".";
            }
            else
            {
                bookLibMed = ReferenceTitle.eachFirstLetterCaps(false) + ". " + City + ": " + Publisher + "; " + ReferenceDate.Year + ".";
            }

            return bookLibMed;
        }
    }
}
