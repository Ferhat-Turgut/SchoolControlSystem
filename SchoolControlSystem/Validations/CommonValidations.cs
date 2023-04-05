using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolControlSystem.Validations
{
    public static class CommonValidations
    {
        public static bool IsExistOnList(string EnteredValue,List<string> SearchList) 
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
        public static int GetGenerateNewId(List<int> Idlist) 
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
        public static bool  IsListEmpty(List<int> IdList) 
        {
            if (IdList.Count==0)
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
    }
}
