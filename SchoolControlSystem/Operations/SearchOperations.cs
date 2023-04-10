namespace SchoolControlSystem.Operations
{
    public class SearchOperations : CommonOperations
    {
        public void SearchInSchool()
        {
            Console.WriteLine("Lütfen aranacak değeri giriniz:");
            var ValueToSearch = Console.ReadLine().ToLower();
            SearchInClasses(ValueToSearch);
            SearchInStudents(ValueToSearch);
            SearchInTeachers(ValueToSearch);

            MainOperations mainOperations = new MainOperations();
            mainOperations.ShowMainOptions();
        }
        public void SearchInClasses(string ValueToSearch)
        {
            var Classes = Lists.ClassList.Where(c => c.Id.ToString() == ValueToSearch
                                                  || c.Name == ValueToSearch).ToList();

            Console.WriteLine("Sınıflar arası arama sonuçları===>");
            foreach (var item in Classes)
            {
                if (item.Name == ValueToSearch)
                {
                    Console.Write($"Sınıf Id:{item.Id}\t");
                    Console.Write($"Sınıf Adı:{item.Name}\t");
                    if (item.TeacherId == null)
                    {
                        Console.WriteLine("Sınıf Öğretmeni:Kayıt yok.");
                    }
                    else
                    {
                        string Teacher = Lists.TeacherList.Where(t => t.Id == item.TeacherId).Select(t => t.Name + t.Surname).FirstOrDefault();
                        Console.WriteLine($"Sınıf Öğretmeni:{Teacher}");
                    }
                }
            }

        }
        public void SearchInStudents(string ValueToSearch)
        {
            Console.WriteLine("Öğrenciler arası arama sonuçları=>");

            var Students = Lists.StudenList.Where(s => s.Id.ToString() == ValueToSearch
                                                    || s.Name == ValueToSearch
                                                    || s.Surname == ValueToSearch
                                                    || s.Number.ToString() == ValueToSearch).ToList();

            foreach (var item in Students)
            {
                    Console.Write($"Öğrenci Id:{item.Id}\t");
                    Console.Write($"Öğrenci Adı:{item.Name}\t");
                    Console.Write($"Öğrenci Soyadı:{item.Surname}\t");
                    Console.Write($"Öğrenci Numarası:{item.Number}\t");
                    if (item.ClassId == null)
                    {
                        Console.WriteLine("Öğrenci Sınıfı:Kayıt yok.");
                    }
                    else
                    {
                        string StudentsClass = Lists.ClassList.Where(c => c.Id == item.ClassId).Select(c => c.Name).FirstOrDefault();
                        Console.WriteLine($"Öğrenci Sınıfı:{StudentsClass}");
                    }
            }
        }
        public void SearchInTeachers(string ValueToSearch)
        {
            var Teachers = Lists.TeacherList.Where(t => t.Id.ToString() == ValueToSearch
                                                     || t.Name == ValueToSearch
                                                     || t.Surname == ValueToSearch).ToList();

            Console.WriteLine("Öğretmenler arası arama sonuçları=>");
            foreach (var item in Teachers)
            {
                    Console.Write($"Öğretmen Id:{item.Id}\t");
                    Console.Write($"Öğretmen Adı:{item.Name}\t");
                    Console.Write($"Öğretmen Soyadı:{item.Surname}\t");

                    if (item.ClassId == null)
                    {
                        Console.WriteLine("Öğretmen Sınıfı:Kayıt yok.");
                    }
                    else
                    {
                        string TeachersClass = Lists.ClassList.Where(c => c.Id == item.ClassId).Select(c => c.Name).FirstOrDefault();
                        Console.WriteLine($"Öğretmen Sınıfı:{TeachersClass}");
                    }
            }
          
        }
    }
}
