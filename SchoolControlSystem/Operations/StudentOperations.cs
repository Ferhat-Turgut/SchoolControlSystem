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
        public void ShowStudentOptions()
        {
            Console.WriteLine("Öğrenci eklemek için 1'e\n" +
                              "Öğrencileri listelemek için 2'ye\n " +
                              "Ana girişe dönmek için 3'e basınız");

            string SelectedStudentAction = Console.ReadLine();
            SelectedStudentActionValidityCheck(SelectedStudentAction);
        }
        public void SelectedStudentActionValidityCheck(string SelectedStudentAction) 
        {
            bool IsSelectedValueExistOnList=CommonValidations.IsExistOnList(SelectedStudentAction, CommonConstant.CommonConstant.StudentOperationsValidList);
           
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
                    MainOperations mainOperations = new MainOperations();
                    mainOperations.ShowMainOptions();
                    break;
            }
        }
        public void AddStudent() 
        {
            Console.WriteLine("Lütfen öğrenci adı giriniz:");
            string EnteredStudentName = Console.ReadLine();
            Console.WriteLine("Lütfen öğrenci soyadı giriniz:");
            string EnteredStudentSurname = Console.ReadLine();
            Console.WriteLine("Lütfen öğrenci numarası giriniz:");
            int EnteredStudentNumber =Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("Lütfen öğrenci sınıfını giriniz:");
            string EnteredStudentClass = Console.ReadLine();

            bool IsEnteredStudentClassExist = CommonValidations.IsExistOnList(EnteredStudentClass, Lists.ClassList.Select(c => c.ClassName).ToList());

            if (!IsEnteredStudentClassExist) 
            {
                Console.WriteLine("Girilen sınıf, sınıf listesinde mevcut değildir.Lütfen bilgileri kontrol ederek tekrar giriniz.");
                AddStudent();
            }

            else if (Lists.StudenList.Any(s=>s.Id==EnteredStudentNumber))
            {
                Console.WriteLine("Bu öğrenci numarası sistemde kayıtlıdır.");
                ShowStudentOptions();
            }
            else
            {
                int GeneratedNewStudentId = CommonValidations.GetGenerateNewId(Lists.StudenList.Select(c => c.Id).ToList());
                StudentModel studentModel = new StudentModel();
                studentModel.Id = GeneratedNewStudentId;
                studentModel.Name = EnteredStudentName;
                studentModel.Surname = EnteredStudentSurname;
                studentModel.Number = EnteredStudentNumber;
                studentModel.Class = EnteredStudentClass;

                Lists.StudenList.Add(studentModel);
                Console.WriteLine("Yeni öğrenci eklendi.");
                ShowStudentOptions();
            }
        }
        public void ShowStudentList()
        {
            bool IsStudentListEmpty = CommonValidations.IsListEmpty(Lists.StudenList.Select(c => c.Id).ToList());
            if (IsStudentListEmpty)
            {
                Console.WriteLine("Öğrenci listesi boş.Lütfen kayıt ekleyin.");
            }
            else
            {
                foreach (var item in Lists.StudenList)
                {
                    Console.Write($"Öğrenci Id:{item.Id}\t");
                    Console.Write($"Öğrenci Adı:{item.Name}\t");
                    Console.Write($"Öğrenci Soyadı:{item.Surname}\t");
                    Console.Write($"Öğrenci Numarası:{item.Number}\t");
                    Console.WriteLine($"Öğrenci Sınıfı:{item.Class}\t");
                }
            }
            ShowStudentOptions();
        }
    }
}
