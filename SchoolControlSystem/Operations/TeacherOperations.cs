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
        TeacherValidations teacherValidations = new TeacherValidations();
        public void ShowTeacherOptions()
        {
            Console.WriteLine("Öğretmen eklemek için 1'e\n" +
                              "Öğretmenleri listelemek için 2'ye\n " +
                              "Öğretmenleri sınıfa atamak için 3'e\n " +
                              "Ana girişe dönmek için 4'e basınız");

            string SelectedTeacherAction = Console.ReadLine();
            SelectedTeacherActionValidityCheck(SelectedTeacherAction);
        }
        public void SelectedTeacherActionValidityCheck(string SelectedTeacherAction)
        {
            bool IsSelectedValueExistOnList = teacherValidations.IsExistOnList(SelectedTeacherAction, CommonConstant.CommonConstant.TeacherOperationsValidList);

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
                    AddTeacherToClass();
                    break;
                case "4":
                    MainOperations mainOperations = new MainOperations();
                    mainOperations.ShowMainOptions();
                    break;
            }
        }
        public void AddTeacher()
        {
            Console.WriteLine("Lütfen öğretmen adı giriniz:");
            string EnteredTeacherName = Console.ReadLine().ToUpper();
            Console.WriteLine("Lütfen öğretmen soyadı giriniz:");
            string EnteredTeacherSurname = Console.ReadLine().ToUpper();


            if (Lists.TeacherList.Any(t => t.Name == EnteredTeacherName && t.Surname == EnteredTeacherSurname))
            {
                Console.WriteLine("Bu öğretmen  sistemde kayıtlıdır.");
                ShowTeacherOptions();
            }


            else
            {
                int GeneratedNewStudentId = teacherValidations.GetGenerateNewId(Lists.TeacherList.Select(c => c.Id).ToList());
                TeacherModel teacherModel = new TeacherModel();
                teacherModel.Id = GeneratedNewStudentId;
                teacherModel.Name = EnteredTeacherName;
                teacherModel.Surname = EnteredTeacherSurname;

                Lists.TeacherList.Add(teacherModel);
                Console.WriteLine("Yeni öğretmen eklendi.");
                ShowTeacherOptions();
            }
        }
        public void ShowTeacherList()
        {
            bool IsTeacherListEmpty = teacherValidations.IsListEmpty(Lists.TeacherList.Select(t => t.Id).ToList());
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
                    Console.WriteLine($"Öğretmen Sınıfı:{item.Class}\t");
                }
            }
            ShowTeacherOptions();
        }
        public void AddTeacherToClass()
        {
            Console.WriteLine("Lütfen eklenecek sınıfın adını giriniz:");
            string ClassToAdd = Console.ReadLine().ToUpper();
            Console.WriteLine("Lütfen eklenecek öğretmenin adını giriniz:");
            string TeacherNameToAdd = Console.ReadLine().ToUpper();
            Console.WriteLine("Lütfen eklenecek öğretmenin soyadını giriniz:");
            string TeacherSurnameToAdd = Console.ReadLine().ToUpper();



            bool IsTeacherExistOnList = teacherValidations.IsExistOnList(TeacherNameToAdd + TeacherSurnameToAdd, Lists.TeacherList.Select(t => t.Name + t.Surname).ToList());
            bool IsClassExistOnList = teacherValidations.IsExistOnList(ClassToAdd, Lists.ClassList.Select(c => c.Name).ToList());


            if (IsTeacherExistOnList && IsClassExistOnList)
            {
                var EnteredTeachersClassInfo = Lists.TeacherList.FirstOrDefault(t => t.Name == TeacherNameToAdd && t.Surname == TeacherSurnameToAdd && t.Class != null);
                var EnteredClassesTeachersInfo = Lists.ClassList.FirstOrDefault(c => c.Name == ClassToAdd && c.Teacher != null);
                if (EnteredTeachersClassInfo == null && EnteredClassesTeachersInfo == null)
                {
                    TeacherModel teacher = Lists.TeacherList.FirstOrDefault(t => t.Name == TeacherNameToAdd && t.Surname == TeacherSurnameToAdd);
                    teacher.Class = ClassToAdd;
                    Console.WriteLine("Öğretmen sınıfa atandı.");
                }
                else
                {
                    Console.WriteLine("Girilen öğretmen bilgileri veya sınıf bilgileri hatalıdır.");
                    ShowTeacherOptions();
                }
            }
            else
            {
                Console.WriteLine("Girilen öğretmen veya sınıf bilgileri kayıtlı değildir.");
            }

            ShowTeacherOptions();

        }
    }
}
