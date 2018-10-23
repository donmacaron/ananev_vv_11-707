using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        class Speed
        {
            private decimal ms;


            public decimal SpeedMs
            {
                get => ms;
            }
            public decimal SpeedKmH
            {
                get { return ms * 3600 / 1000; }
            }
            public decimal SpeedMH
            {
                get { return ms * 224 / 10; }
            }

            private Speed(decimal ms = 0)
            {
                this.ms = ms;
            }

            public static Speed CreateMs(decimal ms)
            {
                return new Speed(ms);
            }

            public static Speed CreateKmH(int kmh)
            {
                return new Speed((decimal)(kmh / 3.6));
            }

            public static Speed operator +(Speed obj1, Speed obj2)
            {
                Speed sum = CreateMs(obj1.SpeedMs + obj2.SpeedMs);
                return sum;
            }

            public static Speed operator -(Speed obj1, Speed obj2)
            {
                Speed sum = CreateMs(obj1.SpeedMs - obj2.SpeedMs);
                if (sum.SpeedMs <= 0)
                    CreateMs(0);
                return sum;
            }
        }

        class Student
        {
            private int id;
            private string name;
            private List<int> marks;
            private Group group;

            public int Id { get => id; }
            public string Name { get => name; }
            public Group Group { get => group; set => group = value; }

            public Student(int id, string name, List<int> marks, Group group = null)
            {
                this.id = id;
                this.name = name;
                this.marks = marks.ToList();
                this.group = group;
            }
        }

        class Group
        {
            private string groupId;
            private List<Student> groupLst;

            public List<Student> GroupList { get => groupLst; }
            public string GroupName { get => groupId; }

            public Group(string groupId)
            {
                groupLst = new List<Student>();
                this.groupId = groupId;
            }

            public Student this[int id]
            {
                get
                {
                    if (groupLst.ElementAtOrDefault(id) != null)
                        return groupLst[id];
                    else return null;
                }


                set
                {
                    if (groupLst.Contains(value))
                    {
                        groupLst.RemoveAt(id);
                        groupLst.Insert(id, value);
                        groupLst[id].Group = this;
                    }
                        
                    else
                    {
                        groupLst.Insert(id, value);
                        groupLst[id].Group = this;
                    }
                }
            }

            public Student this[string name]
            {
                get
                {
                    Student student = null;
                    foreach(var n in groupLst)
                    {
                        if (n.Name == name)
                        {
                            student = n;
                            break;
                        }
                    }
                    return student;
                }

                set
                {
                    foreach(var n in groupLst)
                    {
                        if(n.Name == name)
                        {       
                            var index = groupLst.IndexOf(n);
                            groupLst.RemoveAt(index);
                            groupLst.Insert(index, value);
                            n.Group = this;
                            break;
                        }
                        else
                        {
                            var index = groupLst.IndexOf(n);
                            groupLst.Insert(index, value);
                            n.Group = this;
                            break;
                        }
                        
                    }
                }
            }


        }
  
        static void Main(string[] args)
        {
            Group group1 = new Group("42-666");
            var marks = new List<int>() { 1, 2, 3, 4, 5 };
            Student std0 = new Student(0, "Vasya", marks, group1);
            Student std1 = new Student(1, "Scooby", marks);
            Student std2 = new Student(2, "Tiefling", marks, group1);
            Student std3 = new Student(3, "Darksen", marks);
            Student std4 = new Student(4, "Daniel", marks);
            Student std5 = new Student(5, "Xi Yun", marks);
            Student std6 = new Student(6, "Yugo Shi", marks);
            Student std7 = new Student(7, "Daigakusen", marks);
            Student std8 = new Student(8, "Rarity", marks);
            Student std9 = new Student(9, "Rasmus", marks);

            group1[0] = std9;
            group1["Tiefling"] = std2;
            group1[2] = std3;
            group1[3] = std8;
            
            foreach (var s in group1.GroupList)
            {
                Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Group: {s.Group.GroupName}, <list index: {group1.GroupList.IndexOf(s)}");
            }
            Console.WriteLine("\n\n\n");

            Console.WriteLine($"index int: {group1[2].Name}" +
                $"\n" +
                $"index string: {group1["Darksen"].Name}");

            group1["Darksen"] = std4;
            Console.WriteLine($"{group1.GroupList.IndexOf(std4)}, {group1["Daniel"].Name}");

            foreach (var s in group1.GroupList)
            {
                Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Group: {s.Group.GroupName}, <list index: {group1.GroupList.IndexOf(s)}");
            }
            Console.WriteLine("\n\n\n");


            //Speed s1 = Speed.CreateMs(50);
            //Speed s2 = Speed.CreateMs(69);
            //Speed s3 = Speed.CreateKmH(42);
            //Speed s4, s5;
            //Console.WriteLine($"s1: m/s = {s1.SpeedMs}, Km/h = {s1.SpeedKmH}, m/h = {s1.SpeedMH}\n\n" +
            //    $"s2: m/s = {s2.SpeedMs},Km/h = {s2.SpeedKmH}, m/h = {s2.SpeedMH}\n\n" +
            //    $"s3: m/s = {s3.SpeedMs}, Km/h = {s3.SpeedKmH}, m/h = {s3.SpeedMH}\n\n");
            //s4 = s1 - s3;
            //s5 = s1 + s2;
            //Console.WriteLine($"s1 - s3 = {s4.SpeedMs} m/s\ns1 + s2 = {s5.SpeedMs} m/s");
        }
    }    
}

