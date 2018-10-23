using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;


namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            EmailCheck();
            PhoneCheck();
            PasswordCheck();
            IpCheck();
        }


        static void Task2C()
        {
            /*
             * Распознает правильный двоичный код 
             */
            Console.WriteLine("===##-TASK2C-##===");
            string[] str_array = new string[] {
                "0000", "11011", "1010101", "0101010",
                "1010", "0101", "0001101", "101110",
                "11111", "0", "1"
            };
            List<string> list = new List<string>();
            String pattern2 = @"(\b1*1\b)|(\b0*0\b)|(\b(10)+1*\b)|(\b(01)+0*\b)";
            foreach (var str in str_array)
            {
                foreach (Match match in Regex.Matches(str, pattern2))
                {
                    list.Add(match.ToString());
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
            Console.WriteLine("\n\n");
        }

        static void Task3C()
        {
            /*
             * Генерирует 10 чисел
             * Выводит четные
             */
            Console.WriteLine("===##-TASK3C-##===");
            Random rand = new Random();
            Console.WriteLine("Even nums:");
            string pattern = @"^\d*[02468]$";
            int count = 0;
            while (count < 10)
            {   
                var str = rand.Next(100).ToString();
                if (Regex.IsMatch(str, pattern))
                {
                    Console.WriteLine(str);
                    count++;
                }
            }
            Console.WriteLine("\n\n");
        }

        static void Task3B()
        {
            /*
             * Генерирует 10 чисел
             * Проверяет, нет ли трех четных подряд в сгенерированном числе
             */
            Console.WriteLine("===##-TASK3B-##===");
            Random rand = new Random();
            Console.WriteLine("Result:");
            string pattern = @"^[13579]*[0-9]{0,2}[13579]+[0-9]{0,2}[13579]*$";
            int count = 0;
            while (count < 10)
            {
                var str = rand.Next(100, 1000000).ToString();
                if (Regex.IsMatch(str, pattern))
                {
                    Console.WriteLine(str);
                    count++;
                }
            }
            Console.WriteLine("\n\n");
        }

        static void Task4B()
        {
            /*
             * Вывести первые 10 сгенерированных чисел,
             * которые содержат более 3 и менее 6
             * четных цифр и ни одной нечетной.
             */
            Console.WriteLine("===##-TASK4B-##===");
            Random rand = new Random();
            Console.WriteLine("Result:");
            string pattern = @"^[02468]{3,6}$";
            int count = 0;
            while (count < 10)
            {
                var str = rand.Next(100, 1000000).ToString();
                if (Regex.IsMatch(str, pattern))
                {
                    Console.WriteLine(str);
                    count++;
                }
            }
            Console.WriteLine("\n\n");
        }

        static void Task5B()
        {
            /*
             * Вывести первые 10 сгенерированных чисел,
             * в которых есть как минимум два раза 
             * встречается группа из 2 четных цифр.
             */
            Console.WriteLine("===##-TASK5B-##===");
            Random rand = new Random();
            Console.WriteLine("Result:");
            string pattern = @"[02468][02468]{2,}";
            int count = 0;
            while (count < 10)
            {
                var str = rand.Next(100, 1000000).ToString();
                if (Regex.IsMatch(str, pattern))
                {
                    Console.WriteLine(str);
                    count++;
                }
            }
            Console.WriteLine("\n\n");
        }

        static void Task6B()
        {
            var logFile = File.ReadAllLines(@"C:\Projects\C#\cs_dump\ConsoleApp4\ConsoleApp4\Space Jam.htm");
            var logList = new List<string>(logFile);
            string pattern = @"[^/][a-z]+.[a-z]{3}";
            foreach (var str in logList)
            {
                if (Regex.IsMatch(str, pattern))
                {
                    Console.WriteLine(str+"\n");
                }
            }
        }

        static void EmailCheck()
        {
            Console.WriteLine("Enter e-mail");
            string email = Console.ReadLine();
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            if (Regex.IsMatch(email, pattern)) Console.WriteLine("e-mail is correct\n\n");
            else Console.WriteLine("e-mail is incorrect\n\n");
        }

        static void PhoneCheck()
        {
            Console.WriteLine("Enter phone");
            string phone = Console.ReadLine();
            string pattern = @"^\+{0,1}[0-9]{11}$";
            if (Regex.IsMatch(phone, pattern)) Console.WriteLine("phone is correct\n\n");
            else Console.WriteLine("phone is incorrect\n\n");
        }

        static void PasswordCheck()
        {
            Console.WriteLine("Enter password");
            string pass = Console.ReadLine();
            string pattern = @"^([a-zA-Z0-9]|[^a-zA-Z0-9]){8,32}$";
            if (Regex.IsMatch(pass, pattern)) Console.WriteLine("password matches requirments\n\n");
            else Console.WriteLine("password does not match requirments\n\n");
        }

        static void IpCheck()
        {
            Console.WriteLine("Enter ip adress");
            string ip = Console.ReadLine();
            string pattern = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]).){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";
            if (Regex.IsMatch(ip, pattern)) Console.WriteLine("ip is correct\n\n");
            else Console.WriteLine("ip is incorrect\n\n");
        }
    }
}
