using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseManager.Models
{

    public class WebsiteInfo
    {
        public const string SiteName = "课程管理系统";

        public List<ActionLinks> ActionLinks { get; set; }


        //public WebsiteInfo()
        //{
        //    ActionLinks = new List<ActionLink> {
        //        new ActionLink{ Name="主页", Controller="Home", Action="Index"},
        //        new ActionLink{ Name="关于", Controller="Home", Action="About"},
        //        new ActionLink{ Name="联系方式", Controller="Home", Action="Contact"}
        //    };
        //}
    }
}