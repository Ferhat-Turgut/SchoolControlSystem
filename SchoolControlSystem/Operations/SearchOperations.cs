using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolControlSystem.Operations
{
    public class SearchOperations
    {
        public void SearchInSchool() 
        {
            Console.WriteLine("Lütfen aranacak değeri giriniz:");
            var ValueToSearch=Console.ReadLine().ToUpper();
            SearchInClasses(ValueToSearch);
        }
        public void SearchInClasses(string ValueToSearch) 
        {
            Console.WriteLine("Sınıflar arası arama sonuçları=>");
            foreach (var item in Lists.ClassList)
            {
                if (item.Name==ValueToSearch)
                {
                    Console.Write($"Sınıf Id:{item.Id}\t");
                    Console.Write($"Sınıf Adı:{item.Name}");
                    Console.WriteLine($"Sınıf Öğretmeni:{item.Teacher}");
                 
                }
            }
            SearchInStudents(ValueToSearch);
        }
        public void SearchInStudents(string ValueToSearch)
        {
            Console.WriteLine("Öğrenciler arası arama sonuçları=>");
            foreach (var item in Lists.StudenList)
            {
                if ((item.Name == ValueToSearch||item.Surname== ValueToSearch) ||item.Id==Convert.ToInt32( ValueToSearch))
                {
                    Console.Write($"Öğrenci Id:{item.Id}\t");
                    Console.Write($"Öğrenci Adı:{item.Name}\t");
                    Console.Write($"Öğrenci Soyadı:{item.Surname}\t");
                    Console.Write($"Öğrenci Numarası:{item.Number}\t");
                    Console.WriteLine($"Öğrenci Sınıfı:{item.Class}\t");
                }
                if (int.TryParse(ValueToSearch, out int number) && item.Id == Convert.ToInt32(ValueToSearch))
                {
                    Console.Write($"Öğrenci Id:{item.Id}\t");
                    Console.Write($"Öğrenci Adı:{item.Name}\t");
                    Console.Write($"Öğrenci Soyadı:{item.Surname}\t");
                    Console.Write($"Öğrenci Numarası:{item.Number}\t");
                    Console.WriteLine($"Öğrenci Sınıfı:{item.Class}\t");
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
                    Console.WriteLine($"Öğretmen Sınıfı:{item.Class}");
                    
                }
            }
            MainOperations mainOperations= new MainOperations();
            mainOperations.ShowMainOptions();
        }
    }
}
