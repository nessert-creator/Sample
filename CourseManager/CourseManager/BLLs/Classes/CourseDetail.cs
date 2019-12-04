using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManager.BLLs.Classes
{
    public class CourseDetail
    {
        [Display(Name="班级")]
        public string ClassName { get; set; }
        public string CourseName { get; set; }

        public string TeacherName { get; set; }
    }
}
