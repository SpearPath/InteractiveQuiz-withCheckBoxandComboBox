using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InteractiveQuiz
{
    public partial class InteractiveQuiz : Form
    {
        public static InteractiveQuiz instance;
        public InteractiveQuiz()
        {
            InitializeComponent();
            instance = this;
        }

        private void cisco_Click(object sender, EventArgs e)
        {
            fr_cisco fr1 = new fr_cisco();
            fr1.Show();
            this.Hide();
            fr_cisco.instance.lab1.Text = "Welcome to CISCO quiz. \nGood Luck!";

        }

        private void bosh_Click(object sender, EventArgs e)
        {
            fr_bosh fr2 = new fr_bosh();
            fr2.Show();
            this.Hide();
            fr_bosh.instance.lab1.Text = "Welcome to Basic Occupational Safety and Health quiz. \nGood Luck!";

        }
    }
}
