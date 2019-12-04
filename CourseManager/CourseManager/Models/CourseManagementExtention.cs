using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManager.Models
{
    public partial class CourseManagements
    {
        public string TeacherName
        {
            get
            {
                CourseManagerEntities db = new CourseManagerEntities();
                var teacher = db.Teachers.Where(t => t.Id == TeacherId).FirstOrDefault();
                if (teacher == null)
                {
                    return "";
                }
                return teacher.Name;
            }
        }

        public string ClassName
        {
            get
            {
                CourseManagerEntities db = new CourseManagerEntities();
                var cls = db.Classes.Where(t => t.Id == ClassId).FirstOrDefault();
                if (cls == null)
                {
                    return "";
                }
                return cls.Name;
            }
        }



        public string CourseName
        {
            get
            {
                CourseManagerEntities db = new CourseManagerEntities();
                var course = db.Course.Where(t => t.Id == CourseId).FirstOrDefault();
                if (course == null)
                {
                    return "";
                }
                return course.Name;
            }
        }
    }
}