namespace ManageReferences
{
    partial class ManageReferencesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageReferencesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewReferenceListButton = new System.Windows.Forms.ToolStripMenuItem();
            this.printToDocFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.pageSetupButton = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewButton = new System.Windows.Forms.ToolStripMenuItem();
            this.printToPrinterButton = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chapterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.journalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referenceListRichTextBox = new System.Windows.Forms.RichTextBox();
            this.mlaButton = new System.Windows.Forms.RadioButton();
            this.apaButton = new System.Windows.Forms.RadioButton();
            this.libMedButton = new System.Windows.Forms.RadioButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "References";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.addReferenceToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(754, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.startNewReferenceListButton,
            this.printToDocFileButton,
            this.pageSetupButton,
            this.printPreviewButton,
            this.printToPrinterButton,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.openToolStripMenuItem.Text = "Open References from a Data file...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.saveToolStripMenuItem.Text = "Save References to a Data file...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // startNewReferenceListButton
            // 
            this.startNewReferenceListButton.Name = "startNewReferenceListButton";
            this.startNewReferenceListButton.Size = new System.Drawing.Size(260, 22);
            this.startNewReferenceListButton.Text = "Start New Reference List";
            this.startNewReferenceListButton.Click += new System.EventHandler(this.startNewReferenceListButton_Click);
            // 
            // printToDocFileButton
            // 
            this.printToDocFileButton.Name = "printToDocFileButton";
            this.printToDocFileButton.Size = new System.Drawing.Size(260, 22);
            this.printToDocFileButton.Text = "Print References to a Document file";
            this.printToDocFileButton.Click += new System.EventHandler(this.printToDocFileButton_Click);
            // 
            // pageSetupButton
            // 
            this.pageSetupButton.Name = "pageSetupButton";
            this.pageSetupButton.Size = new System.Drawing.Size(260, 22);
            this.pageSetupButton.Text = "Page Setup...";
            this.pageSetupButton.Click += new System.EventHandler(this.pageSetupButton_Click);
            // 
            // printPreviewButton
            // 
            this.printPreviewButton.Name = "printPreviewButton";
            this.printPreviewButton.Size = new System.Drawing.Size(260, 22);
            this.printPreviewButton.Text = "Print Preview...";
            this.printPreviewButton.Click += new System.EventHandler(this.printPreviewButton_Click);
            // 
            // printToPrinterButton
            // 
            this.printToPrinterButton.Name = "printToPrinterButton";
            this.printToPrinterButton.Size = new System.Drawing.Size(260, 22);
            this.printToPrinterButton.Text = "Print References to a Printer";
            this.printToPrinterButton.Click += new System.EventHandler(this.printToPrinterButton_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // addReferenceToolStripMenuItem
            // 
            this.addReferenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookToolStripMenuItem,
            this.chapterToolStripMenuItem,
            this.journalToolStripMenuItem});
            this.addReferenceToolStripMenuItem.Name = "addReferenceToolStripMenuItem";
            this.addReferenceToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.addReferenceToolStripMenuItem.Text = "Add Reference";
            // 
            // bookToolStripMenuItem
            // 
            this.bookToolStripMenuItem.Name = "bookToolStripMenuItem";
            this.bookToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.bookToolStripMenuItem.Text = "Book";
            this.bookToolStripMenuItem.Click += new System.EventHandler(this.bookToolStripMenuItem_Click);
            // 
            // chapterToolStripMenuItem
            // 
            this.chapterToolStripMenuItem.Name = "chapterToolStripMenuItem";
            this.chapterToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.chapterToolStripMenuItem.Text = "Chapter";
            this.chapterToolStripMenuItem.Click += new System.EventHandler(this.chapterToolStripMenuItem_Click);
            // 
            // journalToolStripMenuItem
            // 
            this.journalToolStripMenuItem.Name = "journalToolStripMenuItem";
            this.journalToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.journalToolStripMenuItem.Text = "Journal";
            this.journalToolStripMenuItem.Click += new System.EventHandler(this.journalToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // referenceListRichTextBox
            // 
            this.referenceListRichTextBox.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.referenceListRichTextBox.Location = new System.Drawing.Point(112, 71);
            this.referenceListRichTextBox.Name = "referenceListRichTextBox";
            this.referenceListRichTextBox.Size = new System.Drawing.Size(598, 366);
            this.referenceListRichTextBox.TabIndex = 2;
            this.referenceListRichTextBox.Text = "";
            // 
            // mlaButton
            // 
            this.mlaButton.AutoSize = true;
            this.mlaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mlaButton.Location = new System.Drawing.Point(12, 87);
            this.mlaButton.Name = "mlaButton";
            this.mlaButton.Size = new System.Drawing.Size(82, 17);
            this.mlaButton.TabIndex = 3;
            this.mlaButton.TabStop = true;
            this.mlaButton.Text = "MLA Format";
            this.mlaButton.UseVisualStyleBackColor = true;
            this.mlaButton.CheckedChanged += new System.EventHandler(this.mlaButton_CheckedChanged);
            // 
            // apaButton
            // 
            this.apaButton.AutoSize = true;
            this.apaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.apaButton.Location = new System.Drawing.Point(12, 117);
            this.apaButton.Name = "apaButton";
            this.apaButton.Size = new System.Drawing.Size(81, 17);
            this.apaButton.TabIndex = 4;
            this.apaButton.TabStop = true;
            this.apaButton.Text = "APA Format";
            this.apaButton.UseVisualStyleBackColor = true;
            this.apaButton.CheckedChanged += new System.EventHandler(this.apaButton_CheckedChanged);
            // 
            // libMedButton
            // 
            this.libMedButton.AutoSize = true;
            this.libMedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.libMedButton.Location = new System.Drawing.Point(12, 147);
            this.libMedButton.Name = "libMedButton";
            this.libMedButton.Size = new System.Drawing.Size(95, 17);
            this.libMedButton.TabIndex = 5;
            this.libMedButton.TabStop = true;
            this.libMedButton.Text = "LibMed Format";
            this.libMedButton.UseVisualStyleBackColor = true;
            this.libMedButton.CheckedChanged += new System.EventHandler(this.libMedButton_CheckedChanged);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "bin";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "bin";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // ManageReferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 459);
            this.Controls.Add(this.libMedButton);
            this.Controls.Add(this.apaButton);
            this.Controls.Add(this.mlaButton);
            this.Controls.Add(this.referenceListRichTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ManageReferencesForm";
            this.Text = "Manage References";
            this.Activated += new System.EventHandler(this.manageReferencesActivated);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNewReferenceListButton;
        private System.Windows.Forms.ToolStripMenuItem printToDocFileButton;
        private System.Windows.Forms.ToolStripMenuItem pageSetupButton;
        private System.Windows.Forms.ToolStripMenuItem printPreviewButton;
        private System.Windows.Forms.ToolStripMenuItem printToPrinterButton;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addReferenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chapterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem journalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.RichTextBox referenceListRichTextBox;
        private System.Windows.Forms.RadioButton mlaButton;
        private System.Windows.Forms.RadioButton apaButton;
        private System.Windows.Forms.RadioButton libMedButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}

