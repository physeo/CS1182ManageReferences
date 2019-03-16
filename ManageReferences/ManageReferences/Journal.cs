//------------------------------------------------------------------
// Journal Class
// Written by Bryce Graham
// CS 1182
// Stores the journal name, journal volume, vulume number,
// beginning page and end page of a journal and then uses methods
// to return the information in different formats
//------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageReferences
{
    [Serializable]
    class Journal : Reference
    {
        private Title journalName;
        private int journalVolume;
        private int volumeNumber;
        private int beginningPage;
        private int endPage;

        //------------------------------------------------------------------
        //Constructors
        //------------------------------------------------------------------
        public Journal()
            : base()
        {
            journalName = new Title();
            journalVolume = 0;
            volumeNumber = 0;
            beginningPage = 0;
            endPage = 0;
        }

        public Journal(string _journalName, int _journalVolume, int _volumeNumber, int _beginningPage, int _endPage,
            string _newTitle, int _year, int _month, int _day)
            : base(_newTitle, _year, _month,  _day)
        {
            journalName = new Title(_journalName);
            JournalVolume = _journalVolume;
            VolumeNumber = _volumeNumber;
            setPages(_beginningPage, _endPage);
        }

        //------------------------------------------------------------------
        // Properties
        //------------------------------------------------------------------
        public Title JournalName
        {
            get { return journalName; }
        }

        public int JournalVolume
        {
            get { return journalVolume; }
            set
            {
                journalVolume = value;
            }
        }

        public int VolumeNumber
        {
            get { return volumeNumber; }
            set
            {
                volumeNumber = value;
            }
        }

        //------------------------------------------------------------------
        // returns the beginningPage and privately allows it to be set
        //------------------------------------------------------------------
        public int BeginningPage
        {
            get { return beginningPage; }
            private set
            {
                beginningPage = value;
            }
        }

        //-------------------------------------------------------------------------
        // returns the endPage and privately allows it to be set as long as it is
        // greater than or equal to the beginningPage
        //-------------------------------------------------------------------------
        public int EndPage
        {
            get { return endPage; }
            private  set
            {
                if (value >= beginningPage)
                {
                    endPage = value;
                }
            }
        }

        //----------------------------------------------------------------------
        // Allows the user of the class to set the beginning and end pages and
        // verifies that the beginning page is not greater than the end page.
        //----------------------------------------------------------------------

        public void setPages(int _beginningPage, int _endPage)
        {
            if(_endPage < beginningPage)
            {
                EndPage = 0;
                BeginningPage = 0;
            }
            else
            {
                BeginningPage = _beginningPage;
                EndPage = _endPage;
            }
        }

        //------------------------------------------------------------------
        // Formatter methods
        //------------------------------------------------------------------

        //------------------------------------------------------------------
        // Returns the reference information in MLA format
        //------------------------------------------------------------------
        public override string formatMLA()
        {
            string journalMLA;

            //------------------------------------------------------------------
            // Removes Volume Number if there is not one
            //------------------------------------------------------------------
            if (VolumeNumber != 0)
            {
                //------------------------------------------------------------------
                // Removes redundant period if there is only one name
                //------------------------------------------------------------------
                if (NameList.Count == 1)
                {
                    journalMLA = this.getLastFirstMi_FirstMiLast(this.NameList) + " \"" + ReferenceTitle.eachFirstLetterCaps(false) + ".\" "
                        + JournalName.noFormat(true) + " " + JournalVolume + "." + VolumeNumber + " (" + ReferenceDate.Year + "): "
                        + BeginningPage + "-" + EndPage + ".";
                }
                else if (NameList.Count == 0)
                {
                    journalMLA = "\"" + ReferenceTitle.eachFirstLetterCaps(false) + ".\" "
                        + JournalName.noFormat(true) + " " + JournalVolume + "." + VolumeNumber + " (" + ReferenceDate.Year + "): "
                        + BeginningPage + "-" + EndPage + ".";
                }
                else
                {
                    journalMLA = this.getLastFirstMi_FirstMiLast(this.NameList) + ". \"" + ReferenceTitle.eachFirstLetterCaps(false) + ".\" "
                        + JournalName.noFormat(true) + " " + JournalVolume + "." + VolumeNumber + " (" + ReferenceDate.Year + "): "
                        + BeginningPage + "-" + EndPage + ".";
                }
            }
            else
            {
                if (NameList.Count == 1)
                {
                    journalMLA = this.getLastFirstMi_FirstMiLast(this.NameList) + " \"" + ReferenceTitle.eachFirstLetterCaps(false) + ".\" "
                        + JournalName.noFormat(true) + " " + JournalVolume + " (" + ReferenceDate.Year + "): "
                        + BeginningPage + "-" + EndPage + ".";
                }
                else if (NameList.Count == 0)
                {
                    journalMLA = "\"" + ReferenceTitle.eachFirstLetterCaps(false) + ".\" "
                        + JournalName.noFormat(true) + " " + JournalVolume + " (" + ReferenceDate.Year + "): "
                        + BeginningPage + "-" + EndPage + ".";
                }
                else
                {
                    journalMLA = this.getLastFirstMi_FirstMiLast(this.NameList) + ". \"" + ReferenceTitle.eachFirstLetterCaps(false) + ".\" "
                        + JournalName.noFormat(true) + " " + JournalVolume + " (" + ReferenceDate.Year + "): "
                        + BeginningPage + "-" + EndPage + ".";
                }
            }
            

            return journalMLA;
        }

        //------------------------------------------------------------------
        // Returns the reference information in APA format
        //------------------------------------------------------------------
        public override string formatAPA()
        {
            string journalAPA = null;

            //------------------------------------------------------------------
            // Removes Volume Number if there is not one
            //------------------------------------------------------------------
            if (VolumeNumber != 0)
            {
                //------------------------------------------------------------------
                // Removes redundant period if there is only one name
                //------------------------------------------------------------------
                if (NameList.Count == 0)
                {
                    journalAPA = "(" + ReferenceDate.Year + "). " + ReferenceTitle.firstLetterCap(false) + ". "
                    + JournalName.noFormat(true) + ", " + JournalVolume + "." + VolumeNumber + ", " + BeginningPage + "-" + EndPage + ".";
                }
                else
                {
                    journalAPA = this.getLastFiMi(this.NameList) + " (" + ReferenceDate.Year + "). " + ReferenceTitle.firstLetterCap(false) + ". "
                                    + JournalName.noFormat(true) + ", " + JournalVolume + "." + VolumeNumber + ", " + BeginningPage + "-" + EndPage + ".";
                }
            }
            else
            {
                if (NameList.Count == 0)
                {
                    journalAPA = "(" + ReferenceDate.Year + "). " + ReferenceTitle.firstLetterCap(false) + ". "
                    + JournalName.noFormat(true) + ", " + JournalVolume + ", " + BeginningPage + "-" + EndPage + ".";
                }
                else
                {
                    journalAPA = this.getLastFiMi(this.NameList) + " (" + ReferenceDate.Year + "). " + ReferenceTitle.firstLetterCap(false) + ". "
                                    + JournalName.noFormat(true) + ", " + JournalVolume + ", " + BeginningPage + "-" + EndPage + ".";
                }
            }
            
            return journalAPA;
        }

        //------------------------------------------------------------------
        // Returns the reference information in Library of Medicine format
        //------------------------------------------------------------------
        public override string formatLibMed()
        {
            string journalLibMed = null;

            //------------------------------------------------------------------
            // Removes Volume Number if there is not one
            //------------------------------------------------------------------
            if (VolumeNumber != 0)
            {
                //------------------------------------------------------------------
                // Removes redundant period if there is only one name
                //------------------------------------------------------------------
                if (NameList.Count == 0)
                {
                    journalLibMed = ReferenceTitle.eachFirstLetterCaps(false) + ". "
                        + JournalName.noFormat(true) + " " + ReferenceDate.Year + "; " + JournalVolume + "." + VolumeNumber + ":" + BeginningPage + "-" + EndPage + ".";
                }
                else
                {
                    journalLibMed = this.getLastFiMiNoCommaNoDot(this.NameList) + ". " + ReferenceTitle.eachFirstLetterCaps(false) + ". "
                        + JournalName.noFormat(true) + " " + ReferenceDate.Year + "; " + JournalVolume + "." + VolumeNumber + ":" + BeginningPage + "-" + EndPage + ".";
                }
            }
            else
            {
                if (NameList.Count == 0)
                {
                    journalLibMed = ReferenceTitle.eachFirstLetterCaps(false) + ". "
                        + JournalName.noFormat(true) + " " + ReferenceDate.Year + "; " + JournalVolume + ":" + BeginningPage + "-" + EndPage + ".";
                }
                else
                {
                    journalLibMed = this.getLastFiMiNoCommaNoDot(this.NameList) + ". " + ReferenceTitle.eachFirstLetterCaps(false) + ". "
                        + JournalName.noFormat(true) + " " + ReferenceDate.Year + "; " + JournalVolume + ":" + BeginningPage + "-" + EndPage + ".";
                }
            }

            return journalLibMed;
        }
    }
}
