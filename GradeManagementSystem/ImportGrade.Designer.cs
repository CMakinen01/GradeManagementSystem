namespace GradeManagementSystem
{
    partial class ImportGrade
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
            backButton = new Button();
            fileImport = new Button();
            folderImport = new Button();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            folderBrowserDialog1 = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.ForeColor = Color.Red;
            backButton.Location = new Point(412, 218);
            backButton.Margin = new Padding(2);
            backButton.Name = "backButton";
            backButton.Size = new Size(140, 45);
            backButton.TabIndex = 1;
            backButton.Text = "Back to Main View";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // fileImport
            // 
            fileImport.Location = new Point(54, 49);
            fileImport.Name = "fileImport";
            fileImport.Size = new Size(203, 140);
            fileImport.TabIndex = 2;
            fileImport.Text = "Import a Single Excel File";
            fileImport.UseVisualStyleBackColor = true;
            fileImport.Click += fileImport_Click;
            // 
            // folderImport
            // 
            folderImport.Location = new Point(298, 49);
            folderImport.Name = "folderImport";
            folderImport.Size = new Size(203, 140);
            folderImport.TabIndex = 3;
            folderImport.Text = "Import Many Files from a Folder";
            folderImport.UseVisualStyleBackColor = true;
            folderImport.Click += folderImport_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog1";
            openFileDialog2.FileOk += openFileDialog2_FileOk;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.HelpRequest += folderBrowserDialog1_HelpRequest;
            // 
            // ImportGrade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 270);
            Controls.Add(folderImport);
            Controls.Add(fileImport);
            Controls.Add(backButton);
            Margin = new Padding(2);
            Name = "ImportGrade";
            Text = "ImportGrade";
            ResumeLayout(false);
        }

        #endregion

        private Button backButton;
        private Button fileImport;
        private Button folderImport;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}