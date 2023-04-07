using SchoolControlSystem.Models;
using SchoolControlSystem.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolControlSystem.Operations
{
    public class StudentOperations
    {
        StudentValidations studentValidations=new StudentValidations();
        public void ShowStudentOptions()
        {
            Console.WriteLine("Öğrenci eklemek için 1'e\n" +
                              "Öğrencileri listelemek için 2'ye\n " +
                              "Öğrenciyi sınıfa atamak için 3'e\n " +
                              "Ana girişe dönmek için 4'e basınız");

            string SelectedStudentAction = Console.ReadLine();
            SelectedStudentActionValidityCheck(SelectedStudentAction);
        }
        public void SelectedStudentActionValidityCheck(string SelectedStudentAction) 
        {
            bool IsSelectedValueExistOnList= studentValidations.IsExistOnList(SelectedStudentAction, CommonConstant.CommonConstant.StudentOperationsValidList);
           
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
                    MainOperations mainOperations = new MainOperations();
                    mainOperations.ShowMainOptions();
                    break;
            }
        }
        public void AddStudent() 
        {
            Console.WriteLine("Lütfen öğrenci adı giriniz:");
            string EnteredStudentName = Console.ReadLine().ToUpper();
            Console.WriteLine("Lütfen öğrenci soyadı giriniz:");
            string EnteredStudentSurname = Console.ReadLine().ToUpper();
            Console.WriteLine("Lütfen öğrenci numarası giriniz:");
            int EnteredStudentNumber =Convert.ToInt32( Console.ReadLine());

            //Burayı methoda al
            if (Lists.StudenList.Any(s=>s.Number==EnteredStudentNumber))
            {
                Console.WriteLine("Bu öğrenci numarası sistemde kayıtlıdır.");
                ShowStudentOptions();
            }
            else
            {
                int GeneratedNewStudentId = studentValidations.GetGenerateNewId(Lists.StudenList.Select(c => c.Id).ToList());
                StudentModel studentModel = new StudentModel();
                studentModel.Id = GeneratedNewStudentId;
                studentModel.Name = EnteredStudentName;
                studentModel.Surname = EnteredStudentSurname;
                studentModel.Number = EnteredStudentNumber;

                Lists.StudenList.Add(studentModel);
                Console.WriteLine("Yeni öğrenci eklendi.");
                ShowStudentOptions();
            }
        }
        public void ShowStudentList()
        {
            bool IsStudentListEmpty = studentValidations.IsListEmpty(Lists.StudenList.Select(s => s.Id).ToList());
            if (!IsStudentListEmpty)
            {
                foreach (var item in Lists.StudenList)
                {
                    Console.Write($"Öğrenci Id:{item.Id}\t");
                    Console.Write($"Öğrenci Adı:{item.Name}\t");
                    Console.Write($"Öğrenci Soyadı:{item.Surname}\t");
                    Console.Write($"Öğrenci Numarası:{item.Number}\t");
                    if (string.IsNullOrEmpty(item.Class))
                    {
                        Console.WriteLine($"Öğrenci Sınıfı:Atanmadı.\t");
                    }
                    else
                    {
                        Console.WriteLine($"Öğrenci Sınıfı:{item.Class}\t");
                    }
                }
            }
            
            ShowStudentOptions();
        }
        public void AddStudentToClass() 
        {
            Console.WriteLine("Lütfen eklenecek sınıfın adını giriniz:");
            string ClassToAdd=Console.ReadLine().ToUpper(); 
            Console.WriteLine("Lütfen eklenecek öğrencinin numarasını giriniz:");
            int StudentNumberToAdd = Convert.ToInt32(Console.ReadLine());

            var EnteredStudentsClass = Lists.StudenList.FirstOrDefault(s => s.Number == StudentNumberToAdd && s.Class != null);
            if (EnteredStudentsClass == null)
            {
                bool IsEnteredClassNameExistOnClassList = studentValidations.IsExistOnList(ClassToAdd, Lists.ClassList.Select(c => c.Name).ToList());
                bool IsEnteredStudentNumberExistOnClassList = studentValidations.IsExistOnList(StudentNumberToAdd, Lists.StudenList.Select(s => s.Number).ToList());

                if (IsEnteredClassNameExistOnClassList && IsEnteredStudentNumberExistOnClassList)
                {
                    StudentModel student = Lists.StudenList.FirstOrDefault(s=>s.Number==StudentNumberToAdd);
                    student.Class = ClassToAdd;
                    Console.WriteLine("Öğrenci sınıfa kaydedildi.");
                }
                else
                {
                    Console.WriteLine("Girilen sınıf veya öğrenci numarası sistemde kayıtlı değildir.");
                }
            }
            else
            {
                Console.WriteLine("Bu öğrencinin bir sınıfı vardır.");
            }

            ShowStudentOptions();

        }


    }
}
