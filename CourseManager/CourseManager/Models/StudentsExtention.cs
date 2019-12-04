using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManager.Models
{
    public partial class Students
    {
        public string ClassName {
            get {
                CourseManagerEntities db = new CourseManagerEntities();
                var cls = db.Classes.Where(t => t.Id == ClassId).FirstOrDefault();
                if (cls == null)
                {
                    return "";
                }
                return cls.Name;
            }
        }
    }
}