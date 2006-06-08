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

            Program.activeWindow = new Unit(); // make the form
            Program.activeWindow.Show(); // show the form
            //oldWindow.Dispose();
        }

        private void pictureBox121_Click(object sender, EventArgs e)
        {

        }

        private void MainDisplay_Load(object sender, EventArgs e)
        {

        }

        private void panel7_GotFocus(object sender, EventArgs e)
        {

        }

        private void pictureBox93_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox115_Click(object sender, EventArgs e)
        {
            Matrix m = new Matrix();
            m.Show();
        }

        private void pictureBox116_Click(object sender, EventArgs e)
        {
            Statistic s = new Statistic();
            s.Show();
        }

        private void pictureBox113_Click(object sender, EventArgs e)
        {
            Unit c = new Unit();
            c.Show();
        }

        private void pictureBox120_Click(object sender, EventArgs e)
        {
            Plot p = new Plot();
            p.Show();
        }

        private void pictureBox118_Click(object sender, EventArgs e)
        {
            Differentiation d = new Differentiation();
            d.Show();
        }

        private void pictureBox119_Click(object sender, EventArgs e)
        {
            Integration i = new Integration();
            i.Show();
        }

        private void pictureBox117_Click(object sender, EventArgs e)
        {
            Vector v = new Vector();
            v.Show();
        }

        private void pictureBox139_Click(object sender, EventArgs e)
        {
            Equations ee = new Equations();
            ee.Show();
        }
    }
}