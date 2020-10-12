using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _4_3
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 添加事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Grade.AddStudent(
                new Student
                (
                    string.IsNullOrEmpty(textBox1.Text.Trim()) ? 0 : Convert.ToInt32(textBox1.Text.Trim()),
                    textBox2.Text.Trim(),
                    string.IsNullOrEmpty(textBox3.Text.Trim()) ? 0 : Convert.ToDouble(textBox3.Text.Trim()),
                    string.IsNullOrEmpty(textBox4.Text.Trim()) ? 0 : Convert.ToDouble(textBox4.Text.Trim()),
                    string.IsNullOrEmpty(textBox5.Text.Trim()) ? 0 : Convert.ToDouble(textBox5.Text.Trim())
                ));
            MessageBox.Show("添加成功！");
        }

        /// <summary>
        /// 查询事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                MessageBox.Show("请输入姓名！");
            }
            else
            {
                string name = textBox2.Text.Trim();
                MessageBox.Show(name+"的总成绩为："+Grade.GetAllResult(name));
            }
        }

        /// <summary>
        /// 完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            LabelDispose();
            label6.Text += Grade.GetAverResult();
            label7.Text += Grade.GetMaxResult(Convert.ToInt32(Enum.课程.语文));
            List<Student> firstTreeStudent = Grade.GetFirstThreeStudents();
            foreach (var student in firstTreeStudent)
            {
                label8.Text += student.StudentName+ " ";
            }
            List<Student> unstudents = Grade.GetUnPassNames(Convert.ToInt32(Enum.课程.语文));
            foreach (var unstudent in unstudents)
            {
                label9.Text += unstudent.StudentName + " ";
            }
        }

        /// <summary>
        /// 文本处理
        /// </summary>
        private void LabelDispose()
        {
            label6.Text = label7.Text = label8.Text = label9.Text = null;
            label6.Text = "全班学生平均成绩:";
            label7.Text = "语文单科最高分:";
            label8.Text = "全班前三名单:";
            label9.Text = "不及格成绩名单:";
        }
    }
}
