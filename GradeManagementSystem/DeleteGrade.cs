using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeManagementSystem
{
    public partial class DeleteGrade : Form
    {
        public DeleteGrade()
        {
            InitializeComponent();
            SeeAll();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainView mainView = new MainView();
            mainView.Show();
            this.Close();
        }

        private void showClasses_Click(object sender, EventArgs e)
        {
            string fixID = studentID.Text.Replace(" ", "");
            //search the DB, if the student does not exist, exit process
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT * FROM studentInfo_Camden440 LEFT JOIN grades_Camden440 ON studentInfo_Camden440.student_id = grades_Camden440.student_id LEFT JOIN courseInfo_Camden440 ON grades_Camden440.crn = courseInfo_Camden440.crn LEFT JOIN importedid_Camden440 ON importedid_Camden440.student_id = studentInfo_Camden440.student_id WHERE studentInfo_Camden440.student_id = @studentID";
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

                        sb.AppendLine($"ID: {reader.GetInt32(0)}    Excel ID: {reader.GetInt32(12)}    Name: {reader.GetString(1)}  GPA: {reader.GetDouble(2)}    Course: {reader.GetString(7)} {reader.GetString(8)}     Taken: {reader.GetString(10)} {reader.GetInt16(9)}");
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

        private void studentID_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }




        private void updateGPA()
        {
            //List to hold all necessary info
            List<(int hours, char grade)> courses = new List<(int hours, char grade)>();
            string fixID = studentID.Text.Replace(" ", "");

            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT* FROM grades_Camden440 WHERE student_id = @StudentID";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", fixID);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int crn = reader.GetInt32(reader.GetOrdinal("crn"));
                            char grade = reader.GetChar(reader.GetOrdinal("grade"));

                            //Get course hours for each CRN
                            int hours = 0;
                            string queryHours = "SELECT hours FROM courseInfo_Camden440 WHERE crn = @CRN";

                            using (MySqlConnection connInner = new MySqlConnection(connStr))
                            {
                                connInner.Open();

                                using (MySqlCommand cmdHours = new MySqlCommand(queryHours, connInner))
                                {
                                    cmdHours.Parameters.AddWithValue("@CRN", crn);
                                    using (MySqlDataReader readerHrs = cmdHours.ExecuteReader())
                                    {
                                        if (readerHrs.Read())
                                        {
                                            hours = readerHrs.GetInt32(readerHrs.GetOrdinal("hours"));
                                        }
                                    }
                                }
                            }
                            // Add to course list
                            courses.Add((hours, grade));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            conn.Close();

            //Math to calculate GPA
            double totalHours = 0;
            double totalPoints = 0;
            foreach ((int hours, char grade) course in courses)
            {
                switch (course.grade)
                {
                    case 'A':
                        totalPoints += course.hours * 4.0;
                        break;
                    case 'B':
                        totalPoints += course.hours * 3.0;
                        break;
                    case 'C':
                        totalPoints += course.hours * 2.0;
                        break;
                    case 'D':
                        totalPoints += course.hours * 1.0;
                        break;
                    case 'F':
                        totalPoints += course.hours * 0;
                        break;
                }
                totalHours += course.hours;
            }

            if (totalPoints == 0)//Avoid dividing by 0, exit
            {
                MessageBox.Show("divide by zero");
                return;
            }
            //Round GPA to hundredths place for visual clarity
            double updatedGPA = Math.Round(totalPoints / totalHours, 2);
            double GPA = updatedGPA;

            //Update table(s)
            MessageBox.Show("GPA: " + updatedGPA);
            query = "UPDATE studentInfo_Camden440 SET student_GPA = @GPA WHERE student_id = @ID";
            try
            {

                Console.WriteLine("Connecting to MySQL...");
                conn.Open();


                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", fixID);
                cmd.Parameters.AddWithValue("@GPA", GPA);
                cmd.ExecuteNonQuery();
                MessageBox.Show("GPA updated successfully");


            }
            catch (Exception ex)//error handling
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
            conn.Close();


        }

        private void deleteGradeButton_Click(object sender, EventArgs e)
        {
            string fixID = studentID.Text.Replace(" ", "");
            string fixCRN = enteredCRN.Text.Replace(" ", "");

            //Check for student existence
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            //Search for the student
            try
            {
                conn.Open();
                string query = "SELECT * FROM studentInfo_Camden440 WHERE student_id = @studentID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", fixID);

                //Error Handling
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
            conn.Close();


            //check for course existence
            string connStr2 = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn2 = new MySql.Data.MySqlClient.MySqlConnection(connStr2);

            //Search for the course
            try
            {
                conn2.Open();
                string query2 = "SELECT * FROM grades_Camden440 WHERE crn = @crn";
                MySqlCommand cmd2 = new MySqlCommand(query2, conn2);
                cmd2.Parameters.AddWithValue("@crn", fixCRN);

                //Error Handling
                using (MySqlDataReader reader = cmd2.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Invalid Course ID. No record found.", "Invalid ID Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        conn2.Close();
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching for course: " + ex.Message, "Course Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn2.Close();
                return;
            }

            //deleteQuery
            try
            {
                conn.Open();
                string deleteCourseQuery = "DELETE FROM grades_Camden440 WHERE CRN = @CRN";
                MySqlCommand cmdDeleteCourse = new MySqlCommand(deleteCourseQuery, conn);
                cmdDeleteCourse.Parameters.AddWithValue("@CRN", fixCRN);

                cmdDeleteCourse.ExecuteNonQuery();
                MessageBox.Show("Course Deleted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while Deleting course: " + ex.Message, "Course Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return;
            }

            //update GPA
            updateGPA();

            refreshTable();





        }


        private void refreshTable()
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

                        sb.AppendLine($"ID: {reader.GetInt32(0)}    CRN: {reader.GetInt32(3)}    Name: {reader.GetString(1)}  GPA: {reader.GetDouble(2)}    Course: {reader.GetString(7)} {reader.GetString(8)}     Taken: {reader.GetString(10)} {reader.GetInt16(9)}");
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

        private void enteredCRN_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void SeeAll()
        {
            string fixID = studentID.Text.Replace(" ", "");
            //search the DB, if the student does not exist, exit process
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT * FROM studentInfo_Camden440 LEFT JOIN importedid_Camden440 ON importedid_Camden440.student_id = studentInfo_Camden440.student_id ";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    StringBuilder sb = new StringBuilder();

                    while (reader.Read())
                    {

                        sb.AppendLine($"ID: {reader.GetInt32(0)}    Excel ID: {reader.GetInt32(3)}         Name: {reader.GetString(1)}");
                    }
                    reader.Close();
                    allGrades.Text = sb.ToString();
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Clipboard.SetText(ex.ToString());
            }
        }
    }




}
