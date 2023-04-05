using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolControlSystem.Operations
{
    public class SearchOperations
    {
        public void SearchInSchool() 
        {
            Console.WriteLine("Lütfen aranacak değeri giriniz:");
            string ValueToSearch=Console.ReadLine();
            SearchInClasses(ValueToSearch);
        }
        public void SearchInClasses(string ValueToSearch) 
        {
            Console.WriteLine("Sınıflar arası arama sonuçları=>");
            foreach (var item in Lists.ClassList)
            {
                if (item.ClassName==ValueToSearch)
                {
                    Console.Write($"Sınıf Id:{item.ClassId}");
                    Console.Write($"Sınıf Adı:{item.ClassName}");
                    if (string.IsNullOrEmpty(item.Teacher))
                    {
                        Console.WriteLine("Sınıf Öğretmeni:Atanmadı!");
                    }
                    else
                    {
                        Console.WriteLine($"Sınıf Öğretmeni:{item.Teacher}");

                    }
                }
            }
            SearchInStudents(ValueToSearch);
        }
        public void SearchInStudents(string ValueToSearch)
        {
            Console.WriteLine("Öğrenciler arası arama sonuçları=>");
            foreach (var item in Lists.StudenList)
            {
                if (item.Name == ValueToSearch||item.Surname== ValueToSearch )
                {
                    Console.Write($"Öğrenci Id:{item.Id}");
                    Console.Write($"Öğrenci Adı:{item.Name}");
                    Console.Write($"Öğrenci Soyadı:{item.Surname}");
                    Console.Write($"Öğrenci Numarası:{item.Number}");
                    Console.Write($"Öğrenci Sınıfı:{item.Class}");
                }
            }
            SearchInTeachers(ValueToSearch);
        }
        public void SearchInTeachers(string ValueToSearch)
        {
            Console.WriteLine("Öğretmenler arası arama sonuçları=>");
            foreach (var item in Lists.TeacherList)
            {
                if (item.Name == ValueToSearch || item.Surname == ValueToSearch )
                {
                    Console.Write($"Öğretmen Id:{item.Id}");
                    Console.Write($"Öğretmen Adı:{item.Name}");
                    Console.Write($"Öğretmen Soyadı:{item.Surname}");
                    Console.Write($"Öğretmen Sınıfı:{item.Class}");
                    
                }
            }
            MainOperations mainOperations= new MainOperations();
            mainOperations.ShowMainOptions();
        }
    }
}
