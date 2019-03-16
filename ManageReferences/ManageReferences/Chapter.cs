//------------------------------------------------------------------
// Chapter Class
// Written by Bryce Graham
// CS 1182
// Stores the date, title and authors of a reference object
//------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageReferences
{
    [Serializable]
    class Chapter : Book
    {
        private Title chapterTitle;
        private List<Name> editorNames;
        private int beginningPage;
        private int endPage;

        public Chapter()
            : base()
        {
            chapterTitle = new Title();
            editorNames = new List<Name>();
            beginningPage = 0;
            endPage = 0;
        }

        public Chapter(string _bookTitle, string _chapterTitle, int _beginningPage, int _endPage, int _year, int _month, int _day, string _publisher, 
            string _city, string _state, string _country)
            : base(_bookTitle, _year, _month, _day, _publisher, _city, _state, _country)
        {
            chapterTitle = new Title(_chapterTitle);
            editorNames = new List<Name>();
            setPages(_beginningPage, _endPage);
        }

        //------------------------------------------------------------------
        // returns the chapterTitle
        //------------------------------------------------------------------
        public Title ChapterTitle
        {
            get { return chapterTitle; }
        }

        //------------------------------------------------------------------
        // returns the list of editor names
        //------------------------------------------------------------------
        public List<Name> EditorNames
        {
            get { return editorNames; }
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

        //------------------------------------------------------------------
        // returns the endPage and privately allows it to be set as long as it is
        // greater than or equal to the beginningPage
        //------------------------------------------------------------------
        public int EndPage
        {
            get { return endPage; }
            private set
            {
                if (value >= beginningPage)
                {
                    endPage = value;
                }
            }
        }

        //---------------------------------------------------------------------
        // Allows the user of the class to set the beginning and end pages and
        // verifies that the beginning page is not greater than the end page.
        //---------------------------------------------------------------------
        public void setPages(int _beginningPage, int _endPage)
        {
            if (_endPage < beginningPage)
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
        // Allows editor names to be added to the editor list
        // and allows them to be sorted
        //------------------------------------------------------------------
        public void addEditor(string _firstName, string _middleInitial, string _lastName)
        {
            Name newEditor = new Name(_firstName, _middleInitial, _lastName);
            editorNames.Add(newEditor);
            editorNames.Sort();
        }

        //------------------------------------------------------------------
        // Formatter methods
        //------------------------------------------------------------------

        //------------------------------------------------------------------
        // Return the input information in MLA format
        // Allows for no authors and fixes redundant period
        // if only one author is entered
        //------------------------------------------------------------------
        public override string formatMLA()
        {
            string chapterMLA = null;

            if (NameList.Count == 1)
            {
                chapterMLA = this.getLastFirstMi_FirstMiLast(this.NameList) + " \"" + 
                    ChapterTitle.eachFirstLetterCaps(false) + ".\" " + ReferenceTitle.eachFirstLetterCaps(true) + ". " + 
                    "Eds. " + getFirstMiLast(EditorNames) + ". " + City + ": " + Publisher + ", " + 
                    ReferenceDate.Year + ". " + BeginningPage + "-" + EndPage;
            }
            else if (NameList.Count == 0)
            {
                chapterMLA = "\"" + ChapterTitle.eachFirstLetterCaps(false) + ".\" " + ReferenceTitle.eachFirstLetterCaps(true) + ". " +
                    "Eds. " + getFirstMiLast(EditorNames) + ". " + City + ": " + Publisher + ", " + 
                    ReferenceDate.Year + ". " + BeginningPage + "-" + EndPage;
            }
            else
            {
                chapterMLA = this.getLastFirstMi_FirstMiLast(this.NameList) + ". " + "\"" +
                     ChapterTitle.eachFirstLetterCaps(false) + ".\" " + ReferenceTitle.eachFirstLetterCaps(true) + ". " +
                     "Eds. " + getFirstMiLast(EditorNames) + ". " + City + ": " + Publisher + ", " 
                     + ReferenceDate.Year + ". " + BeginningPage + "-" + EndPage;
            }

            return chapterMLA;
        }

        //------------------------------------------------------------------
        // Returns input information in APA format
        // and allows for no authors
        //------------------------------------------------------------------
        public override string formatAPA()
        {
            string chapterAPA = null;

            if (NameList.Count != 0)
            {
                chapterAPA = this.getLastFiMi(this.NameList) + " (" + ReferenceDate.Year + "). " +
                    ChapterTitle.firstLetterCap(false) + ". " + "In " + getFiMiLast(EditorNames) + " "
                    + ReferenceTitle.firstLetterCap(true) + ". " + City + ": " + Publisher + ".";
            }
            else
            {
                chapterAPA = "(" + ReferenceDate.Year + "). " +
                    ChapterTitle.firstLetterCap(false) + ". " + "In " + getFiMiLast(EditorNames) + " "
                    + ReferenceTitle.firstLetterCap(true) + ". " + City + ": " + Publisher + ".";
            }

            return chapterAPA;
        }

        //------------------------------------------------------------------
        // Returns input information in Library of Medicine format
        // and allows for no authors
        //------------------------------------------------------------------
        public override string formatLibMed()
        {
            string chapterLibMed = null;

            if (NameList.Count != 0)
            {
                chapterLibMed = this.getLastFiMiNoCommaNoDot(this.NameList) + ". " + ChapterTitle + ". In: " +
                    getLastFiMiNoCommaNoDot(EditorNames) + " Editors. " + ReferenceTitle.eachFirstLetterCaps(false) + ". "
                    + City + ": " + Publisher + "; " + ReferenceDate.Year + ".";
            }
            else
            {
                chapterLibMed = ChapterTitle + ". In: " +
                    getLastFiMiNoCommaNoDot(EditorNames) + " Editors. " + ReferenceTitle.eachFirstLetterCaps(false) + ". "
                    + City + ": " + Publisher + "; " + ReferenceDate.Year + ".";
            }

            return chapterLibMed;
        }
    }
}
