namespace GradeManagementSystem
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void addGradeButton_Click(object sender, EventArgs e)
        {
            AddGrade addGrade = new AddGrade();
            addGrade.Show();
            this.Hide();
        }
        private void importButton_Click(object sender, EventArgs e)
        {
            ImportGrade importGrade = new ImportGrade();
            importGrade.Show();
            this.Hide();
        }

        private void deleteGradeButton_Click(object sender, EventArgs e)
        {
            DeleteGrade deleteGrade = new DeleteGrade();
            deleteGrade.Show();
            this.Hide();
        }
        private void editGradeButton_Click(object sender, EventArgs e)
        {
            EditGrade editGrade = new EditGrade();  
            editGrade.Show();
            this.Hide();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            PrintTranscript printTranscript = new PrintTranscript();
            printTranscript.Show();
            this.Hide();
        }

    }
}
