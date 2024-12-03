using iTextSharp.text.pdf;
using iTextSharp.text;
using MySql.Data.MySqlClient;
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
    public partial class PrintTranscript : Form
    {
        public PrintTranscript()
        {
            InitializeComponent();
            SeeAll();
        }
        private void PrintTranscript_Load(object sender, EventArgs e)
        {
            SeeAll();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            MainView mainView = new MainView();
            mainView.Show();
            this.Close();
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

                        sb.AppendLine($"ID: {reader.GetInt32(0)}    CRN: {reader.GetInt32(3)}    Name: {reader.GetString(1)}  GPA: {reader.GetDouble(2)}    Course: {reader.GetString(7)} {reader.GetString(8)}     Grade: {reader.GetString(4)}");
                    }
                    reader.Close();
                    allGrades.Text = sb.ToString();
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void showClasses_Click(object sender, EventArgs e)
        {
            refreshTable();
        }

        private void getAllGrades_Click(object sender, EventArgs e)
        {
            SeeAll();
        }




        private void transcript(int studentID)
        {
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            string query = "SELECT studentInfo_Camden440.student_id, studentInfo_Camden440.student_name, studentInfo_Camden440.student_gpa, " +
                              "courseInfo_Camden440.subj_code, courseInfo_Camden440.crse_numb, grades_Camden440.grade, importedid_Camden440.entered_id, courseInfo_Camden440.hours " +
                              "FROM studentInfo_Camden440 " +
                              "LEFT JOIN grades_Camden440 ON studentInfo_Camden440.student_id = grades_Camden440.student_id " +
                              "LEFT JOIN courseInfo_Camden440 ON grades_Camden440.crn = courseInfo_Camden440.crn " +
                              "LEFT JOIN importedid_Camden440 on importedid_Camden440.student_id = studentInfo_Camden440.student_id " +
                              "WHERE studentInfo_Camden440.student_id = @studentID";
            string studentName = "";
            string studentGPA = "";
            string id = "";
            List<string[]> courses = new List<string[]>();//holds courses

            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Save the Student's Transcript"
            };

            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string file = saveFileDialog1.FileName;

            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("No grades for Student");//edge case handling
                            return;
                        }

                        while (reader.Read())
                        {
                            if (string.IsNullOrEmpty(studentName))//retrieve student info only once, to avoid duplicate entries
                            {
                                studentName = reader["student_name"].ToString();
                                studentGPA = reader["student_gpa"].ToString();
                                id = reader["entered_id"].ToString();
                            }
                            courses.Add(new string[]
                            {
                                reader["subj_code"].ToString(),
                                reader["crse_numb"].ToString(),
                                reader["grade"].ToString(),
                                reader["hours"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while making transcript: " + ex.Message);
                    Clipboard.SetText(ex.ToString());
                    return;
                }
            }
            //If for some reason a student doesnt have an Excel imported id, set to database id
            if(id == "")
            {
                id = studentID.ToString();
            }

            //Create the PDF
            try
            {
                using (FileStream fs = new FileStream(file, FileMode.Create))
                {
                    Document pdf = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(pdf, fs);
                    pdf.Open();

                    pdf.Add(new Paragraph($"Grade Management System Transcript", FontFactory.GetFont(FontFactory.TIMES_BOLD, 16)));
                    pdf.Add(new Paragraph($"Student ID: {id}"));
                    pdf.Add(new Paragraph($"Student Name: {studentName}"));
                    pdf.Add(new Paragraph($"GPA: {studentGPA}"));
                    pdf.Add(new Paragraph(" "));

                    PdfPTable table = new PdfPTable(4);
                    table.AddCell("Course Prefix");
                    table.AddCell("Course Number");
                    table.AddCell("Grade");
                    table.AddCell("Hours");

                    foreach (var course in courses)
                    {
                        table.AddCell(course[0]); //SUBJCODE
                        table.AddCell(course[1]); //CRSENUMB
                        table.AddCell(course[2]); //GRADE
                        table.AddCell(course[3]); //HOURS
                    }

                    pdf.Add(table);
                    pdf.Close();
                }

                MessageBox.Show("Transcript has been Created");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while creating PDF: " + ex.Message);
                Clipboard.SetText(ex.ToString());
            }
        }




        private void printTranscriptButton_Click(object sender, EventArgs e)
        {
            //Check for student existence
            string connStr = "server=csitmariadb.eku.edu;user=student;database=csc340_db;port=3306;password=Maroon@21?;";
            MySql.Data.MySqlClient.MySqlConnection conn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            string fixID = studentID.Text.Replace(" ", "");

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

            int id = Convert.ToInt32(fixID);

            transcript(id);
        }
    }
}