using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4_3
{
    public class Student
    {
        /// <summary>
        /// 学号
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string StudentName { get; set; }

        /// <summary>
        /// 语文成绩
        /// </summary>
        public double ChineseResult { get; set; }

        /// <summary>
        /// 数学成绩
        /// </summary>
        public double MathResult { get; set; }

        /// <summary>
        /// 英语成绩
        /// </summary>
        public double EnglishResult { get; set; }

        /// <summary>
        /// 总成绩
        /// </summary>
        public double AllResult { get; private set; }

        public Student(int studentId,string studentName, double chineseResult, double mathResult, double englishResult)
        {
            StudentID = studentId;
            StudentName = studentName;
            ChineseResult = chineseResult;
            MathResult = mathResult;
            EnglishResult = englishResult;
            AllResult = chineseResult + englishResult + mathResult;
        }
    }
}
