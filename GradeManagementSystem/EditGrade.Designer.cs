namespace GradeManagementSystem
{
    partial class EditGrade
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
            editGradeButton = new Button();
            label6 = new Label();
            newGrade = new ComboBox();
            allGrades = new TextBox();
            enteredCRN = new MaskedTextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.ForeColor = Color.Red;
            backButton.Location = new Point(781, 285);
            backButton.Margin = new Padding(2, 3, 2, 3);
            backButton.Name = "backButton";
            backButton.Size = new Size(160, 60);
            backButton.TabIndex = 2;
            backButton.Text = "Back to Main View";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // showClasses
            // 
            showClasses.Location = new Point(75, 28);
            showClasses.Margin = new Padding(2, 3, 2, 3);
            showClasses.Name = "showClasses";
            showClasses.Size = new Size(121, 27);
            showClasses.TabIndex = 25;
            showClasses.Text = "Find Grades";
            showClasses.UseVisualStyleBackColor = true;
            showClasses.Click += showClasses_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 7);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(120, 20);
            label3.TabIndex = 24;
            label3.Text = "Enter Student ID:";
            // 
            // studentID
            // 
            studentID.CausesValidation = false;
            studentID.Location = new Point(9, 29);
            studentID.Margin = new Padding(2, 3, 2, 3);
            studentID.Mask = "000000000";
            studentID.Name = "studentID";
            studentID.Size = new Size(62, 27);
            studentID.TabIndex = 23;
            studentID.MaskInputRejected += studentID_MaskInputRejected;
            // 
            // editGradeButton
            // 
            editGradeButton.Location = new Point(110, 157);
            editGradeButton.Margin = new Padding(2, 3, 2, 3);
            editGradeButton.Name = "editGradeButton";
            editGradeButton.Size = new Size(87, 27);
            editGradeButton.TabIndex = 26;
            editGradeButton.Text = "Edit";
            editGradeButton.UseVisualStyleBackColor = true;
            editGradeButton.Click += editGradeButton_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 131);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(124, 20);
            label6.TabIndex = 28;
            label6.Text = "Enter New Grade:";
            // 
            // newGrade
            // 
            newGrade.DropDownStyle = ComboBoxStyle.DropDownList;
            newGrade.FormattingEnabled = true;
            newGrade.Items.AddRange(new object[] { "A", "B", "C", "D", "F" });
            newGrade.Location = new Point(9, 153);
            newGrade.Margin = new Padding(2, 3, 2, 3);
            newGrade.Name = "newGrade";
            newGrade.Size = new Size(95, 28);
            newGrade.TabIndex = 27;
            // 
            // allGrades
            // 
            allGrades.Location = new Point(248, 16);
            allGrades.Margin = new Padding(3, 4, 3, 4);
            allGrades.Multiline = true;
            allGrades.Name = "allGrades";
            allGrades.ReadOnly = true;
            allGrades.ScrollBars = ScrollBars.Both;
            allGrades.Size = new Size(691, 243);
            allGrades.TabIndex = 29;
            // 
            // enteredCRN
            // 
            enteredCRN.Location = new Point(9, 96);
            enteredCRN.Margin = new Padding(3, 4, 3, 4);
            enteredCRN.Mask = "000000000";
            enteredCRN.Name = "enteredCRN";
            enteredCRN.Size = new Size(62, 27);
            enteredCRN.TabIndex = 30;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 72);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(79, 20);
            label1.TabIndex = 31;
            label1.Text = "Enter CRN:";
            // 
            // EditGrade
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 360);
            Controls.Add(label1);
            Controls.Add(enteredCRN);
            Controls.Add(allGrades);
            Controls.Add(label6);
            Controls.Add(newGrade);
            Controls.Add(editGradeButton);
            Controls.Add(showClasses);
            Controls.Add(label3);
            Controls.Add(studentID);
            Controls.Add(backButton);
            Margin = new Padding(2, 3, 2, 3);
            Name = "EditGrade";
            Text = "EditGrade";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backButton;
        private Button showClasses;
        private Label label3;
        private MaskedTextBox studentID;
        private Button editGradeButton;
        private Label label6;
        private ComboBox newGrade;
        private TextBox allGrades;
        private MaskedTextBox enteredCRN;
        private Label label1;
    }
}