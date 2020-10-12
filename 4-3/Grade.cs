using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public static double GetMaxResult(int subjects)
        {
            return subjects switch
            {
                >= 1 and <= 1 => students.Max(a => a.ChineseResult),
                >= 2 and <= 2 => students.Max(a => a.MathResult),
                >= 3 and <= 3 => students.Max(a => a.EnglishResult),
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
        public static List<Student> GetUnPassNames(int subjects)
        {
            return subjects switch
            {
                >= 1 and <= 1 => students.FindAll(a => a.ChineseResult < 60),
                >= 2 and <= 2 => students.FindAll(a => a.MathResult < 60),
                >= 3 and <= 3 => students.FindAll(a => a.EnglishResult < 60),
                _ => students.FindAll(a => a.AllResult < 60)
            };
        }

    }
}
