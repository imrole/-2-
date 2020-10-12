using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 第四章
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point pointA = new Point
            {
                X = Convert.ToDouble(textBox1.Text.Trim()),
                Y = Convert.ToDouble(textBox2.Text.Trim())
            };

            Point pointB = new Point
            {
                X = Convert.ToDouble(textBox3.Text.Trim()),
                Y = Convert.ToDouble(textBox4.Text.Trim())
            };

            textBox5.Text = pointA.Distance(pointB).ToString();
        }
    }
}
