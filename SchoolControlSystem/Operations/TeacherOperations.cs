using SchoolControlSystem.Models;
using SchoolControlSystem.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolControlSystem.Operations
{
    public class TeacherOperations:CommonOperations
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
            bool IsSelectedValueExistOnList = teacherValidations.IsExistOnList(SelectedTeacherAction, CommonConstant.TeacherOperationsValidList);

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
            string EnteredTeacherName = Console.ReadLine().ToLower();
            Console.WriteLine("Lütfen öğretmen soyadı giriniz:");
            string EnteredTeacherSurname = Console.ReadLine().ToLower();

            if (Lists.TeacherList.Any(t => t.Name == EnteredTeacherName && t.Surname == EnteredTeacherSurname))
            {
                Console.WriteLine("Bu öğretmen  sistemde kayıtlıdır.");
                ShowTeacherOptions();
            }
            else
            {
                TeacherModel teacherModel = new TeacherModel();
                teacherModel.Id = GetGenerateNewId(Lists.TeacherList.Select(c => c.Id).ToList());
                teacherModel.Name = EnteredTeacherName;
                teacherModel.Surname = EnteredTeacherSurname;
                Lists.TeacherList.Add(teacherModel);

                Console.WriteLine("Yeni öğretmen eklendi.");
                ShowTeacherOptions();
            }
        }
        public void ShowTeacherList()
        {
            
            if (Lists.TeacherList.Count==0)
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

                    if (item.ClassId == null)
                    {
                        Console.WriteLine("Öğretmen Sınıfı:Atanmadı.\t");
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
                            Console.WriteLine("Öğrenci Sınıfı:Bulunamadı.\t");
                        }
                    }
                }
            }
            ShowTeacherOptions();
        }
        public void AddTeacherToClass()
        {
            Console.WriteLine("Lütfen öğretmen eklenecek sınıfın adını giriniz:");
            string ClassToAddTeacher = Console.ReadLine().ToLower();
            Console.WriteLine("Lütfen eklenecek öğretmenin adını giriniz:");
            string TeacherNameToAdd = Console.ReadLine().ToLower();
            Console.WriteLine("Lütfen eklenecek öğretmenin soyadını giriniz:");
            string TeacherSurnameToAdd = Console.ReadLine().ToLower();


            bool IsTeacherExistOnList = teacherValidations.IsExistOnList(TeacherNameToAdd + TeacherSurnameToAdd, Lists.TeacherList.Select(t => t.Name + t.Surname).ToList());
            bool IsClassExistOnList = teacherValidations.IsExistOnList(ClassToAddTeacher, Lists.ClassList.Select(c => c.Name).ToList());

            if (!IsTeacherExistOnList)
            {
                Console.WriteLine("Bu öğretmen kayıtlı değildir.");
            }
            if (!IsClassExistOnList)
            {
                Console.WriteLine("Bu sınıf kayıtlı değildir.");
            }
            if (IsTeacherExistOnList && IsClassExistOnList)
            {
                var SuitableTeacher = Lists.TeacherList.FirstOrDefault(t => t.Name == TeacherNameToAdd && t.Surname == TeacherSurnameToAdd && t.ClassId == null);
                var SuitableClass = Lists.ClassList.FirstOrDefault(c => c.Name == ClassToAddTeacher && c.TeacherId == null);

                if (SuitableTeacher == null)
                {
                    Console.WriteLine("Girilen öğretmenin bir sınıfı vardır.");
                }
                if (SuitableClass == null)
                {
                    Console.WriteLine("Girilen sınıfın bir öğretmeni vardır.");
                }
                if(SuitableTeacher != null && SuitableClass != null)
                {
                    //TeacherModel teacher = Lists.TeacherList.FirstOrDefault(t => t.Name == TeacherNameToAdd && t.Surname == TeacherSurnameToAdd);
                    SuitableTeacher.ClassId = SuitableClass.Id;
                    SuitableClass.TeacherId = SuitableTeacher.Id;

                    Console.WriteLine("Öğretmen sınıfa atandı.");
                }
            }
            ShowTeacherOptions();
        }
    }
}
