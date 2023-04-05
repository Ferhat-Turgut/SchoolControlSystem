using SchoolControlSystem.Models;
using SchoolControlSystem.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolControlSystem.Operations
{
    public class TeacherOperations
    {
        public void ShowTeacherOptions()
        {
            Console.WriteLine("Öğretmen eklemek için 1'e\n" +
                              "Öğretmenleri listelemek için 2'ye\n " +
                              "Ana girişe dönmek için 3'e basınız");

            string SelectedTeacherAction = Console.ReadLine();
            SelectedTeacherActionValidityCheck(SelectedTeacherAction);
        }
        public void SelectedTeacherActionValidityCheck(string SelectedTeacherAction)
        {
            bool IsSelectedValueExistOnList = CommonValidations.IsExistOnList(SelectedTeacherAction, CommonConstant.CommonConstant.TeacherOperationsValidList);

            if (IsSelectedValueExistOnList)
            {
                RedirectToSelectedTeacherAction(SelectedTeacherAction);
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir seçenek giriniz!");
                ShowTeacherOptions();
            }
        }
        public void RedirectToSelectedTeacherAction(string SelectedTeacherAction)
        {
            switch (SelectedTeacherAction)
            {
                case "1":
                    AddTeacher();
                    break;
                case "2":
                    ShowTeacherList();
                    break;
                case "3":
                    MainOperations mainOperations = new MainOperations();
                    mainOperations.ShowMainOptions();
                    break;
            }
        }
        public void AddTeacher()
        {
            Console.WriteLine("Lütfen öğretmen adı giriniz:");
            string EnteredTeacherName = Console.ReadLine();
            Console.WriteLine("Lütfen öğretmen soyadı giriniz:");
            string EnteredTeacherSurname = Console.ReadLine();
            Console.WriteLine("Lütfen öğretmenin sınıfını giriniz:");
            string EnteredTeacherClass = Console.ReadLine();
            
     

            if (Lists.TeacherList.Any(t => t.Name == EnteredTeacherName && t.Surname==EnteredTeacherSurname))
            {
                Console.WriteLine("Bu öğretmen  sistemde kayıtlıdır.");
                ShowTeacherOptions();
            }
            else
            {
                int GeneratedNewStudentId = CommonValidations.GetGenerateNewId(Lists.TeacherList.Select(c => c.Id).ToList());
                TeacherModel teacherModel = new TeacherModel();
                teacherModel.Id = GeneratedNewStudentId;
                teacherModel.Name = EnteredTeacherName;
                teacherModel.Surname = EnteredTeacherSurname;
                teacherModel.Class = EnteredTeacherClass;

                Lists.TeacherList.Add(teacherModel);
                Console.WriteLine("Yeni öğretmen eklendi.");
                ShowTeacherOptions();
            }
        }
        public void ShowTeacherList()
        {
            bool IsTeacherListEmpty = CommonValidations.IsListEmpty(Lists.StudenList.Select(c => c.Id).ToList());
            if (IsTeacherListEmpty)
            {
                Console.WriteLine("Öğretmen listesi boş.Lütfen kayıt ekleyin.");
            }
            else
            {
                foreach (var item in Lists.TeacherList)
                {
                    Console.Write($"Öğretmen Id:{item.Id}\t");
                    Console.Write($"Öğretmen Adı:{item.Name}\t");
                    Console.Write($"Öğretmen Soyadı:{item.Surname}\t");
                    Console.Write($"Öğretmen Sınıfı:{item.Class}\t");
                }
            }
            ShowTeacherOptions();
        }
    }
}
