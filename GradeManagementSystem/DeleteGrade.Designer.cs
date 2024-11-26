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
            // deleteGradeButton
            // 
            deleteGradeButton.Location = new Point(253, 34);
            deleteGradeButton.Name = "deleteGradeButton";
            deleteGradeButton.Size = new Size(108, 34);
            deleteGradeButton.TabIndex = 27;
            deleteGradeButton.Text = "Delete";
            deleteGradeButton.UseVisualStyleBackColor = true;
            // 
            // DeleteGrade
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(deleteGradeButton);
            Controls.Add(showClasses);
            Controls.Add(label3);
            Controls.Add(studentID);
            Controls.Add(backButton);
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
    }
}