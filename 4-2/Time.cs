using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4_2
{
    public class Time
    {
        public int Hour { get; set; }

        public int Minute { get; set; }

        public int Second { get; set; }

        public Time()
        {
            this.Hour = DateTime.Now.Hour;
            this.Minute = DateTime.Now.Minute;
            this.Second = DateTime.Now.Second;
        }

        public void AddSecond()
        {
            Second++;
            if (Second >= 60) 
            {
                Second = Second % 60;
                Minute++;
            }
            if (Minute >= 60)
            {
                Minute = Minute % 60;
                Hour++;
            }
        }
    }
}
