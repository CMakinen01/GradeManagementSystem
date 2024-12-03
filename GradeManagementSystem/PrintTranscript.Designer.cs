namespace GradeManagementSystem
{
    partial class PrintTranscript
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
            showClasses = new Button();
            label3 = new Label();
            studentID = new MaskedTextBox();
            printTranscriptButton = new Button();
            allGrades = new TextBox();
            getAllGrades = new Button();
            saveFileDialog1 = new SaveFileDialog();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.ForeColor = Color.Red;
            backButton.Location = new Point(683, 218);
            backButton.Margin = new Padding(2);
            backButton.Name = "backButton";
            backButton.Size = new Size(140, 45);
            backButton.TabIndex = 2;
            backButton.Text = "Back to Main View";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // showClasses
            // 
            showClasses.Location = new Point(66, 21);
            showClasses.Margin = new Padding(2);
            showClasses.Name = "showClasses";
            showClasses.Size = new Size(106, 20);
            showClasses.TabIndex = 25;
            showClasses.Text = "Find Grades";
            showClasses.UseVisualStyleBackColor = true;
            showClasses.Click += showClasses_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 5);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 24;
            label3.Text = "Enter Student ID:";
            // 
            // studentID
            // 
            studentID.CausesValidation = false;
            studentID.Location = new Point(8, 22);
            studentID.Margin = new Padding(2);
            studentID.Mask = "000000000";
            studentID.Name = "studentID";
            studentID.Size = new Size(55, 23);
            studentID.TabIndex = 23;
            // 
            // printTranscriptButton
            // 
            printTranscriptButton.Location = new Point(8, 218);
            printTranscriptButton.Margin = new Padding(2);
            printTranscriptButton.Name = "printTranscriptButton";
            printTranscriptButton.Size = new Size(140, 45);
            printTranscriptButton.TabIndex = 26;
            printTranscriptButton.Text = "Print Transcript";
            printTranscriptButton.UseVisualStyleBackColor = true;
            printTranscriptButton.Click += printTranscriptButton_Click;
            // 
            // allGrades
            // 
            allGrades.Location = new Point(216, 30);
            allGrades.Multiline = true;
            allGrades.Name = "allGrades";
            allGrades.ReadOnly = true;
            allGrades.ScrollBars = ScrollBars.Both;
            allGrades.Size = new Size(606, 183);
            allGrades.TabIndex = 30;
            // 
            // getAllGrades
            // 
            getAllGrades.Location = new Point(66, 46);
            getAllGrades.Name = "getAllGrades";
            getAllGrades.Size = new Size(106, 23);
            getAllGrades.TabIndex = 31;
            getAllGrades.Text = "See all Grades";
            getAllGrades.UseVisualStyleBackColor = true;
            getAllGrades.Click += getAllGrades_Click;
            // 
            // PrintTranscript
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 270);
            Controls.Add(getAllGrades);
            Controls.Add(allGrades);
            Controls.Add(printTranscriptButton);
            Controls.Add(showClasses);
            Controls.Add(label3);
            Controls.Add(studentID);
            Controls.Add(backButton);
            Margin = new Padding(2);
            Name = "PrintTranscript";
            Text = "PrintTranscript";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backButton;
        private Button showClasses;
        private Label label3;
        private MaskedTextBox studentID;
        private Button printTranscriptButton;
        private TextBox allGrades;
        private Button getAllGrades;
        private SaveFileDialog saveFileDialog1;
    }
}