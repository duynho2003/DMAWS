using Lab08AzureFunction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08AzureFunction.Service
{
    public class StudentService
    {
        public static List<Student> sList = new List<Student>()
        {
            new Student{code="Student202301",name="Tai Phan", year=19},
            new Student{code="Student202302",name="Quang Teo", year=20},
            new Student{code="Student202303",name="Hai Tu", year=18}
        };
    }
}
