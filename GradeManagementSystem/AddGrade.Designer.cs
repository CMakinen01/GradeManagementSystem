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
            allGrades = new TextBox();
            hours = new MaskedTextBox();
            label7 = new Label();
            SuspendLayout();
            // 
            // backButton
            // 
            backButton.ForeColor = Color.Red;
            backButton.Location = new Point(779, 292);
            backButton.Margin = new Padding(2, 3, 2, 3);
            backButton.Name = "backButton";
            backButton.Size = new Size(160, 60);
            backButton.TabIndex = 0;
            backButton.Text = "Back to Main View";
            backButton.UseVisualStyleBackColor = true;
            backButton.Click += backButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 12);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(120, 20);
            label3.TabIndex = 15;
            label3.Text = "Enter Student ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 65);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(138, 20);
            label2.TabIndex = 14;
            label2.Text = "Enter Subject Code:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 123);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(153, 20);
            label1.TabIndex = 13;
            label1.Text = "Enter Course Number:";
            // 
            // crseNumb
            // 
            crseNumb.Location = new Point(9, 145);
            crseNumb.Margin = new Padding(2, 3, 2, 3);
            crseNumb.Mask = "000L";
            crseNumb.Name = "crseNumb";
            crseNumb.Size = new Size(33, 27);
            crseNumb.TabIndex = 12;
            // 
            // subjCode
            // 
            subjCode.Location = new Point(9, 87);
            subjCode.Margin = new Padding(2, 3, 2, 3);
            subjCode.Mask = "LLL";
            subjCode.Name = "subjCode";
            subjCode.Size = new Size(33, 27);
            subjCode.TabIndex = 11;
            // 
            // studentID
            // 
            studentID.CausesValidation = false;
            studentID.Location = new Point(9, 35);
            studentID.Margin = new Padding(2, 3, 2, 3);
            studentID.Mask = "000000000";
            studentID.Name = "studentID";
            studentID.Size = new Size(62, 27);
            studentID.TabIndex = 10;
            // 
            // newGrade
            // 
            newGrade.DropDownStyle = ComboBoxStyle.DropDownList;
            newGrade.FormattingEnabled = true;
            newGrade.Items.AddRange(new object[] { "A", "B", "C", "D", "F" });
            newGrade.Location = new Point(9, 308);
            newGrade.Margin = new Padding(2, 3, 2, 3);
            newGrade.Name = "newGrade";
            newGrade.Size = new Size(95, 28);
            newGrade.TabIndex = 16;
            // 
            // season
            // 
            season.DropDownStyle = ComboBoxStyle.DropDownList;
            season.FormattingEnabled = true;
            season.Items.AddRange(new object[] { "Fall", "Winter", "Spring", "Summer" });
            season.Location = new Point(9, 248);
            season.Margin = new Padding(2, 3, 2, 3);
            season.Name = "season";
            season.Size = new Size(95, 28);
            season.TabIndex = 17;
            // 
            // year
            // 
            year.Location = new Point(9, 195);
            year.Margin = new Padding(2, 3, 2, 3);
            year.Mask = "0000";
            year.Name = "year";
            year.Size = new Size(33, 27);
            year.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 172);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(78, 20);
            label4.TabIndex = 19;
            label4.Text = "Enter Year:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 221);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 20;
            label5.Text = "Enter Season:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 281);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(90, 20);
            label6.TabIndex = 21;
            label6.Text = "Enter Grade:";
            // 
            // showClasses
            // 
            showClasses.Location = new Point(75, 33);
            showClasses.Margin = new Padding(2, 3, 2, 3);
            showClasses.Name = "showClasses";
            showClasses.Size = new Size(121, 27);
            showClasses.TabIndex = 22;
            showClasses.Text = "Find Grades";
            showClasses.UseVisualStyleBackColor = true;
            showClasses.Click += showClasses_Click;
            // 
            // addGradeButton
            // 
            addGradeButton.Location = new Point(118, 308);
            addGradeButton.Margin = new Padding(2, 3, 2, 3);
            addGradeButton.Name = "addGradeButton";
            addGradeButton.Size = new Size(89, 27);
            addGradeButton.TabIndex = 23;
            addGradeButton.Text = "Submit";
            addGradeButton.UseVisualStyleBackColor = true;
            addGradeButton.Click += addGradeButton_Click;
            // 
            // allGrades
            // 
            allGrades.Location = new Point(247, 35);
            allGrades.Margin = new Padding(3, 4, 3, 4);
            allGrades.Multiline = true;
            allGrades.Name = "allGrades";
            allGrades.ReadOnly = true;
            allGrades.ScrollBars = ScrollBars.Both;
            allGrades.Size = new Size(692, 243);
            allGrades.TabIndex = 24;
            // 
            // hours
            // 
            hours.Location = new Point(118, 248);
            hours.Margin = new Padding(3, 4, 3, 4);
            hours.Mask = "0";
            hours.Name = "hours";
            hours.Size = new Size(47, 27);
            hours.TabIndex = 25;
            hours.MaskInputRejected += hours_MaskInputRejected;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(118, 221);
            label7.Name = "label7";
            label7.Size = new Size(89, 20);
            label7.TabIndex = 26;
            label7.Text = "Enter Hours:";
            label7.Click += label7_Click;
            // 
            // AddGrade
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 360);
            Controls.Add(label7);
            Controls.Add(hours);
            Controls.Add(allGrades);
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
            Margin = new Padding(2, 3, 2, 3);
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
        private TextBox allGrades;
        private MaskedTextBox hours;
        private Label label7;
    }
}