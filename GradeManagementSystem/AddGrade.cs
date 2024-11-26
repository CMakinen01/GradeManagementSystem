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
            string crseHrs = crseNum.Substring(0, 1);
            //Input validation for course number
            if (int.Parse(crseNum) < 100)
            {
                MessageBox.Show("Invalid Course Number. Please Make the number > 100.", "Course Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //search the DB, if the student does not exist, exit process
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            // Step 1: Search for the student
            try
            {
                conn.Open();
                string query = "SELECT * FROM studentInfo_Camden440 WHERE student_id = @studentID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", fixID);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Invalid Student ID. No record found.", "Invalid ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conn.Close();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching for student: " + ex.Message, "Student Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return;
            }

            // Step 2: Check for existing courses
            try
            {
                string checkCourseQuery = "SELECT * FROM courseinfo_camden440 WHERE subj_code = @subj AND crse_numb = @crse AND year = @year AND season = @season";
                MySqlCommand cmdCheckCourse = new MySqlCommand(checkCourseQuery, conn);
                cmdCheckCourse.Parameters.AddWithValue("@subj", capitalSubj);
                cmdCheckCourse.Parameters.AddWithValue("@crse", crseNum);
                cmdCheckCourse.Parameters.AddWithValue("@year", fixYear);
                cmdCheckCourse.Parameters.AddWithValue("@season", season.Text);

                using (MySqlDataReader readerCheckCourse = cmdCheckCourse.ExecuteReader())
                {
                    if (readerCheckCourse.HasRows)
                    {
                        MessageBox.Show("This course already exists.", "Course Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        conn.Close();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while checking course: " + ex.Message, "Course Check Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return;
            }

            // Step 3: Insert into courseinfo_camden440 table
            try
            {
                string insertCourseQuery = "INSERT INTO courseinfo_camden440 (subj_code, crse_numb, year, season, hours) " +
                                           "VALUES (@subj, @crse, @year, @season, @hours)";
                MySqlCommand cmdInsertCourse = new MySqlCommand(insertCourseQuery, conn);
                cmdInsertCourse.Parameters.AddWithValue("@subj", capitalSubj);
                cmdInsertCourse.Parameters.AddWithValue("@crse", crseNum);
                cmdInsertCourse.Parameters.AddWithValue("@year", fixYear);
                cmdInsertCourse.Parameters.AddWithValue("@season", season.Text);
                cmdInsertCourse.Parameters.AddWithValue("@hours", crseHrs);

                cmdInsertCourse.ExecuteNonQuery();
                MessageBox.Show("Course added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while inserting course: " + ex.Message, "Course Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return;
            }

            // Step 4: Retrieve the CRN from the courseinfo_camden440 table
            long crn = 0;
            try
            {
                string justAddedQuery = "SELECT crn FROM COURSEINFO_CAMDEN440 WHERE subj_code = @subj AND crse_numb = @crse AND year = @year AND season = @season AND hours = @hours";
                MySqlCommand cmd3 = new MySqlCommand(justAddedQuery, conn);
                cmd3.Parameters.AddWithValue("@subj", capitalSubj);
                cmd3.Parameters.AddWithValue("@crse", crseNum);
                cmd3.Parameters.AddWithValue("@year", fixYear);
                cmd3.Parameters.AddWithValue("@season", season.Text);
                cmd3.Parameters.AddWithValue("@hours", crseHrs);

                using (MySqlDataReader reader3 = cmd3.ExecuteReader())
                {
                    if (reader3.Read())
                    {
                        crn = reader3.GetInt32("crn");
                        MessageBox.Show("Retrieved CRN: " + crn.ToString(), "CRN Retrieved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while retrieving CRN: " + ex.Message, "CRN Retrieval Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return;
            }

            // Step 5: Insert into grades_camden440 table
            if (crn == 0)
            {
                MessageBox.Show("Error: Course information not found, unable to insert grade.", "Course Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return;
            }

            try
            {
                string insertGradeQuery = "INSERT INTO grades_camden440 (grade, student_id, crn) VALUES (@Grade, @StudentID, @CRN)";
                MySqlCommand cmd2 = new MySqlCommand(insertGradeQuery, conn);
                cmd2.Parameters.AddWithValue("@Grade", newGrade.Text);
                cmd2.Parameters.AddWithValue("@StudentID", fixID);
                cmd2.Parameters.AddWithValue("@CRN", crn);

                cmd2.ExecuteNonQuery();
                MessageBox.Show("Grade added successfully to grades.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while inserting grade: " + ex.Message, "Grade Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return;
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

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
//Tables:
//studentInfo_Camden440
//courseInfo_Camden440
//grades_Camden440