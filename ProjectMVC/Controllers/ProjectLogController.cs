using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectMVC.DAL;
using ProjectMVC.Models;

namespace ProjectMVC.Controllers
{
    public class ProjectLogController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: ProjectLog
        public ActionResult Index()
        {
            var projectLogs = db.ProjectLogs.Include(p => p.Manager).Include(p => p.Project);
            return View(projectLogs.ToList());
        }

        // GET: ProjectLog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectLog projectLog = db.ProjectLogs.Find(id);
            if (projectLog == null)
            {
                return HttpNotFound();
            }
            return View(projectLog);
        }

        // GET: ProjectLog/Create
        public ActionResult Create()
        {
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "firstName");
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "name");
            return View();
        }

        // POST: ProjectLog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LogID,ManagerID,ProjectID")] ProjectLog projectLog)
        {
            if (ModelState.IsValid)
            {
                db.ProjectLogs.Add(projectLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "firstName", projectLog.ManagerID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "name", projectLog.ProjectID);
            return View(projectLog);
        }

        // GET: ProjectLog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectLog projectLog = db.ProjectLogs.Find(id);
            if (projectLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "firstName", projectLog.ManagerID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "name", projectLog.ProjectID);
            return View(projectLog);
        }

        // POST: ProjectLog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LogID,ManagerID,ProjectID")] ProjectLog projectLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ManagerID = new SelectList(db.Managers, "ManagerID", "firstName", projectLog.ManagerID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "name", projectLog.ProjectID);
            return View(projectLog);
        }

        // GET: ProjectLog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectLog projectLog = db.ProjectLogs.Find(id);
            if (projectLog == null)
            {
                return HttpNotFound();
            }
            return View(projectLog);
        }

        // POST: ProjectLog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectLog projectLog = db.ProjectLogs.Find(id);
            db.ProjectLogs.Remove(projectLog);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
