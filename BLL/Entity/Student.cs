using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entity
{
    public class Student
    {
        public int St_Id { get; set; }
        public string? St_Fname { get; set; }
        public string? St_Lname { get; set; }
        public string? St_Address { get; set; }
        public int? St_Age { get; set; }
        //public int? Dept_Id { get; set; }
        //public int? St_super { get; set; }
    }
}
