//------------------------------------------------------------------
// Title class
// Written by Bryce Graham
// CS 1182
// Store a title and transform it into several different formats
//------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageReferences
{
    [Serializable]
    class Title
    {
        private string titleString;

        //------------------------------------------------------------------
        // Constructors
        //------------------------------------------------------------------

        public Title()
        {
            titleString = "";
        }

        public Title(string _title)
        {
            TitleString = _title;
        }

        //------------------------------------------------------------------
        // Properties
        //------------------------------------------------------------------

        //------------------------------------------------------------------
        // Returns the titleString and allows it to be set
        // as long as it is not null or empty. Otherwise it
        // is set as "No Title."
        //------------------------------------------------------------------
        public string TitleString
        {
            get { return titleString; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    titleString = "No Title";
                }
                else
                {
                    titleString = value.Trim();
                }
                
            }
        }

        //------------------------------------------------------------------
        // Formatter methods
        //------------------------------------------------------------------

        //------------------------------------------------------------------
        // Leave the input as it is
        //------------------------------------------------------------------

        public string noFormat(bool italics)
        {
            if (italics)
            {
                return italicizeTitle(titleString);
            }
            else
            {
                return titleString;
            }
        }

        //------------------------------------------------------------------
        // Change the first letter of each word in the title to uppercase
        //------------------------------------------------------------------

        public string eachFirstLetterCaps(bool italics)
        {
            string titleFormat;
  
                char[] titleChar = TitleString.ToCharArray();

                if (titleChar.Length >= 1)
                {
                    if (char.IsLower(titleChar[0]))
                    {
                        titleChar[0] = char.ToUpper(titleChar[0]);
                    }
                }

                for (int x = 1; x < titleChar.Length; x++)
                {
                    if (titleChar[x - 1] == ' ')
                    {
                        if (char.IsLower(titleChar[x]))
                        {
                            titleChar[x] = char.ToUpper(titleChar[x]);
                        }
                    }
                }

                titleFormat = new string(titleChar);

                if (italics)
                {
                   return italicizeTitle(titleFormat);
                }

            return titleFormat;
        }

        //------------------------------------------------------------------------------------------
        // Change the first letter of the title and the subtitle (designated by ":") to uppercase
        //------------------------------------------------------------------------------------------

        public string firstLetterCap(bool italics)
        {
            string titleFormat = null;
            char firstLetter;
            string restOfTitle;
            char subtitleFirstLetter;

            firstLetter = char.ToUpper(TitleString[0]);
            restOfTitle = TitleString.Substring(1);
            restOfTitle = restOfTitle.ToLower();
            titleFormat = firstLetter + restOfTitle;

            if (titleFormat.IndexOf(":") > -1)
            {
                subtitleFirstLetter = titleFormat[titleFormat.IndexOf(":") + 2];
                subtitleFirstLetter = char.ToUpper(subtitleFirstLetter);

                titleFormat = titleFormat.Substring(0, titleFormat.IndexOf(":") + 2) + subtitleFirstLetter + titleFormat.Substring(titleFormat.IndexOf(":") + 3);
            }

            if (italics)
            {
                return italicizeTitle(titleFormat);
            }
  
            return titleFormat;
        }

        //------------------------------------------------------------------
        // Convert every letter in the title to lowercase
        //------------------------------------------------------------------

        public string allLowercase(bool italics)
        {
            string titleFormat = TitleString.ToLower();

            if (italics)
            {
                return italicizeTitle(titleFormat);
            }

            return titleFormat;
        }

        //------------------------------------------------------------------
        // Place tags on the title to signal that it should be
        // italicized
        //------------------------------------------------------------------

        public string italicizeTitle(string _title)
        {
            _title = "<i>" + _title + @"</i>";
            
            return _title;
        }

    }
}
