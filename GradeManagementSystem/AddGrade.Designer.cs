using System.Diagnostics;

namespace GradeManagementSystem
{
    partial class AddGrade
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
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            crseNumb = new MaskedTextBox();
            subjCode = new MaskedTextBox();
            studentID = new MaskedTextBox();
            newGrade = new ComboBox();
            season = new ComboBox();
            year = new MaskedTextBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            showClasses = new Button();
            addGradeButton = new Button();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.ForeColor = Color.Red;
            backButton.Location = new Point(588, 363);
            backButton.Name = "backButton";
            backButton.Size = new Size(200, 75);
            backButton.TabIndex = 0;
            backButton.Text = "Back to Main View";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 15);
            label3.Name = "label3";
            label3.Size = new Size(145, 25);
            label3.TabIndex = 15;
            label3.Text = "Enter Student ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 81);
            label2.Name = "label2";
            label2.Size = new Size(166, 25);
            label2.TabIndex = 14;
            label2.Text = "Enter Subject Code:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 153);
            label1.Name = "label1";
            label1.Size = new Size(186, 25);
            label1.TabIndex = 13;
            label1.Text = "Enter Course Number:";
            // 
            // crseNumb
            // 
            crseNumb.Location = new Point(12, 181);
            crseNumb.Mask = "000";
            crseNumb.Name = "crseNumb";
            crseNumb.Size = new Size(30, 31);
            crseNumb.TabIndex = 12;
            // 
            // subjCode
            // 
            subjCode.Location = new Point(12, 109);
            subjCode.Mask = "LLL";
            subjCode.Name = "subjCode";
            subjCode.Size = new Size(30, 31);
            subjCode.TabIndex = 11;
            // 
            // studentID
            // 
            studentID.CausesValidation = false;
            studentID.Location = new Point(12, 43);
            studentID.Mask = "000000000";
            studentID.Name = "studentID";
            studentID.Size = new Size(77, 31);
            studentID.TabIndex = 10;
            // 
            // newGrade
            // 
            newGrade.FormattingEnabled = true;
            newGrade.Items.AddRange(new object[] { "A", "B", "C", "D", "F" });
            newGrade.Location = new Point(12, 385);
            newGrade.Name = "newGrade";
            newGrade.Size = new Size(118, 33);
            newGrade.TabIndex = 16;
            // 
            // season
            // 
            season.FormattingEnabled = true;
            season.Items.AddRange(new object[] { "Fall", "Winter", "Spring", "Summer" });
            season.Location = new Point(12, 310);
            season.Name = "season";
            season.Size = new Size(118, 33);
            season.TabIndex = 17;
            // 
            // year
            // 
            year.Location = new Point(12, 243);
            year.Mask = "0000";
            year.Name = "year";
            year.Size = new Size(40, 31);
            year.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 215);
            label4.Name = "label4";
            label4.Size = new Size(93, 25);
            label4.TabIndex = 19;
            label4.Text = "Enter Year:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 277);
            label5.Name = "label5";
            label5.Size = new Size(118, 25);
            label5.TabIndex = 20;
            label5.Text = "Enter Season:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 346);
            label6.Name = "label6";
            label6.Size = new Size(108, 25);
            label6.TabIndex = 21;
            label6.Text = "Enter Grade:";
            // 
            // showClasses
            // 
            showClasses.Location = new Point(95, 41);
            showClasses.Name = "showClasses";
            showClasses.Size = new Size(152, 34);
            showClasses.TabIndex = 22;
            showClasses.Text = "Find Grades";
            showClasses.UseVisualStyleBackColor = true;
            // 
            // addGradeButton
            // 
            addGradeButton.Location = new Point(147, 385);
            addGradeButton.Name = "addGradeButton";
            addGradeButton.Size = new Size(112, 34);
            addGradeButton.TabIndex = 23;
            addGradeButton.Text = "Submit";
            addGradeButton.UseVisualStyleBackColor = true;
            // 
            // AddGrade
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(addGradeButton);
            Controls.Add(showClasses);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(year);
            Controls.Add(season);
            Controls.Add(newGrade);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(crseNumb);
            Controls.Add(subjCode);
            Controls.Add(studentID);
            Controls.Add(backButton);
            Name = "AddGrade";
            Text = "AddGrade";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button backButton;
        private Label label3;
        private Label label2;
        private Label label1;
        private MaskedTextBox crseNumb;
        private MaskedTextBox subjCode;
        private MaskedTextBox studentID;
        private ComboBox newGrade;
        private ComboBox season;
        private MaskedTextBox year;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button showClasses;
        private Button addGradeButton;
    }
}