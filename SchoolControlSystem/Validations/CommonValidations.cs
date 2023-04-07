using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolControlSystem.Validations
{
    public  class CommonValidations
    {
        public  bool IsExistOnList<T>(T EnteredValue,List<T> SearchList) 
        {
            if (SearchList.Contains(EnteredValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public  int GetGenerateNewId(List<int> Idlist) 
        {
            if (Idlist.Count==0)
            {
                return 1;
            }
            else
            {
                return Idlist.Max() + 1;
            }
        }
        public bool IsListEmpty(List<int> Idlist)
        {
            if (Idlist.Count == 0)
            {
                Console.WriteLine("Listede kayıt yoktur.");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
