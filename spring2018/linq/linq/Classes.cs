using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq
{
    class Fitness
    {
        public int id { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int hours { get; set; }


        public Fitness(string str)
        {
            var ar = str.Split(' ');
            id = int.Parse(ar[0]);
            year = int.Parse(ar[1]);
            month = int.Parse(ar[2]);
            hours = int.Parse(ar[3]);
        }

    }

    class Students
    {
        public string lastName { get; set; }
        public int enrYear { get; set; }
        public int schoolN { get; set; }


        public Students(string str)
        {
            var ar = str.Split(' ');
            lastName = ar[0];
            enrYear = int.Parse(ar[1]);
            schoolN = int.Parse(ar[2]);
        }
    }

    class Deptors
    {
        public int arrears { get; set; }
        public string lastName { get; set; }
        public int flatN { get; set; }
        public int floor { get; set; }
        public int entrance { get; set; }

        public Deptors(string str)
        {
            var ar = str.Split(' ');
            arrears = int.Parse(ar[0]);
            lastName = ar[1];
            flatN = int.Parse(ar[2]);
        }
    }

    class Petrol
    {
        public int mk { get; set; }
        public string street { get; set; }
        public string company { get; set; }
        public int price { get; set; }

        public Petrol(string str)
        {
            var ar = str.Split(' ');
            mk = int.Parse(ar[0]);
            street = ar[1];
            company = ar[2];
            price = int.Parse(ar[3]);
        }
    }

    class Exam
    {
        public int scoreRus { get; set; }
        public int scoreMath { get; set; }
        public int scoreInf { get; set; }
        public string lastName { get; set; }
        public string initials { get; set; }
        public int schoolN { get; set; }

        public Exam(string str)
        {
            var ar = str.Split(' ');
            scoreRus = int.Parse(ar[0]);
            scoreMath = int.Parse(ar[1]);
            scoreInf = int.Parse(ar[2]);
            lastName = ar[3];
            initials = ar[4];
            schoolN = int.Parse(ar[5]);
        }

    }
}

   


