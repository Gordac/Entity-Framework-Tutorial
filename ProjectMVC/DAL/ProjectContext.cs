using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProjectMVC.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjectMVC.DAL
{
    public class ProjectContext : DbContext
    {
        public ProjectContext() : base("ProjectContext")
            {

            }

        public  DbSet<Project> Projects { get; set; }
        public DbSet<ProjectLog> ProjectLogs { get; set; }
        public DbSet<Manager> Managers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove < PluralizingTableNameConvention>();
        }
    }
}