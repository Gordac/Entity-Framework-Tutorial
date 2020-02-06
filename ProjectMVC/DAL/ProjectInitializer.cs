using ProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMVC.DAL
{
    public class ProjectInitializer : System.Data.Entity. DropCreateDatabaseIfModelChanges<ProjectContext>
    {
        protected override void Seed(ProjectContext context)
        {
            var projects = new List<Project>
            {
                new Project{name="Data Collection", projTime = DateTime.Parse("2020-01-15")},
                new Project{name="Frontend design", projTime = DateTime.Parse("2018-07-11")},
                new Project{name="Backend testing", projTime = DateTime.Parse("2013-02-20")},
                new Project{name="Story testing", projTime = DateTime.Parse("2019-03-01")}
            };

            projects.ForEach(s => context.Projects.Add(s));
            context.SaveChanges(); //Behövs ej men hjälper till att lokalisera problem vid eventuellt fel när det skrivs till databasen

            var projectLogs = new List<ProjectLog>
            {
                new ProjectLog {LogID = 11, ProjectID=1, ManagerID=1000},
                new ProjectLog {LogID = 12, ProjectID=2, ManagerID=1001},
                new ProjectLog {LogID = 13, ProjectID=3, ManagerID=1002},
                new ProjectLog {LogID = 14, ProjectID=4, ManagerID=1001}
            };

            projectLogs.ForEach(s => context.ProjectLogs.Add(s));
            context.SaveChanges();

            var managers = new List<Manager>
            {
                new Manager {ManagerID=1000, firstName="John", lastName="Svensson"},
                new Manager {ManagerID=1001, firstName="Kim", lastName="Olsson"},
                new Manager {ManagerID=1002, firstName="David", lastName="Björk"}
            };

            managers.ForEach(s => context.Managers.Add(s));
            context.SaveChanges();
            
        }
    }
}