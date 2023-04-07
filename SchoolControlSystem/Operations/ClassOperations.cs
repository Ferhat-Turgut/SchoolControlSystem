using SchoolControlSystem.Models;
using SchoolControlSystem.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolControlSystem.Operations
{
    public class ClassOperations:CommonOperations
    {
        ClassValidations classValidations = new ClassValidations();
        public void ShowClassOptions()
        {
            Console.WriteLine("Sınıf eklemek için 1'e\n" +
                              "Sınıfları listelemek için 2'ye\n " +
                              "Ana girişe dönmek için 3'e basınız");
                           
            string SelectedClassAction = Console.ReadLine();
            SelectedClassActionValidityCheck(SelectedClassAction);
            
        }
        public void SelectedClassActionValidityCheck(string SelectedAction)
        {
            bool IsSelectedValueExistOnList = classValidations.IsExistOnList(SelectedAction, CommonConstant.CommonConstant.ClassOperationsValidList);
            if (IsSelectedValueExistOnList)
            {
                RedirectToSelectedClassAction(SelectedAction);
            }
            else
            {
                Console.WriteLine("Lütfen geçerli bir seçenek giriniz!");
                ShowClassOptions();
            }
        }
        public void RedirectToSelectedClassAction(string SelectedAction) 
        {
            switch (SelectedAction)
            {
                case "1":
                    AddNewClass();
                    break;
                case "2":
                    ShowClassesList();
                    break;
                case "3":
                    MainOperations mainOperations = new MainOperations();
                    mainOperations.ShowMainOptions();
                    break;
               
            }
        }
        public void AddNewClass() 
        {
            Console.WriteLine("Lütfen sınıf adı giriniz:");
            string EnteredClassName = Console.ReadLine().ToUpper();

            bool IsEnteredClassExistOnList = classValidations.IsExistOnList(EnteredClassName,Lists.ClassList.Select(c=>c.Name).ToList());
            if (IsEnteredClassExistOnList)
            {
                Console.WriteLine("Bu sınıf sistemde kayıtlıdır.");
                ShowClassOptions();
            }
            else
            {
                int GeneratedNewClassId = classValidations.GetGenerateNewId(Lists.ClassList.Select(c=>c.Id).ToList());
                ClassModel classModel = new ClassModel();
                classModel.Id = GeneratedNewClassId;
                classModel.Name = EnteredClassName;
                Lists.ClassList.Add(classModel);
                Console.WriteLine("Yeni sınıf eklendi.");
                ShowClassOptions();
            }
        }
        public void ShowClassesList() 
        {
            bool IsClassListEmpty=classValidations.IsListEmpty(Lists.ClassList.Select(c=>c.Id).ToList());
            if (!IsClassListEmpty)
            {
                foreach (var item in Lists.ClassList)
                {
                    Console.Write($"Sınıf Id:{item.Id}\t");
                    Console.Write($"Sınıf Adı:{item.Name}\t");
                    Console.WriteLine($"Sınıf Öğretmeni:{item.Teacher}\t");

                }
            }
            ShowClassOptions();
        }

    }
}
