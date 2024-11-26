namespace GradeManagementSystem
{
    partial class MainView
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            addGradeButton = new Button();
            editGradeButton = new Button();
            deleteGradeButton = new Button();
            printButton = new Button();
            importButton = new Button();
            SuspendLayout();
            // 
            // addGradeButton
            // 
            addGradeButton.Location = new Point(286, 105);
            addGradeButton.Name = "addGradeButton";
            addGradeButton.Size = new Size(200, 75);
            addGradeButton.TabIndex = 0;
            addGradeButton.Text = "Add a Single Grade";
            addGradeButton.UseVisualStyleBackColor = true;
            addGradeButton.Click += this.addGradeButton_Click;
            // 
            // editGradeButton
            // 
            editGradeButton.Location = new Point(286, 186);
            editGradeButton.Name = "editGradeButton";
            editGradeButton.Size = new Size(200, 75);
            editGradeButton.TabIndex = 1;
            editGradeButton.Text = "Edit a Single Grade";
            editGradeButton.UseVisualStyleBackColor = true;
            editGradeButton.Click += this.editGradeButton_Click;
            // 
            // deleteGradeButton
            // 
            deleteGradeButton.Location = new Point(286, 267);
            deleteGradeButton.Name = "deleteGradeButton";
            deleteGradeButton.Size = new Size(200, 75);
            deleteGradeButton.TabIndex = 2;
            deleteGradeButton.Text = "Delete a Single Grade";
            deleteGradeButton.UseVisualStyleBackColor = true;
            deleteGradeButton.Click += this.deleteGradeButton_Click;
            // 
            // printButton
            // 
            printButton.Location = new Point(286, 348);
            printButton.Name = "printButton";
            printButton.Size = new Size(200, 75);
            printButton.TabIndex = 3;
            printButton.Text = "Print Transcript";
            printButton.UseVisualStyleBackColor = true;
            printButton.Click += this.printButton_Click;
            // 
            // importButton
            // 
            importButton.Location = new Point(286, 24);
            importButton.Name = "importButton";
            importButton.Size = new Size(200, 75);
            importButton.TabIndex = 4;
            importButton.Text = "Import Grades";
            importButton.UseVisualStyleBackColor = true;
            importButton.Click += this.importButton_Click;
            // 
            // MainView
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(importButton);
            Controls.Add(printButton);
            Controls.Add(deleteGradeButton);
            Controls.Add(editGradeButton);
            Controls.Add(addGradeButton);
            Name = "MainView";
            Text = "Main View";
            ResumeLayout(false);
        }

        #endregion

        private Button addGradeButton;
        private Button editGradeButton;
        private Button deleteGradeButton;
        private Button printButton;
        private Button importButton;
    }
}
