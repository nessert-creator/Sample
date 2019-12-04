using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseManager.Models;

namespace CourseManager.Controllers
{
    public class ActionLinkController : Controller
    {
        private CourseManagerEntities db = new CourseManagerEntities();

        // GET: ActionLink
        public ActionResult Index()
        {
            return View(db.ActionLinks.ToList());
        }

        // GET: ActionLink/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionLinks actionLinks = db.ActionLinks.Find(id);
            if (actionLinks == null)
            {
                return HttpNotFound();
            }
            return View(actionLinks);
        }

        // GET: ActionLink/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActionLink/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Controller,Action")] ActionLinks actionLinks)
        {
            if (ModelState.IsValid)
            {
                db.ActionLinks.Add(actionLinks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(actionLinks);
        }

        // GET: ActionLink/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionLinks actionLinks = db.ActionLinks.Find(id);
            if (actionLinks == null)
            {
                return HttpNotFound();
            }
            return View(actionLinks);
        }

        // POST: ActionLink/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Controller,Action")] ActionLinks actionLinks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(actionLinks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actionLinks);
        }

        // GET: ActionLink/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ActionLinks actionLinks = db.ActionLinks.Find(id);
            if (actionLinks == null)
            {
                return HttpNotFound();
            }
            return View(actionLinks);
        }

        // POST: ActionLink/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ActionLinks actionLinks = db.ActionLinks.Find(id);
            db.ActionLinks.Remove(actionLinks);
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
