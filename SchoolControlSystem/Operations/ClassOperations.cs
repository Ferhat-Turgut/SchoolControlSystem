using SchoolControlSystem.Models;
using SchoolControlSystem.Validations;

namespace SchoolControlSystem.Operations
{
    public class ClassOperations : CommonOperations
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
            bool IsSelectedValueExistOnList = classValidations.IsExistOnList(SelectedAction, CommonConstant.ClassOperationsValidList);

            while (!IsSelectedValueExistOnList)
            {
                Console.WriteLine("Lütfen geçerli bir seçenek giriniz!");
                SelectedAction = Console.ReadLine();
                IsSelectedValueExistOnList = CommonConstant.ClassOperationsValidList.Contains(SelectedAction);
            }
            RedirectToSelectedClassAction(SelectedAction);
           
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
            string EnteredClassName = Console.ReadLine().ToLower();

            if (Lists.ClassList.Any(c => c.Name == EnteredClassName))
            {
                Console.WriteLine("Bu sınıf sistemde kayıtlıdır.");
                ShowClassOptions();
            }
            else
            {
                int GeneratedNewClassId = GetGenerateNewId(Lists.ClassList.Select(c => c.Id).ToList());
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
            if (Lists.ClassList.Count != 0)
            {
                foreach (var item in Lists.ClassList)
                {
                    Console.Write($"Sınıf Id:{item.Id}\t Sınıf Adı:{item.Name}\t ");

                    var TeacherModel = Lists.TeacherList.FirstOrDefault(t => t.Id == item.TeacherId);
                    if (TeacherModel != null)
                    {
                        Console.WriteLine($"Öğretmen Adı:{TeacherModel.Name}\t Öğretmen Soyadı:{TeacherModel.Surname}");
                    }
                    else
                    {
                        Console.WriteLine("Öğretmen Adı:Kayıt yok.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Listede kayıt yoktur.");
            }
            ShowClassOptions();
        }

    }
}
