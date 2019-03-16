//------------------------------------------------------------------
// ChapterForm Class
// written by Bryce Graham
// CS 1182
// Allows the user to interact with the chapter class
//------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManageReferences
{
    public partial class ChapterForm : Form
    {
        Chapter newChapter = new Chapter();

        public ChapterForm()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------
        // Adds an author name to the author list in the chapter reference object
        // displays the names in a list box
        // and clears the name text boxes
        //------------------------------------------------------------------
        private void addNameButton_Click(object sender, EventArgs e)
        {
            string firstName = authorFirstNameTextBox.Text.Trim();
            string middleInitial = authorMiTextBox.Text.Trim();
            string lastName = authorLastNameTextBox.Text.Trim();

            newChapter.addAuthor(firstName, middleInitial, lastName);

            if (string.IsNullOrEmpty(middleInitial))
            {
                authorsListBox.Items.Add(firstName + " " + lastName);
            }
            else
            {
                authorsListBox.Items.Add(firstName + " " + middleInitial + " " + lastName);
            }

            authorFirstNameTextBox.Clear();
            authorMiTextBox.Clear();
            authorLastNameTextBox.Clear();
        }

        //------------------------------------------------------------------
        // Adds editor names to a list in the chapter referenece object
        // displays the editor names in a list box
        // and clears the editor name text boxes
        //------------------------------------------------------------------
        private void addEditorButton_Click(object sender, EventArgs e)
        {
            string firstName = editorFirstNameTextBox.Text.Trim();
            string middleInitial = editorMiTextBox.Text.Trim();
            string lastName = editorLastNameTextBox.Text.Trim();

            newChapter.addEditor(firstName, middleInitial, lastName);

            if (string.IsNullOrEmpty(middleInitial))
            {
                editorsListBox.Items.Add(firstName + " " + lastName);
            }
            else
            {
                editorsListBox.Items.Add(firstName + " " + middleInitial + " " + lastName);
            }

            editorFirstNameTextBox.Clear();
            editorMiTextBox.Clear();
            editorLastNameTextBox.Clear();
        }

        //------------------------------------------------------------------
        // Adds all of the chapter form data to a chapter object
        // and enables the formatter buttons
        //------------------------------------------------------------------
        private void addChapterButton_Click(object sender, EventArgs e)
        {
            string chapterTitle = chapterTitleTextBox.Text.Trim();
            string bookTitle = bookTitleTextBox.Text.Trim();
            string bookPublisher = bookPublisherTextBox.Text.Trim();
            int year = validateInt(yearTextBox.Text.Trim());
            int month = validateInt(monthTextBox.Text.Trim());
            int day = validateInt(dayTextBox.Text.Trim());
            int beginningPage = validateInt(beginPageNumberTextBox.Text.Trim());
            int endPage = validateInt(endPageNumberTextBox.Text.Trim());
            string publisherCity = publisherCityTextBox.Text.Trim();
            string publisherState = publisherStateTextBox.Text.Trim();
            string publisherCountry = publisherCountryTextBox.Text.Trim();

            newChapter.ReferenceTitle.TitleString = bookTitle;
            newChapter.ChapterTitle.TitleString = chapterTitle;
            newChapter.Publisher = bookPublisher;
            newChapter.City = publisherCity;
            newChapter.State = publisherState;
            newChapter.Country = publisherCountry;
            newChapter.ReferenceDate.setDate(year, month, day);
            newChapter.setPages(beginningPage, endPage);

            mlaButton.Enabled = true;
            apaButton.Enabled = true;
            libMedButton.Enabled = true;
        
        }

        //------------------------------------------------------------------
        // Calls the MLA format method, displays it in the
        // rich text box and then calls the setItalicTitle method
        // to italicize anything that is needed
        //------------------------------------------------------------------
        private void mlaButton_Click(object sender, EventArgs e)
        {
            chapterReferenceDisplayBox.Text = newChapter.formatMLA();

            newChapter.setItalicTitle(chapterReferenceDisplayBox);
        }

        //------------------------------------------------------------------
        // Calls the APA format method, displays it in the
        // rich text box and then calls the setItalicTitle method
        // to italicize anything that is needed
        //------------------------------------------------------------------
        private void apaButton_Click(object sender, EventArgs e)
        {
            chapterReferenceDisplayBox.Text = newChapter.formatAPA();

            newChapter.setItalicTitle(chapterReferenceDisplayBox);
        }

        //------------------------------------------------------------------
        // Calls the LibMed format method, displays it in the
        // rich text box and then calls the setItalicTitle method
        // to italicize anything that is needed
        //------------------------------------------------------------------
        private void libMedButton_Click(object sender, EventArgs e)
        {
            chapterReferenceDisplayBox.Text = newChapter.formatLibMed();

            newChapter.setItalicTitle(chapterReferenceDisplayBox);
        }

        //------------------------------------------------------------------
        // Clears the text boxes and resets the form while creating a new
        // chapter reference object
        //------------------------------------------------------------------
         private void addAnothChapterButton_Click(object sender, EventArgs e)
        {
            foreach (TextBox textBox in this.Controls.OfType<TextBox>().ToArray())
            {
                textBox.Clear();
            }

            authorsListBox.Items.Clear();
            editorsListBox.Items.Clear();
            chapterReferenceDisplayBox.Clear();

            mlaButton.Enabled = false;
            apaButton.Enabled = false;
            libMedButton.Enabled = false;

            newChapter = new Chapter();

            authorFirstNameTextBox.Focus();
        }

        //------------------------------------------------------------------
        // Closes the chapter form and returns to the manage references form
        //------------------------------------------------------------------
        private void returnManageReferencesButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        //------------------------------------------------------------------
        // Exits the entire application
        //------------------------------------------------------------------
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //------------------------------------------------------------------
        // Ensures that any numbers required are actually ints
        //------------------------------------------------------------------
        private int validateInt(string testInt)
        {
            int validInt;

            bool valid = int.TryParse(testInt, out validInt);

            if (!valid)
            {
                validInt = 0;
            }


            return validInt;
        }

        //------------------------------------------------------------------------
        // Adds a chapter reference to the reference list in the ManageList class
        //------------------------------------------------------------------------
        private void addReferenceList_Click(object sender, EventArgs e)
        {
            ManageList.addReference(newChapter);
        }
       
    }
}
