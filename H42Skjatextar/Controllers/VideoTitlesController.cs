using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using H42Skjatextar.DAL;
using H42Skjatextar.Models;
using H42Skjatextar.ViewModel;
using System.IO;

namespace H42Skjatextar.Controllers
{
    public class VideoTitlesController : Controller
    {
        private H42SkjatextarContext db = new H42SkjatextarContext();
        
        
        // GET: VideoTitles
        public ActionResult Index()
        {
            return View(db.VideoTitles.ToList());
        }
        // GET: VideoTitles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoTitle videoTitle = db.VideoTitles.Find(id);
            if (videoTitle == null)
            {
                return HttpNotFound();
            }
            return View(videoTitle);
        }

        [HttpPost]
        public ActionResult UploadFile(SubTitleFilesViewModel file)
        {
            
            return View();
        }

        // GET: VideoTitles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VideoTitles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,title")] VideoTitle videoTitle)
        {
            if (ModelState.IsValid)
            {
                db.VideoTitles.Add(videoTitle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(videoTitle);
        }

        // GET: VideoTitles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoTitle videoTitle = db.VideoTitles.Find(id);
            if (videoTitle == null)
            {
                return HttpNotFound();
            }
            return View(videoTitle);
        }

        // POST: VideoTitles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,title")] VideoTitle videoTitle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(videoTitle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(videoTitle);
        }

        // GET: VideoTitles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoTitle videoTitle = db.VideoTitles.Find(id);
            if (videoTitle == null)
            {
                return HttpNotFound();
            }
            return View(videoTitle);
        }

        // POST: VideoTitles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VideoTitle videoTitle = db.VideoTitles.Find(id);
            db.VideoTitles.Remove(videoTitle);
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
