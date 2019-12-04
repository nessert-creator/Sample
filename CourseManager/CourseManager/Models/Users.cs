namespace CourseManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "�û��˺�")]
        public string Account { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name="�û���")]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "�û�����")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
