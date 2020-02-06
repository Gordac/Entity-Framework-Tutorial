using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.Models
{
    public class Manager
    {   [DatabaseGenerated(DatabaseGeneratedOption.None)]
       
        [Key]
        public int ManagerID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }

        public virtual ICollection<ProjectLog> ProjectLogs {get; set;}
    }
}