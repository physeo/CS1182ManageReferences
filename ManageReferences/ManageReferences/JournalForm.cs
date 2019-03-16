//------------------------------------------------------------------
// JournalForm Class
// Written by Bryce Graham
// CS 1182
// Allows the input of information about a journal reference
// and calls the format methods from the Journal class
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
    public partial class JournalForm : Form
    {

        Journal newJournal = new Journal();

        public JournalForm()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------
        // Adds an author's name to the reference name list and displays
        // the author names in a list box then clears the input textboxes.
        //------------------------------------------------------------------
        private void addNameButton_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text.Trim();
            string middleInitial = miTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(firstName))
            {
                firstName = "";
            }
            if (string.IsNullOrEmpty(middleInitial))
            {
                middleInitial = "";
            } 
            if (string.IsNullOrEmpty(lastName))
            {
                lastName = "";
            }

            newJournal.addAuthor(firstName, middleInitial, lastName);

            if (string.IsNullOrEmpty(middleInitial))
            {
                authorsListBox.Items.Add(firstName + " " + lastName);
            }
            else
            {
                authorsListBox.Items.Add(firstName + " " + middleInitial + " " + lastName);
            }

            firstNameTextBox.Clear();
            miTextBox.Clear();
            lastNameTextBox.Clear();
        }

        //------------------------------------------------------------------------------------
        // Sends all of the data from the application form to the journal reference object
        // and enables the use of the format buttons
        //------------------------------------------------------------------------------------
        private void addJournalButton_Click(object sender, EventArgs e)
        {
            string journalName = JournalNameTextBox.Text.Trim();
            int journalVolume = validateInt(volumeTextBox.Text.Trim());
            int journalNumber = validateInt(numberTextBox.Text.Trim());
            int beginningPage = validateInt(beginPageNumberTextBox.Text.Trim());
            int endPage = validateInt(endPageNumberTextBox.Text.Trim());
            string newTitle = JournalTitleTextBox.Text.Trim();
            int year = validateInt(yearTextBox.Text.Trim());
            int month = validateInt(monthTextBox.Text.Trim());
            int day = validateInt(dayTextBox.Text.Trim());

            newJournal.JournalName.TitleString = journalName;
            newJournal.JournalVolume = journalVolume;
            newJournal.VolumeNumber = journalNumber;
            newJournal.setPages(beginningPage, endPage);
            newJournal.ReferenceTitle.TitleString = newTitle;
            newJournal.ReferenceDate.setDate(year, month, day);

            mlaButton.Enabled = true;
            apaButton.Enabled = true;
            libMedButton.Enabled = true;
        }

        //------------------------------------------------------------------
        // Clears all of the text boxes, resets the application form
        // and creates a new, clean journal reference object
        //------------------------------------------------------------------
        private void addAnothJournalButton_Click(object sender, EventArgs e)
        {
           foreach (TextBox textBox in this.Controls.OfType<TextBox>().ToArray())
           {
               textBox.Clear();
           }

           authorsListBox.Items.Clear();
           journalReferenceDisplayBox.Clear();

           mlaButton.Enabled = false;
           apaButton.Enabled = false;
           libMedButton.Enabled = false;

           newJournal = new Journal();

           firstNameTextBox.Focus();

        }

        //-------------------------------------------------------------------------
        // Exits the journal reference application form and returns focus to the
        // manage references form
        //-------------------------------------------------------------------------
        private void returnManageReferencesButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //------------------------------------------------------------------
        // Exits out of the entire application
        //------------------------------------------------------------------
        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //------------------------------------------------------------------
        // Calls the MLA format method, displays it in the
        // rich text box and then calls the setItalicTitle method
        // to italicize anything that is needed
        //------------------------------------------------------------------
        private void mlaButton_Click(object sender, EventArgs e)
        {
            journalReferenceDisplayBox.Text = newJournal.formatMLA();

            newJournal.setItalicTitle(journalReferenceDisplayBox);
        }

        //------------------------------------------------------------------
        // Calls the APA format method, displays it in the
        // rich text box and then calls the setItalicTitle method
        // to italicize anything that is needed
        //------------------------------------------------------------------
        private void apaButton_Click(object sender, EventArgs e)
        {
            journalReferenceDisplayBox.Text = newJournal.formatAPA();

            newJournal.setItalicTitle(journalReferenceDisplayBox);
        }

        //------------------------------------------------------------------
        // Calls the LibMed format method, displays it in the
        // rich text box and then calls the setItalicTitle method
        // to italicize anything that is needed
        //------------------------------------------------------------------
        private void libMedButton_Click(object sender, EventArgs e)
        {
            journalReferenceDisplayBox.Text = newJournal.formatLibMed();

            newJournal.setItalicTitle(journalReferenceDisplayBox);

        }

        //------------------------------------------------------------------
        // Ensures that any numbers entered are actually ints
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

        //---------------------------------------------------------------------------------
        // Adds a journal reference to the static reference list in the ManageList class
        //---------------------------------------------------------------------------------
       private void addReferenceList_Click(object sender, EventArgs e)
        {
            ManageList.addReference(newJournal);
        }

        
    }
}
