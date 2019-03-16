//------------------------------------------------------------------
// BookForm Class
// Written by Bryce Graham
// CS 1182
// Allows the input of information about a book reference
// and calls the format methods from the Book class
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
    public partial class BookForm : Form
    {
        Book newBook = new Book();

        public BookForm()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------
        // Adds an authors name to a list in a book object
        // dispays the names in a list box
        // and clears the name text boxes
        //------------------------------------------------------------------
        private void addNameButton_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text.Trim();
            string middleInitial = miTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();

            newBook.addAuthor(firstName, middleInitial, lastName);

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

        //------------------------------------------------------------------
        // Adds the information from the book form to a book object
        // and enables the formatter buttons
        //------------------------------------------------------------------
        private void addBookButton_Click(object sender, EventArgs e)
        {
            string bookTitle = bookTitleTextBox.Text.Trim();
            string bookPublisher = bookPublisherTextBox.Text.Trim();
            int year = validateInt(yearTextBox.Text.Trim());
            int month = validateInt(monthTextBox.Text.Trim());
            int day = validateInt(dayTextBox.Text.Trim());
            string publisherCity = publisherCityTextBox.Text.Trim();
            string publisherState = publisherStateTextBox.Text.Trim();
            string publisherCountry = publisherCountryTextBox.Text.Trim();

            newBook.ReferenceTitle.TitleString = bookTitle;
            newBook.Publisher = bookPublisher;
            newBook.City = publisherCity;
            newBook.State = publisherState;
            newBook.Country = publisherCountry;
            newBook.ReferenceDate.setDate(year, month, day);

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
            bookReferenceDisplayBox.Text = newBook.formatMLA();

            newBook.setItalicTitle(bookReferenceDisplayBox);
        }

        //------------------------------------------------------------------
        // Calls the APA format method, displays it in the
        // rich text box and then calls the setItalicTitle method
        // to italicize anything that is needed
        //------------------------------------------------------------------
        private void apaButton_Click(object sender, EventArgs e)
        {
            bookReferenceDisplayBox.Text = newBook.formatAPA();

            newBook.setItalicTitle(bookReferenceDisplayBox);
        }

        //------------------------------------------------------------------
        // Calls the LibMed format method, displays it in the
        // rich text box and then calls the setItalicTitle method
        // to italicize anything that is needed
        //------------------------------------------------------------------
        private void libMedButton_Click(object sender, EventArgs e)
        {
            bookReferenceDisplayBox.Text = newBook.formatLibMed();

            newBook.setItalicTitle(bookReferenceDisplayBox);
        }

        //------------------------------------------------------------------
        // Clears all text boxes
        // resets the book form
        // and creates a new book object
        //------------------------------------------------------------------
        private void addAnothBookButton_Click(object sender, EventArgs e)
        {
            foreach (TextBox textBox in this.Controls.OfType<TextBox>().ToArray())
            {
                textBox.Clear();
            }

            authorsListBox.Items.Clear();
            bookReferenceDisplayBox.Clear();

            mlaButton.Enabled = false;
            apaButton.Enabled = false;
            libMedButton.Enabled = false;

            newBook = new Book();

            firstNameTextBox.Focus();
        }

        //------------------------------------------------------------------
        // Closes the book form and returns to the manage references form
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

        //----------------------------------------------------------------------
        // Adds a book reference to the reference list in the ManageList class
        //----------------------------------------------------------------------
        private void addReferenceList_Click(object sender, EventArgs e)
        {
            ManageList.addReference(newBook);
        }
    }
}
