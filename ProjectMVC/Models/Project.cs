using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models
{
    public class Project
    {
        [Key]
        public int ID { get; set; }
        public string name { get; set; }
        public DateTime projTime { get; set; }

        public virtual ICollection<ProjectLog> projLog { get; set; }
    }
}