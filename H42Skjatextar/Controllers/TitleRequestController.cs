using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using H42Skjatextar.Models;
using H42Skjatextar.DAL;

namespace H42Skjatextar.Controllers
{
    public class TitleRequestController : Controller
    {
        private H42SkjatextarContext db = new H42SkjatextarContext();

        // GET: /TitleRequest/
        public ActionResult Index()
        {
            return View(db.titleRequests.ToList());
        }

        // GET: /TitleRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleRequest titlerequest = db.titleRequests.Find(id);
            if (titlerequest == null)
            {
                return HttpNotFound();
            }
            return View(titlerequest);
        }

        // GET: /TitleRequest/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TitleRequest/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,name,year,director,type,genre")] TitleRequest titlerequest)
        {
            if (ModelState.IsValid)
            {
                db.titleRequests.Add(titlerequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(titlerequest);
        }

        // GET: /TitleRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleRequest titlerequest = db.titleRequests.Find(id);
            if (titlerequest == null)
            {
                return HttpNotFound();
            }
            return View(titlerequest);
        }

        // POST: /TitleRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,name,year,director,type,genre")] TitleRequest titlerequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(titlerequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(titlerequest);
        }

        // GET: /TitleRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleRequest titlerequest = db.titleRequests.Find(id);
            if (titlerequest == null)
            {
                return HttpNotFound();
            }
            return View(titlerequest);
        }

        // POST: /TitleRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TitleRequest titlerequest = db.titleRequests.Find(id);
            db.titleRequests.Remove(titlerequest);
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
