using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace GradeManagementSystem
{
    public partial class AddGrade : Form
    {
        public AddGrade()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainView mainView = new MainView();
            mainView.Show();
            this.Close();
        }

        private void addGradeButton_Click(object sender, EventArgs e)
        {
            //handling misuse of maskedTextBoxes
            string fixNum = crseNumb.Text.Replace(" ", "");
            string fixYear = year.Text.Replace(" ", "");
            string fixID = studentID.Text.Replace(" ", "");
            string crseNum = fixNum.Substring(0, 3);
            string capitalSubj = subjCode.Text.ToUpper();


            //Input validation for course number
            if (int.Parse(crseNum) < 100)
            {
                MessageBox.Show("Invalid Course Number. Please Make the number > 100.", "Course Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //search the DB, if the student does not exist, exit process
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT * FROM studentInfo_Camden440 WHERE student_id = @studentID";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", fixID);
                cmd.Parameters.AddWithValue("@Grade", newGrade.Text);
                cmd.ExecuteNonQuery();



                MessageBox.Show("Grade added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("A Grade Already Exists for this Class.", "Duplicate Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();


        }//close button

        private void showClasses_Click(object sender, EventArgs e)
        {
            string fixID = studentID.Text.Replace(" ", "");
            //search the DB, if the student does not exist, exit process
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT * FROM studentInfo_Camden440 LEFT JOIN grades_Camden440 ON studentInfo_Camden440.student_id = grades_Camden440.student_id LEFT JOIN courseInfo_Camden440 ON grades_Camden440.crn = courseInfo_Camden440.crn WHERE studentInfo_Camden440.student_id = @studentID";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", fixID);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    StringBuilder sb = new StringBuilder();

                    while (reader.Read())
                    {

                        sb.AppendLine($"ID: {reader.GetInt32(0)}    Name: {reader.GetString(1)}  GPA: {reader.GetDouble(2)}    Course: {reader.GetString(7)} {reader.GetString(8)}     Taken: {reader.GetString(10)} {reader.GetInt16(9)}");
                    }
                    reader.Close();
                    allGrades.Text = sb.ToString();
                }
                



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conn.Close();
        }
    }
}
//Tables:
//studentInfo_Camden440
//courseInfo_Camden440
//grades_Camden440