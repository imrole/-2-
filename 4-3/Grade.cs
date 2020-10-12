using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace _4_3
{
    public class Grade
    {
        public static List<Student> students = new List<Student>();

        public static void AddStudent(Student student)
        {
            students.Add(student);
        }

        /// <summary>
        /// 获取学生总成绩
        /// </summary>
        /// <param name="studentName">学生姓名</param>
        /// <returns></returns>
        public static double GetAllResult(string studentName)
        {
            var student = students.FirstOrDefault(a => a.StudentName == studentName);
            Console.Write(student.AllResult);
            if (student == null)
            {
                return 0;
            }
            else
            {

                return student.AllResult; 
            }
        }

        /// <summary>
        /// 获取全班总平均成绩
        /// </summary>
        /// <returns></returns>
        public static double GetAverResult()
        {
            return students.Average(a => a.AllResult);
        }

        /// <summary>
        /// 获取单科最高分
        /// </summary>
        /// <param name="subjects">科目</param>
        /// <returns></returns>
        public static double GetMaxResult(Enum.课程 subjects)
        {
            return subjects switch
            {
                Enum.课程.语文 => students.Max(a => a.ChineseResult),
                Enum.课程.数学 => students.Max(a => a.MathResult),
                Enum.课程.英语 => students.Max(a => a.EnglishResult),
                _ => students.Max(a => a.AllResult)
            };
        }

        /// <summary>
        /// 获取全班前三的名单（按总成绩）
        /// </summary>
        /// <returns></returns>
        public static List<Student> GetFirstThreeStudents()
        {
            List<Student> newStudents = students.OrderBy(a=>a.AllResult).ToList();
            List<Student> retStudent = new List<Student>();
            if (newStudents.Count <= 3)
            {
                for (int i = 0; i < newStudents.Count; i++)
                {
                    retStudent.Add(new Student
                        (
                            newStudents[i].StudentID,
                            newStudents[i].StudentName,
                            newStudents[i].ChineseResult,
                            newStudents[i].MathResult,
                            newStudents[i].EnglishResult
                        ));
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    retStudent.Add(new Student
                        (
                            newStudents[i].StudentID,
                            newStudents[i].StudentName,
                            newStudents[i].ChineseResult,
                            newStudents[i].MathResult,
                            newStudents[i].EnglishResult
                        ));
                }
            }
            return retStudent;
        }

        /// <summary>
        /// 获取不及格名单
        /// </summary>
        /// <param name="subjects">科目</param>
        /// <returns></returns>
        public static List<Student> GetUnPassNames(Enum.课程 subjects)
        {
            return subjects switch
            {
                Enum.课程.语文 => students.FindAll(a => a.ChineseResult < 60),
                Enum.课程.数学 => students.FindAll(a => a.MathResult < 60),
                Enum.课程.英语 => students.FindAll(a => a.EnglishResult < 60),
                _ => students.FindAll(a => a.AllResult < 60)
            };
        }

        /// <summary>
        /// 统计
        /// </summary>
        public static string Statistical(Enum.课程 subjects)
        {
            int[] a = new int[3];
            switch (subjects)
            {
                case Enum.课程.语文:
                    a[0] = (from student in students where student.ChineseResult < 60 select student).Count();
                    a[1] = (from student in students where student.ChineseResult >= 60 && student.MathResult < 90 select student).Count();
                    a[2] = (from student in students where student.ChineseResult > 90 select student).Count();
                    break;
                case Enum.课程.数学:
                    a[0] = (from student in students where student.MathResult < 60 select student).Count();
                    a[1] = (from student in students where student.MathResult >= 60 && student.MathResult < 90 select student).Count();
                    a[2] = (from student in students where student.MathResult > 90 select student).Count();
                    break;
                case Enum.课程.英语:
                    a[0] = (from student in students where student.EnglishResult < 60 select student).Count();
                    a[1] = (from student in students where student.EnglishResult >= 60 && student.MathResult < 90 select student).Count();
                    a[2] = (from student in students where student.EnglishResult > 90 select student).Count();
                    break;
                default:
                    a[0] = (from student in students where student.AllResult < 60 select student).Count();
                    a[1] = (from student in students where student.AllResult >= 60 && student.MathResult < 90 select student).Count();
                    a[2] = (from student in students where student.AllResult > 90 select student).Count();
                    break;
            }
            return "\n60以下：" + a[0]/(double)students.Count()*100 + "%" + "\n60至90：" + a[1] / (double)students.Count()*100 + "%" + "\n90以上：" + a[2] / (double)students.Count()*100+"%";
        }

    }
}
