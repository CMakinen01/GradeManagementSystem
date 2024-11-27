using IronXL;
using Microsoft.VisualBasic.Devices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using MySqlX.XDevAPI;

namespace GradeManagementSystem
{
    public partial class ImportGrade : Form
    {
        public ImportGrade()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainView mainView = new MainView();
            mainView.Show();
            this.Close();
        }

        string fn = "";

        //method to import 1 to many files
        private void folderImport_Click(object sender, EventArgs e)
        {

        }

        //import a single file
        private void fileImport_Click(object sender, EventArgs e)
        {
            string file = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                fn = openFileDialog1.FileName;
                file = openFileDialog1.SafeFileName;
                MessageBox.Show(file);
            }
            ;
            if (!IsValidFileName(file))
            {
                MessageBox.Show("Invalid file name. \n Please ensure your file is of the format [Course prefix] [Course Number] [Year] [semester].xlsx");
                return;
            }

            var workbook = WorkBook.Load(fn);
            var workSheet = workbook.WorkSheets.First();
            var cell = workSheet["A2"];
            int RC = workSheet.Rows.Count();
            int CC = workSheet.Columns.Count();
            int studentID = 0;

           // MessageBox.Show(RC.ToString());

            string[] fileNameDetails = file.Split(' ');

            //Gather Course Info, IE Check to see if course exists 
            //MessageBox.Show(CRN.ToString());


            for (int i = 2; i <= RC; i++)
            {
                int s = -1;
                cell = workSheet[$"B{i}"];
                studentID = int.Parse(cell.StringValue);

                s = searchStudent(studentID);
                string name = workSheet[$"A{i}"].StringValue;
                if (s == -1)
                {
                    var cell2 = workSheet[$"A{i}"];
                    MessageBox.Show(cell2.StringValue + " does not yet exist, they will be added.");

                    string connStr1 = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
                    using (MySqlConnection conn1 = new MySqlConnection(connStr1))
                    {
                        conn1.Open();
                        int generatedID = 0;
                        // Insert into `studentinfo_camden440` table
                        try
                        {
                            string insertQuery = "INSERT INTO studentinfo_camden440 (student_name, student_gpa) VALUES (@studentName, 0); SELECT LAST_INSERT_ID();";
                            using (MySqlCommand cmdInsert = new MySqlCommand(insertQuery, conn1))
                            {
                                cmdInsert.Parameters.AddWithValue("@studentName", name);

                                // Retrieve the generated student_id
                                object result = cmdInsert.ExecuteScalar();
                                generatedID = Convert.ToInt32(result);
                            }

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while inserting student: " + ex.Message, "Student Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Clipboard.SetText(ex.Message);
                            conn1.Close();
                            return;
                        }

                        
                        try
                        {
                            string insertImportedIdQuery = "INSERT INTO importedid_camden440 (entered_id, student_id) VALUES (@EnteredID, @StudentID)";
                            MySqlCommand cmdInsertImportedId = new MySqlCommand(insertImportedIdQuery, conn1);
                            cmdInsertImportedId.Parameters.AddWithValue("@StudentID", generatedID);
                            cmdInsertImportedId.Parameters.AddWithValue("@EnteredID", studentID);

                            cmdInsertImportedId.ExecuteNonQuery();
                            MessageBox.Show($"Student ID {studentID} added successfully.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while inserting into imported ID table: " + ex.Message,
                                            "Import Insert Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Clipboard.SetText(ex.Message);
                            conn1.Close();
                            return;
                        }
                    }
                }



            }

            //COURSE METHOD CALL
            string subjectCode1 = fileNameDetails[0];
            string courseNumber1 = fileNameDetails[1];
            string year1 = fileNameDetails[2];
            string season1 = fileNameDetails[3].Substring(0, fileNameDetails[3].Length - 5);
            int hours1 = 3;
            InsertCourse(subjectCode1, courseNumber1, year1, season1, hours1);


            //Insertions
            for (int i = 2; i <= RC; i++)
            {
                cell = workSheet[$"B{i}"];
                studentID = int.Parse(cell.StringValue);
                cell = workSheet[$"C{i}"];
                string grade = cell.StringValue.ToUpper();

                string subjectCode = fileNameDetails[0];
                string courseNumber = fileNameDetails[1];
                string year = fileNameDetails[2];
                string season = fileNameDetails[3].Substring(0, fileNameDetails[3].Length - 5);

                int CRN = GetCRN(subjectCode, courseNumber, year, season);
                int id = 0;
                string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
                string query = "INSERT INTO grades_Camden440 (crn, grade, student_id) VALUES (@CRN, @Grade, @student_id)";


                MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    id = GetStudent(studentID);

                    MessageBox.Show(id + "  " + CRN + "  " + grade);

                    cmd.Parameters.AddWithValue("@student_id", id);//fix to get actual student_id
                    cmd.Parameters.AddWithValue("@CRN", CRN);
                    cmd.Parameters.AddWithValue("@Grade", grade);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Insert grade error per student: " + ex.Message);
                }

                updateGPA(id);
            }
        }//close import

        private bool IsValidFileName(string fileName)
        {
            string pattern1 = @"^[A-Z]{3}\s\d{3}\s\d{4}\s(Spring|Summer|Fall|Winter)\.xlsx$";
            string pattern2 = @"^[A-Z]{3}\s\d{3}[A-Z]\s\d{4}\s(Spring|Summer|Fall|Winter)\.xlsx$";

            return Regex.IsMatch(fileName, pattern1, RegexOptions.IgnoreCase) || Regex.IsMatch(fileName, pattern2, RegexOptions.IgnoreCase);
        }

        /*
        string readFile(string fn)
        {
            var workbook = WorkBook.Load(fn);
            var workSheet = workbook.WorkSheets.First();
            var cell = workSheet["A2"];
            int RC = workSheet.Rows.Count() - 1;
            int CC = workSheet.Columns.Count();
            return cell.StringValue;
        }
        */

        private int searchStudent(int studentID)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            //Search for the student
            try
            {
                conn.Open();
                string query = "SELECT * FROM studentInfo_Camden440 LEFT JOIN importedid_Camden440 ON importedid_Camden440.student_id = studentInfo_Camden440.student_id WHERE importedid_Camden440.entered_id = @StudentID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", studentID);

                //Error Handling
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        conn.Close();
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching for student: " + ex.Message, "Student Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return 0;
            }
            conn.Close();


            return 1;
        }

        private int GetStudent(int enteredID)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            //Search for the student
            try
            {
                conn.Open();
                string query = "SELECT studentInfo_Camden440.student_id FROM studentInfo_Camden440 LEFT JOIN importedid_Camden440 ON importedid_Camden440.student_id = studentInfo_Camden440.student_id WHERE importedid_Camden440.entered_id = @StudentID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@StudentID", enteredID);

                //Error Handling
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int returned = reader.GetInt32(0);
                        conn.Close();
                        return returned; //Return ID
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetStudent method error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conn.Close();
                return 0;
            }

            conn.Close();
            return -1; //No student found, this shouldnt happen as long as previous logic holds
        }



        private void updateGPA(int studentID)
        {
            //List to hold all necessary info
            List<(int hours, char grade)> courses = new List<(int hours, char grade)>();

            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT * FROM grades_Camden440 WHERE student_id = @StudentID";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);

            try
            {

                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);

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
            //MessageBox.Show(totalPoints + " " + courses);

            if (totalPoints == 0)//Avoid dividing by 0, exit
            {
                MessageBox.Show("Divide by zero");
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
                cmd.Parameters.AddWithValue("@ID", studentID);
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

        private void InsertCourse(string subjectCode, string courseNumber, string year, string season, int hours)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();

                //Check if the course exists
                string checkCourseQuery = "SELECT COUNT(CRN) FROM courseinfo_camden440 WHERE subj_code = @subj AND crse_numb = @crse AND year = @year AND season = @season";
                MySqlCommand cmdCheckCourse = new MySqlCommand(checkCourseQuery, conn);
                cmdCheckCourse.Parameters.AddWithValue("@subj", subjectCode);
                cmdCheckCourse.Parameters.AddWithValue("@crse", courseNumber);
                cmdCheckCourse.Parameters.AddWithValue("@year", year);
                cmdCheckCourse.Parameters.AddWithValue("@season", season);

                int courseCount = Convert.ToInt32(cmdCheckCourse.ExecuteScalar());

                //If the course does not exist, insert it
                if (courseCount == 0)
                {
                    string insertCourseQuery = "INSERT INTO courseinfo_camden440 (subj_code, crse_numb, year, season, hours) " +
                                               "VALUES (@subj, @crse, @year, @season, @hours)";
                    MySqlCommand cmdInsertCourse = new MySqlCommand(insertCourseQuery, conn);
                    cmdInsertCourse.Parameters.AddWithValue("@subj", subjectCode);
                    cmdInsertCourse.Parameters.AddWithValue("@crse", courseNumber);
                    cmdInsertCourse.Parameters.AddWithValue("@year", year);
                    cmdInsertCourse.Parameters.AddWithValue("@season", season);
                    cmdInsertCourse.Parameters.AddWithValue("@hours", hours);

                    cmdInsertCourse.ExecuteNonQuery();

                    MessageBox.Show("Course inserted successfully.");
                }
                else
                {
                    MessageBox.Show("Course already exists.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while inserting course: " + ex.Message, "Course Insert Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            conn.Close();
            
        }


        private int GetCRN(string subjectCode, string courseNumber, string year, string season)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT CRN FROM courseinfo_camden440 WHERE subj_code = @subj AND crse_numb = @crse AND year = @year AND season = @season";

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@subj", subjectCode);
                    cmd.Parameters.AddWithValue("@crse", courseNumber);
                    cmd.Parameters.AddWithValue("@year", year);
                    cmd.Parameters.AddWithValue("@season", season);

                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return -1; // CRN not found
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while fetching CRN: " + ex.Message, "CRN Fetch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1; // Error in fetching CRN
                }
            }
        }


    }
}