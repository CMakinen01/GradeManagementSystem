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
    }
}
