//------------------------------------------------------------------
// Manage References Form Class
// Written by Bryce Graham
// CS 1182
// Allows the user to interact with the BookForm, JournalForm
// and ChapterForm classes and displays the references created
// in those forms that are added to a static list in
// the ManageList class.
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
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Drawing.Printing;

namespace ManageReferences
{
    public partial class ManageReferencesForm : Form
    {
        public ManageReferencesForm()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------
        // Creates and opens a bookForm dialog
        //----------------------------------------------------------
        private void bookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm();
            bookForm.ShowDialog();
        }

        //----------------------------------------------------------
        // Creates and opens a chapterForm dialog
        //----------------------------------------------------------
        private void chapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChapterForm chapterForm = new ChapterForm();
            chapterForm.ShowDialog();
        }

        //----------------------------------------------------------
        // Creates and opens a journalForm dialog
        //----------------------------------------------------------
        private void journalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JournalForm journalForm = new JournalForm();
            journalForm.ShowDialog();
        }

        //----------------------------------------------------------------------
        // When the manageReferences form is activated the MLA radio button 
        // is selected and the displayReferences method is called.
        //----------------------------------------------------------------------
        private void manageReferencesActivated(object sender, EventArgs e)
        {
            mlaButton.Select();

            displayReferences();

            printDocument1.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        //-----------------------------------------------------------------------------------
        // First clears the referenceListRichTextBox, then sorts and displays the items
        // in the Reference List as long as the list does not have a null value.
        // It also changes the format of the references when their respective
        // radio buttons are checked.
        //-----------------------------------------------------------------------------------
        private void displayReferences()
        {
            referenceListRichTextBox.Clear();

            if (ManageList.ReferenceList != null)
            {
                ManageList.ReferenceList.Sort();

                if (mlaButton.Checked)
                {
                    foreach (Reference reference in ManageList.ReferenceList)
                     {
                         referenceListRichTextBox.Text += reference.formatMLA() + Environment.NewLine;
                     }
                    
                }
                else if (apaButton.Checked)
                {
                    foreach (Reference reference in ManageList.ReferenceList)
                    {
                        referenceListRichTextBox.Text += reference.formatAPA() + Environment.NewLine;
                    }
                }
                else if(libMedButton.Checked)
                {
                    foreach (Reference reference in ManageList.ReferenceList)
                    {
                       referenceListRichTextBox.Text += reference.formatLibMed() + Environment.NewLine;
                    }
                }

                //------------------------------------------------------------------
                // Reference object to allow access to the setItalicTitle method
                //------------------------------------------------------------------
                Reference italicizeMethod = new Book();
                italicizeMethod.setItalicTitle(referenceListRichTextBox);
            }   
        }

        //----------------------------------------------------------
        // Calls the displayReferences method
        //----------------------------------------------------------

        private void mlaButton_CheckedChanged(object sender, EventArgs e)
        {
            displayReferences();
        }

        //----------------------------------------------------------
        // Calls the displayReferences method
        //----------------------------------------------------------
        private void apaButton_CheckedChanged(object sender, EventArgs e)
        {
            displayReferences();
        }

        //----------------------------------------------------------
        // Calls the displayReferences method
        //----------------------------------------------------------
        private void libMedButton_CheckedChanged(object sender, EventArgs e)
        {
            displayReferences();
        }

        //----------------------------------------------------------
        // Causes the application to exit
        //----------------------------------------------------------
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //----------------------------------------------------------
        // Opens the save file dialog
        //----------------------------------------------------------
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

        }

        //----------------------------------------------------------
        // Opens the open file dialog
        //----------------------------------------------------------
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        //----------------------------------------------------------
        // When the 'OK' button is pressed in the save file dialog
        // write the object information into a data file.
        //----------------------------------------------------------
        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            BinaryFormatter referenceFormatter = new BinaryFormatter();

            string fileName = saveFileDialog1.FileName;
            try
            {
                FileStream referenceFileStream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
                referenceFormatter.Serialize(referenceFileStream, ManageList.ReferenceList);
                referenceFileStream.Close();

                MessageBox.Show("File Written");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing to file " + ex.Message);
            }
        }

        //-------------------------------------------------------------------
        // When the 'OK' button is pressed read the binary file into a new
        // list of references and then add that list to the static list in
        // the ManageList class.
        //-------------------------------------------------------------------
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = openFileDialog1.FileName;

            List<Reference> myReferences = new List<Reference>();

            BinaryFormatter referenceFormatter = new BinaryFormatter();

            if (File.Exists(fileName))
            {
                try
                {
                    FileStream referenceFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                    myReferences = (List<Reference>)referenceFormatter.Deserialize(referenceFileStream);
                    referenceFileStream.Close();

                    foreach (Reference r in myReferences)
                    {
                        ManageList.addReference(r);
                    }

                    displayReferences();

                }
                catch
                {
                    MessageBox.Show("Error reading from file");
                }
            }
        }

        //----------------------------------------------------------
        // Clear the static list in the ManageList class
        // and clear all text from the rich text box.
        //----------------------------------------------------------
        private void startNewReferenceListButton_Click(object sender, EventArgs e)
        {
            ManageList.ReferenceList.Clear();
            referenceListRichTextBox.Clear();
        }

        //----------------------------------------------------------
        // Prints the contents of the rich text box to an .rtf file
        // Throws an error if there is a problem writing the file
        //----------------------------------------------------------

        private void printToDocFileButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileChooser = new SaveFileDialog();
            fileChooser.ValidateNames = true;
            fileChooser.InitialDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
            fileChooser.Filter = "rtf files (*.rtf) |*.rtf|All files (*.*) | *,*";

            if (referenceListRichTextBox.TextLength == 0)
            {
                MessageBox.Show("Nothing to Write");
            }
            else
            {
                if (fileChooser.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        referenceListRichTextBox.SaveFile(fileChooser.FileName);
                        MessageBox.Show("File Written");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message + "\n", "Problem saving the Results: " + ex.Message);
                    }
                }
            }
        }

        //----------------------------------------------------------
        // Allows the user to set up the way they wish the 
        // information to be printed on a page.
        // Prints if the 'OK' button is pressed.
        //----------------------------------------------------------
        private void pageSetupButton_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.Document = printDocument1;

            if (pageSetupDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings = pageSetupDialog1.PrinterSettings;
            }
        }

        //----------------------------------------------------------
        // Shows a preview of what will be printing.
        // Prints if the 'OK' button is pressed.
        //----------------------------------------------------------
        private void printPreviewButton_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;

            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        //----------------------------------------------------------
        // Prints the information from the rich text box
        // to the computer's printer.
        //----------------------------------------------------------

        private void printToPrinterButton_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        //----------------------------------------------------------
        // Handles the graphic drawing of the rich text box
        // information into a printable form.
        //----------------------------------------------------------
        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            StringReader reader = new StringReader(referenceListRichTextBox.Text);
            float LinesPerPage = 0;
            float YPosition = 0;
            float XPosition = 0;
            int Count = 0;
            float LeftMargin = e.MarginBounds.Left;
            float TopMargin = e.MarginBounds.Top;
            string Line = null;
            System.Drawing.FontStyle italic = System.Drawing.FontStyle.Italic;
            Font PrintFont = this.referenceListRichTextBox.Font;
            //Font PrintFont = new Font("Courier New", 12);
            Font PrintFontItalic = new System.Drawing.Font(PrintFont.FontFamily, PrintFont.Size, italic);
            SolidBrush PrintBrush = new SolidBrush(Color.Black);
            char ch;
            int chCount = 0;

            LinesPerPage = e.MarginBounds.Height / PrintFont.GetHeight(e.Graphics);

            while (Count < LinesPerPage && ((Line = reader.ReadLine()) != null))
            {
                YPosition = TopMargin + (Count * PrintFont.GetHeight(e.Graphics));
                XPosition = LeftMargin;

                for (int ndx = 0; ndx < Line.Length; ndx++)
                {
                    ch = Line[ndx];

                    referenceListRichTextBox.SelectionStart = chCount;
                    referenceListRichTextBox.SelectionLength = 1;
                    if (referenceListRichTextBox.SelectionFont.Italic)
                    {
                        e.Graphics.DrawString(ch.ToString(), PrintFontItalic, PrintBrush, XPosition, YPosition - 1, new StringFormat());
                        XPosition += (int)e.Graphics.MeasureString(ch.ToString(), PrintFontItalic).Width - 5;
                    }
                    else
                    {
                        e.Graphics.DrawString(ch.ToString(), PrintFont, PrintBrush, XPosition, YPosition, new StringFormat());
                        XPosition += (int)e.Graphics.MeasureString(ch.ToString(), PrintFont).Width - 5;
                    }
                    chCount++;

                }
                Count++;
                chCount++;
            }

            if (Line != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            PrintBrush.Dispose();
        }    
    }
}
