using SchoolControlSystem.Validations;

namespace SchoolControlSystem.Operations
{
    public  class MainOperations
    {
        MainValidations mainValidations=new MainValidations();
        public  void ShowMainOptions() 
        {
            Console.WriteLine("Sınıf işlemleri için 1'e\n" +
                              "Öğrenci işlemleri için 2'ye\n" +
                              "Öğretmen işlemleri için 3'e\n" +
                              "Arama işlemleri için 4'e\n" +
                              "Çıkış için 5'e basınız.");
            string SelectedAction=Console.ReadLine();
            SelectedValueValidCheck(SelectedAction);
        }
        public void SelectedValueValidCheck(string SelectedAction) 
        {
            bool IsSelectedValueExistOnList = CommonConstant.MainOperationsValidList.Contains(SelectedAction);
    
            while (!IsSelectedValueExistOnList)
            {
                Console.WriteLine("Lütfen geçerli bir seçenek giriniz!");
                SelectedAction = Console.ReadLine();
                IsSelectedValueExistOnList= CommonConstant.MainOperationsValidList.Contains(SelectedAction);
            }
            RedirectToSelectedAction(SelectedAction);

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
                    if (Lists.ClassList.Count==0)
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
                    if (Lists.ClassList.Count ==0)
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
                case "5":
                    Environment.Exit(0);
                    break;
            }
        }


    }
}
