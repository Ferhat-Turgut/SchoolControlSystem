﻿using SchoolControlSystem.Models;
using SchoolControlSystem.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolControlSystem.Operations
{
    public class ClassOperations
    {
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
            bool IsSelectedValueExistOnList = CommonValidations.IsExistOnList(SelectedAction, CommonConstant.CommonConstant.ClassOperationsValidList);
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
                    ShowClassesInList();
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
            string EnteredClassName = Console.ReadLine();

            bool IsEnteredValueExistOnList = CommonValidations.IsExistOnList(EnteredClassName,Lists.ClassList.Select(c=>c.ClassName).ToList());
            if (IsEnteredValueExistOnList)
            {
                Console.WriteLine("Bu sınıf sistemde kayıtlıdır.");
                ShowClassOptions();
            }
            else
            {
                int GeneratedNewClassId = CommonValidations.GetGenerateNewId(Lists.ClassList.Select(c=>c.ClassId).ToList());
                ClassModel classModel = new ClassModel();
                classModel.ClassName = EnteredClassName;
                classModel.ClassId = GeneratedNewClassId;
                Lists.ClassList.Add(classModel);
                Console.WriteLine("Yeni sınıf eklendi.");
                ShowClassOptions();
            }
        }
        public void ShowClassesInList() 
        {
            bool IsClassListEmpty=CommonValidations.IsListEmpty(Lists.ClassList.Select(c=>c.ClassId).ToList());
            if (IsClassListEmpty)
            {
                Console.WriteLine("Sınıf listesi boş.Lütfen kayıt ekleyin.");
            }
            else
            {
                foreach (var item in Lists.ClassList)
                {
                    Console.Write($"Sınıf Id:{item.ClassId}\t");
                    Console.Write($"Sınıf Adı:{item.ClassName}\t");
                    if (string.IsNullOrEmpty(item.Teacher))
                    {
                        Console.WriteLine($"Sınıf Öğretmeni:Atanmadı!");
                    }
                    else
                    {
                        Console.WriteLine($"Sınıf Öğretmeni:{item.Teacher}");
                    }
                }
            }
            ShowClassOptions();
        }
    }
}