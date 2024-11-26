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
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.ForeColor = Color.Red;
            backButton.Location = new Point(588, 363);
            backButton.Name = "backButton";
            backButton.Size = new Size(200, 75);
            backButton.TabIndex = 2;
            backButton.Text = "Back to Main View";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // showClasses
            // 
            showClasses.Location = new Point(95, 35);
            showClasses.Name = "showClasses";
            showClasses.Size = new Size(152, 34);
            showClasses.TabIndex = 25;
            showClasses.Text = "Find Grades";
            showClasses.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(145, 25);
            label3.TabIndex = 24;
            label3.Text = "Enter Student ID:";
            // 
            // studentID
            // 
            studentID.CausesValidation = false;
            studentID.Location = new Point(12, 37);
            studentID.Mask = "000000000";
            studentID.Name = "studentID";
            studentID.Size = new Size(77, 31);
            studentID.TabIndex = 23;
            // 
            // editGradeButton
            // 
            editGradeButton.Location = new Point(136, 116);
            editGradeButton.Name = "editGradeButton";
            editGradeButton.Size = new Size(108, 34);
            editGradeButton.TabIndex = 26;
            editGradeButton.Text = "Edit";
            editGradeButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 77);
            label6.Name = "label6";
            label6.Size = new Size(108, 25);
            label6.TabIndex = 28;
            label6.Text = "Enter Grade:";
            // 
            // newGrade
            // 
            newGrade.FormattingEnabled = true;
            newGrade.Items.AddRange(new object[] { "A", "B", "C", "D", "F" });
            newGrade.Location = new Point(12, 116);
            newGrade.Name = "newGrade";
            newGrade.Size = new Size(118, 33);
            newGrade.TabIndex = 27;
            // 
            // EditGrade
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(newGrade);
            Controls.Add(editGradeButton);
            Controls.Add(showClasses);
            Controls.Add(label3);
            Controls.Add(studentID);
            Controls.Add(backButton);
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
    }
}