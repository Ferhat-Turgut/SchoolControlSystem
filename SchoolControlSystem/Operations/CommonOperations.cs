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
        public  int GetGenerateNewId(List<int> Idlist)
        {
            if (Idlist.Count == 0)
            {
                return 1;
            }
            else
            {
                return Idlist.Max() + 1;
            }
        }

    }
}
