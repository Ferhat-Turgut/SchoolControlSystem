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
        public bool IsInt(string EnteredValue) 
        {
            if (int.TryParse(EnteredValue, out int result))
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
