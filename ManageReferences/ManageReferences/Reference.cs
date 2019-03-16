//------------------------------------------------------------------
// Reference Class
// Written by Bryce Graham
// CS 1182
// Stores the date, title and authors of a reference object
// and allows them to be retrieved into various formats
//------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;


namespace ManageReferences
{
[Serializable]
    abstract class Reference : IformatReference, IComparable
    {
        private Title referenceTitle;
        private Date referenceDate;
        private List<Name> nameList;

        //------------------------------------------------------------------
        // Constructors
        //------------------------------------------------------------------

        public Reference()
        {
            referenceTitle = new Title();
            referenceDate = new Date();
            nameList = new List<Name>();
        }

        public Reference(string _newTitle, int _year, int _month, int _day)
        {
            referenceTitle = new Title(_newTitle);
            referenceDate = new Date(_year, _month, _day);
            nameList = new List<Name>();
        }

        //------------------------------------------------------------------
        // Properties
        //------------------------------------------------------------------

        public Title ReferenceTitle
        {
            get { return referenceTitle; }
        }

        public Date ReferenceDate
        {
            get { return referenceDate; }
        }

        public List<Name> NameList
        {
            get { return nameList; }
        }

        //------------------------------------------------------------------
        // Adds a new author name to the name list
        //------------------------------------------------------------------
        public void addAuthor(string _firstName, string _middleInitial, string _lastName)
        {
            
            Name newAuthor = new Name(_firstName, _middleInitial, _lastName);
            nameList.Add(newAuthor);
            nameList.Sort();
        }

        //------------------------------------------------------------------
        // Formatter methods
        //------------------------------------------------------------------

        //------------------------------------------------------------------
        // Returns reference format: Last, First M., Last, First M. and Last, First M.
        //------------------------------------------------------------------
        public string getLastFirstMi(List<Name> _nameList)
        {
            string referenceFormat = null;

            for (int ndx = 0; ndx < _nameList.Count; ndx++)
            {
                if (ndx == 0)
                {
                    referenceFormat += _nameList[ndx].lastCommaFirstMiPeriod();
                }
                else if (ndx == nameList.Count - 1)
                {
                    referenceFormat += " and " + _nameList[ndx].lastCommaFirstMiPeriod();
                }
                else
                {
                    referenceFormat += ", " + _nameList[ndx].lastCommaFirstMiPeriod();
                }

            }

            return referenceFormat;
        }

        //----------------------------------------------------------------------
        // Returns reference format: Last, F. M., Last, F. M. and Last, F. M.
        //----------------------------------------------------------------------
        public string getLastFiMi(List<Name> _nameList)
        {
            string referenceFormat = null;

            for (int ndx = 0; ndx < _nameList.Count; ndx++)
            {
                if (ndx == 0)
                {
                    referenceFormat += _nameList[ndx].lastCommaInitialsPeriods();
                }
                else if (ndx == nameList.Count - 1)
                {
                    referenceFormat += " and " + _nameList[ndx].lastCommaInitialsPeriods();
                }
                else
                {
                    referenceFormat += ", " + _nameList[ndx].lastCommaInitialsPeriods();
                }

            }

            return referenceFormat;
        }
        //----------------------------------------------------------------------------
        // Returns reference format: Last, F. M., First M. Last and First M. Last
        //----------------------------------------------------------------------------
        public string getLastFiMi_FirstMiLast(List<Name> _nameList)
        {
            string referenceFormat = null;

            for (int ndx = 0; ndx < _nameList.Count; ndx++)
            {
                if (ndx == 0)
                {
                    referenceFormat = _nameList[ndx].lastCommaInitialsPeriods();
                }
                else if (ndx == nameList.Count - 1)
                {
                    referenceFormat += " and " + _nameList[ndx].firstMiPeriodLast();
                }
                else
                {
                    referenceFormat += ", " + _nameList[ndx].firstMiPeriodLast();
                }

            }

            return referenceFormat;
        }

        //-----------------------------------------------------------------------------
        // Returns reference format: Last, First M., First M. Last and first M. Last
        //-----------------------------------------------------------------------------
        public string getLastFirstMi_FirstMiLast(List<Name> _nameList)
        {
            string referenceFormat = null;

            for (int ndx = 0; ndx < _nameList.Count; ndx++)
            {
                if (ndx == 0)
                {
                    referenceFormat = _nameList[ndx].lastCommaFirstMiPeriod();
                }
                else if (ndx == nameList.Count - 1)
                {
                    referenceFormat += " and " + _nameList[ndx].firstMiPeriodLast();
                }
                else
                {
                    referenceFormat += ", " + _nameList[ndx].firstMiPeriodLast();
                }

            }

            return referenceFormat;
        }

        //------------------------------------------------------------------
        // Returns reference format: Last FM, Last FM, Last FM
        //------------------------------------------------------------------
        public string getLastFiMiNoCommaNoDot(List<Name> _nameList)
        {
            string referenceFormat = null;

            for (int ndx = 0; ndx < _nameList.Count; ndx++)
            {
                if (ndx == 0)
                {
                    referenceFormat = _nameList[ndx].lastSpaceInitials();
                }
                else
                {
                    referenceFormat += ", " + _nameList[ndx].lastSpaceInitials();
                }

            }

            return referenceFormat;
        }
        //------------------------------------------------------------------
        // Returns reference format: F M Last, F M Last and F M Last
        //------------------------------------------------------------------
        public string getFiMiLast(List<Name> _nameList)
        {
            string referenceFormat = null;

            for (int ndx = 0; ndx < _nameList.Count; ndx++)
            {
                if (ndx == 0)
                {
                    referenceFormat = _nameList[ndx].initialsSpacesLastName();
                }
                else if (ndx == nameList.Count - 1)
                {
                    referenceFormat += " and " + _nameList[ndx].initialsSpacesLastName();
                }
                else
                {
                    referenceFormat += ", " + _nameList[ndx].initialsSpacesLastName();
                }

            }

            return referenceFormat;
        }

        // Returns reference format: First M Last, First M, Last and First M Last
        public string getFirstMiLast(List<Name> _nameList)
        {
            string referenceFormat = null;

            for (int ndx = 0; ndx < _nameList.Count; ndx++)
            {
                if (ndx == 0)
                {
                    referenceFormat = _nameList[ndx].firstMiLast();
                }
                else if (ndx == nameList.Count - 1)
                {
                    referenceFormat += " and " + _nameList[ndx].firstMiLast();
                }
                else
                {
                    referenceFormat += ", " + _nameList[ndx].firstMiLast();
                }

            }

            return referenceFormat;
        }

        //-------------------------------------------------------------------------------------------------------
        // Italicization
        // Receives a RichTextBox object and a string and creates an italic Font object
        // Whatever part of the string has <i> at the beginning and </i> at the end it will be italicized
        //-------------------------------------------------------------------------------------------------------
        public void setItalicTitle(RichTextBox textToItalicize)
        {
            string rtb = textToItalicize.Text;
            List<string> italicizeMeList = new List<string>();
            Font currentFont = textToItalicize.SelectionFont;
            FontStyle newFontStyle = FontStyle.Italic;
            FontStyle resetFont = FontStyle.Regular;
            textToItalicize.SelectAll();
            textToItalicize.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, resetFont);
            textToItalicize.DeselectAll();

            while (rtb.IndexOf("<i>") >= 0 && rtb.IndexOf("</i>") >= 0)
            {
                int start = rtb.IndexOf("<i>");
                int end = rtb.IndexOf("</i>");

                string italicizeMe = rtb.Substring(start + 3, end - (start + 3));

                rtb = rtb.Substring(0, start) + italicizeMe + rtb.Substring(end + 4);
                textToItalicize.Text = rtb;

                italicizeMeList.Add(italicizeMe);
            }

            foreach (string s in italicizeMeList)
            {
                textToItalicize.SelectionStart = rtb.IndexOf(s);
                textToItalicize.SelectionLength = s.Length;
                textToItalicize.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newFontStyle);
            }
        }

        //------------------------------------------------------------------
        // Allows Reference type objects to be compared by this priority:
        // First name, Last name and middle initial
        //------------------------------------------------------------------
        public int CompareTo(object obj)
        {
            Reference tempRef = (Reference)obj;

            string thisReference = this.getLastFirstMi(this.NameList);
            string parameterReference = tempRef.getLastFirstMi(tempRef.NameList);
            return String.Compare(thisReference, parameterReference);
        }

        //------------------------------------------------------------------
        // Abstract methods
        //------------------------------------------------------------------

        public abstract string formatLibMed();
        public abstract string formatMLA();
        public abstract string formatAPA();
    }
}
