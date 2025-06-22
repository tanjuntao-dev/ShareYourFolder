using System;
using System.Windows.Forms;

namespace ShareYourFolder
{
    public partial class HelpForm : Form
    {
        public HelpForm(string title, string content)
        {
            InitializeComponent();
            this.Text = title;
            txtContent.Text = content;
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            txtContent.SelectionStart = 0;
            txtContent.SelectionLength = 0;
        }
    }
}