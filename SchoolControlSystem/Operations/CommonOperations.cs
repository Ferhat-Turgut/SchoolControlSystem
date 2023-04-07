using SchoolControlSystem.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SchoolControlSystem.Operations
{
    public  class CommonOperations
    {
        public void GetList(List<object> getList)
        {
            foreach (var item in getList)
            {
                Console.WriteLine(item);
            }
        }
       
        
    }
}
