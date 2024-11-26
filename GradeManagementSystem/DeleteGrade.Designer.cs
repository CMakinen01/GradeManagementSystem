namespace GradeManagementSystem
{
    partial class DeleteGrade
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
            deleteGradeButton = new Button();
            allGrades = new TextBox();
            enteredCRN = new MaskedTextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.ForeColor = Color.Red;
            backButton.Location = new Point(583, 214);
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
            studentID.MaskInputRejected += studentID_MaskInputRejected;
            // 
            // deleteGradeButton
            // 
            deleteGradeButton.Location = new Point(68, 74);
            deleteGradeButton.Margin = new Padding(2);
            deleteGradeButton.Name = "deleteGradeButton";
            deleteGradeButton.Size = new Size(104, 20);
            deleteGradeButton.TabIndex = 27;
            deleteGradeButton.Text = "Delete";
            deleteGradeButton.UseVisualStyleBackColor = true;
            deleteGradeButton.Click += deleteGradeButton_Click;
            // 
            // allGrades
            // 
            allGrades.Location = new Point(216, 26);
            allGrades.Multiline = true;
            allGrades.Name = "allGrades";
            allGrades.ReadOnly = true;
            allGrades.ScrollBars = ScrollBars.Both;
            allGrades.Size = new Size(506, 183);
            allGrades.TabIndex = 28;
            // 
            // enteredCRN
            // 
            enteredCRN.Location = new Point(8, 71);
            enteredCRN.Mask = "000000000";
            enteredCRN.Name = "enteredCRN";
            enteredCRN.Size = new Size(55, 23);
            enteredCRN.TabIndex = 29;
            enteredCRN.MaskInputRejected += enteredCRN_MaskInputRejected;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 53);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 30;
            label1.Text = "Enter CRN:";
            label1.Click += label1_Click;
            // 
            // DeleteGrade
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 270);
            Controls.Add(label1);
            Controls.Add(enteredCRN);
            Controls.Add(allGrades);
            Controls.Add(deleteGradeButton);
            Controls.Add(showClasses);
            Controls.Add(label3);
            Controls.Add(studentID);
            Controls.Add(backButton);
            Margin = new Padding(2);
            Name = "DeleteGrade";
            Text = "DeleteGrade";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backButton;
        private Button showClasses;
        private Label label3;
        private MaskedTextBox studentID;
        private Button deleteGradeButton;
        private TextBox allGrades;
        private MaskedTextBox enteredCRN;
        private Label label1;
    }
}