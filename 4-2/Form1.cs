using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _4_2
{
    public partial class Form1 : Form
    {
        private static Time time = new Time();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            time.AddSecond();
            textBox1.Text = time.Hour.ToString();
            textBox2.Text = time.Minute.ToString();
            textBox3.Text = time.Second.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = time.Hour.ToString();
            textBox2.Text = time.Minute.ToString();
            textBox3.Text = time.Second.ToString();
        }
    }
}
