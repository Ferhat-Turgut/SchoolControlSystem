using SchoolControlSystem.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolControlSystem.Operations
{
    public  class MainOperations
    {
        public  void ShowMainOptions() 
        {
            Console.WriteLine("Sınıf işlemleri için 1'e\n" +
                              "Öğrenci işlemleri için 2'ye\n " +
                              "Öğretmen işlemleri için 3'e\n " +
                              "Arama işlemleri için 4'e\n " +
                              "Çıkış için 5'e basınız.");
            string SelectedAction=Console.ReadLine();
            SelectedValueValidCheck(SelectedAction);
        }
        public void SelectedValueValidCheck(string SelectedAction) 
        {
            bool IsSelectedValueExistOnList = CommonValidations.IsExistOnList(SelectedAction, CommonConstant.CommonConstant.MainOperationsValidList); 
            if (IsSelectedValueExistOnList) 
            {
                RedirectToSelectedAction(SelectedAction);
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir seçenek giriniz!");
                ShowMainOptions();
            }
        }
        public void RedirectToSelectedAction(string SelectedAction) 
        {
            switch (SelectedAction)
            {
                case "1":
                    ClassOperations classOperations = new ClassOperations();
                    classOperations.ShowClassOptions();
                    break;
                case "2":
                    if (Lists.ClassList.Count<1)
                    {
                        Console.WriteLine("Sınıf eklemeden öğrenci ekleyemezsiniz.");
                        ShowMainOptions();
                    }
                    else
                    {
                        StudentOperations studentOperations=new StudentOperations();
                        studentOperations.ShowStudentOptions();
                    }
                    break;
                case "3":
                    if (Lists.ClassList.Count < 1)
                    {
                        Console.WriteLine("Sınıf eklemeden öğretmen ekleyemezsiniz.");
                        ShowMainOptions();

                    }
                    else
                    {
                        TeacherOperations teacherOperations = new TeacherOperations();
                        teacherOperations.ShowTeacherOptions();
                    }
                    break;
                case "4":
                        SearchOperations searchOperations = new SearchOperations();
                        searchOperations.SearchInSchool();
                    break;
            }
        }


    }
}
