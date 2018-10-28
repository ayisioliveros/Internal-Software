using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrackerModuleV1._0.Models.PTM
{
    public class User
    {
        //public User()
        //{
        //    this.projects = new HashSet<Project>();        }
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string JobRole { get; set; }
        //public int ProjectNumber { get; set; }
        //public Project Project { get; set; }
        public ICollection<Part> Parts { get; set; }
        public virtual ICollection<Project> projects { get; set; }
    }
}