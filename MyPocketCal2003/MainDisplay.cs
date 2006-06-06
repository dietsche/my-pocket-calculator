using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyPocketCal2003
{
    public partial class MainDisplay : Form
    {
        public MainDisplay()
        {
            InitializeComponent();
        }

        private void pictureBox30_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form oldWindow = Program.activeWindow; // the old window
            oldWindow.Hide(); // hide the window

            Program.activeWindow = new Matrix(); // make the form
            Program.activeWindow.Show(); // show the form
            //oldWindow.Dispose();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form oldWindow = Program.activeWindow; // the old window
            oldWindow.Hide(); // hide the window

            Program.activeWindow = new Statistic(); // make the form
            Program.activeWindow.Show(); // show the form
           //oldWindow.Dispose();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form oldWindow = Program.activeWindow; // the old window
            oldWindow.Hide(); // hide the window

            Program.activeWindow = new Conversion(); // make the form
            Program.activeWindow.Show(); // show the form
            //oldWindow.Dispose();
        }
    }
}