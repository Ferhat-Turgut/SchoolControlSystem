using SchoolControlSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolControlSystem
{
    //Herhangi bir class'tan, nesne üretmeden listelere ulaşmak için static class olarak tanımladık.
    public static class Lists
    {
        public static List<ClassModel> ClassList= new List<ClassModel>();
        public static List<StudentModel> StudenList = new List<StudentModel>();
        public static List<TeacherModel> TeacherList = new List<TeacherModel>();
    }
}
