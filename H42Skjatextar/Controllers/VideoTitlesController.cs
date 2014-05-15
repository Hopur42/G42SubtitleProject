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

        private IVideoTitleRepository repo = null;

        // This constructor is called when the web app is being used by users.
        public VideoTitlesController()
        {
            repo = new VideoTitleRepository();
        }
        
        // This constructor is called when we're testing the controller and we
        // need to use a fake database.
        public VideoTitlesController(IVideoTitleRepository rep)
        {
            repo = rep;
        }
        
        // GET: VideoTitles
        public ActionResult Index()
        {
            return View(repo.GetAllVideos().ToList());
        }

        // GET: VideoTitles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VideoTitle videoTitle = repo.FindVideoTitleById(id);
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
                repo.AddVideoTitle(videoTitle);
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
            VideoTitle videoTitle = repo.FindVideoTitleById(id);
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
                repo.GetDbContext().Entry(videoTitle).State = EntityState.Modified;
                repo.Save();
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
            VideoTitle videoTitle = repo.FindVideoTitleById(id);
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
            VideoTitle videoTitle = repo.FindVideoTitleById(id);
            repo.RemoveVideoTitle(videoTitle);
            repo.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.GetDbContext().Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
