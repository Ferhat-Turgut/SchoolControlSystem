using SchoolControlSystem.Models;
using SchoolControlSystem.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolControlSystem.Operations
{
    public class StudentOperations : CommonOperations
    {
        StudentValidations studentValidations = new StudentValidations();
        public void ShowStudentOptions()
        {
            Console.WriteLine("Öğrenci eklemek için 1'e\n" +
                              "Öğrencileri listelemek için 2'ye\n " +
                              "Öğrenciyi sınıfa atamak için 3'e\n " +
                              "Öğrenci ödevi göndermek için 4'e\n " +
                              "Ana girişe dönmek için 5'e basınız");

            string SelectedStudentAction = Console.ReadLine();
            SelectedStudentActionValidityCheck(SelectedStudentAction);
        }
        public void SelectedStudentActionValidityCheck(string SelectedStudentAction)
        {
            bool IsSelectedValueExistOnList = studentValidations.IsExistOnList(SelectedStudentAction, CommonConstant.StudentOperationsValidList);

            if (IsSelectedValueExistOnList)
            {
                RedirectToSelectedStudentAction(SelectedStudentAction);
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir seçenek giriniz!");
                ShowStudentOptions();
            }
        }
        public void RedirectToSelectedStudentAction(string SelectedStudentAction)
        {
            switch (SelectedStudentAction)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    ShowStudentList();
                    break;
                case "3":
                    AddStudentToClass();
                    break;
                case "4":
                    SendHomeWork();
                    break;
                case "5":
                    MainOperations mainOperations = new MainOperations();
                    mainOperations.ShowMainOptions();
                    break;
            }
        }
        public void AddStudent()
        {
            Console.WriteLine("Lütfen öğrenci adı giriniz:");
            string EnteredStudentName = Console.ReadLine().ToLower();
            Console.WriteLine("Lütfen öğrenci soyadı giriniz:");
            string EnteredStudentSurname = Console.ReadLine().ToLower();
            Console.WriteLine("Lütfen öğrenci numarası giriniz:");
            var EnteredStudentNumber = Console.ReadLine();

            while (!studentValidations.IsInt(EnteredStudentNumber))
            {
                Console.WriteLine("Lütfen öğrenci numarasını sayısal değer giriniz:");
                EnteredStudentNumber = Console.ReadLine();

            }
            if (Lists.StudenList.Any(s => s.Number == int.Parse(EnteredStudentNumber)))
            {
                Console.WriteLine("Bu öğrenci numarası sistemde kayıtlıdır.");
                ShowStudentOptions();
            }
            else
            {
                StudentModel studentModel = new StudentModel();
                studentModel.Id = GetGenerateNewId(Lists.StudenList.Select(c => c.Id).ToList());
                studentModel.Name = EnteredStudentName;
                studentModel.Surname = EnteredStudentSurname;
                studentModel.Number = int.Parse(EnteredStudentNumber);
                Lists.StudenList.Add(studentModel);

                Console.WriteLine("Yeni öğrenci eklendi.");
                ShowStudentOptions();
            }
        }
        public void ShowStudentList()
        {
            if (Lists.StudenList.Count != 0)
            {
                foreach (var item in Lists.StudenList)
                {
                    Console.Write($"Öğrenci Id:{item.Id}\t");
                    Console.Write($"Öğrenci Adı:{item.Name}\t");
                    Console.Write($"Öğrenci Soyadı:{item.Surname}\t");
                    Console.Write($"Öğrenci Numarası:{item.Number}\t");
                    if (item.ClassId == null)
                    {
                        Console.WriteLine("Öğrenci Sınıfı:Atanmadı.\t");
                    }
                    else
                    {
                        var ClassName = Lists.ClassList.Where(c => c.Id == item.ClassId).Select(c => c.Name).FirstOrDefault();
                        if (!string.IsNullOrEmpty(ClassName))
                        {
                            Console.WriteLine($"Öğrenci Sınıfı:{ClassName}\t");
                        }
                        else
                        {
                            Console.WriteLine("Öğrenci Sınıfı:Kayıt yok.\t");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Öğrenci listesinde kayıt yoktur.");
            }
            ShowStudentOptions();
        }
        public void SendHomeWork() 
        {
            Console.WriteLine("Lütfen ödev gönderecek öğrencinin numarasını giriniz:");
            var StudentNumber = Console.ReadLine();

            while (!studentValidations.IsInt(StudentNumber))
            {
                Console.WriteLine("Lütfen öğrenci numarasını sayısal değer giriniz:");
                StudentNumber = Console.ReadLine();
            }

            var Student = Lists.StudenList.FirstOrDefault(s=>s.Number==int.Parse(StudentNumber));
            Console.WriteLine($"{Student.Number} numaralı {Student.Name} {Student.Surname} adlı öğrencinin ödevi gönderildi.");
            ShowStudentOptions();
        }
        public void AddStudentToClass()
        {
            Console.WriteLine("Lütfen eklenecek sınıfın adını giriniz:");
            string ClassToAdd = Console.ReadLine().ToLower();
            Console.WriteLine("Lütfen eklenecek öğrencinin numarasını giriniz:");
            var StudentNumberToAdd = Console.ReadLine();

            while (!studentValidations.IsInt(StudentNumberToAdd))
            {
                Console.WriteLine("Lütfen öğrenci numarasını sayısal değer giriniz:");
                StudentNumberToAdd = Console.ReadLine();
            }

            bool IsEnteredClassNameExistOnClassList = Lists.ClassList.Any(c => c.Name == ClassToAdd);
            bool IsEnteredStudentNumberExistOnClassList = Lists.StudenList.Any(s => s.Number == int.Parse(StudentNumberToAdd));

            var StudentsClassInfo = Lists.StudenList.FirstOrDefault(s => s.Number == int.Parse(StudentNumberToAdd) && s.ClassId != null);

            if (!IsEnteredClassNameExistOnClassList)
            {
                Console.WriteLine("Sınıf bilgisi kayıtlarda mevcut değildir.");
            }
            if (!IsEnteredStudentNumberExistOnClassList)
            {
                Console.WriteLine("Öğrenci bilgisi kayıtlarda mevcut değildir.");
            }
            if (StudentsClassInfo != null)
            {
                Console.WriteLine("Bu öğrencinin sınıf kaydı mevcuttur.");
            }

            if (StudentsClassInfo == null && IsEnteredClassNameExistOnClassList && IsEnteredStudentNumberExistOnClassList)
            {
                StudentModel student = Lists.StudenList.FirstOrDefault(s => s.Number == int.Parse(StudentNumberToAdd));
                var IdOfAddedClass = Lists.ClassList.Where(c => c.Name == ClassToAdd).Select(c => c.Id).FirstOrDefault();
                student.ClassId = IdOfAddedClass;

                Console.WriteLine("Öğrenci sınıfa kaydedildi.");
            }

            ShowStudentOptions();

        }


    }
}
