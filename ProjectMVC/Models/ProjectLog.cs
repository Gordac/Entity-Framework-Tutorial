using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models
{
    public enum Status
    {
        Done, Active, Delayed, Cancelled 
    }
    public class ProjectLog
    {
        [Key]
        public int LogID { get; set; }
        public int ManagerID { get; set; }
        public int ProjectID { get; set; }

        public virtual Manager Manager { get; set; }
        public virtual Project Project { get; set; }
    }
}