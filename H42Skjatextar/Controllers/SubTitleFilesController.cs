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
    public class SubTitleFilesController : Controller
    {
        private H42SkjatextarContext db = new H42SkjatextarContext();

        private ISubTitleFilesRepository repo = null;

        // This constructor is called when the web app is being used by users.
        public SubTitleFilesController()
        {
            repo = new SubTitleFilesRepository();
        }
        
        // This constructor is called when we're testing the controller and we
        // need to use a fake database.
        public SubTitleFilesController(ISubTitleFilesRepository rep)
        {
            repo = rep;
        }

        // GET: SubTitleFiles
        public ActionResult Index()
        {
            return View(repo.GetAllSubTitleFiles());
        }

        // GET: SubTitleFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTitleFiles subTitleFiles = repo.FindSubTitleFileById(id);
            if (subTitleFiles == null)
            {
                return HttpNotFound();
            }
            return View(subTitleFiles);
        }

        // GET: SubTitleFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubTitleFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "fileTitle,titleOfMovie,language,date,director,type,genre")] SubTitleFilesViewModel subTitleFileViewModel)
        {
            SubTitleFiles subTitleFile = new SubTitleFiles();

            subTitleFile.fileTitle = Request.Files["file"].FileName;
            subTitleFile.titleOfMovie = subTitleFileViewModel.titleOfMovie;
            subTitleFile.language = subTitleFileViewModel.language;
            subTitleFile.date = subTitleFileViewModel.date;
            subTitleFile.director = subTitleFileViewModel.director;
            subTitleFile.type = subTitleFileViewModel.type;
            subTitleFile.genre = subTitleFileViewModel.genre;

            subTitleFileViewModel.File = Request.Files["file"];

            BinaryReader b = new BinaryReader(Request.Files["file"].InputStream);
            byte[] binData = b.ReadBytes(Request.Files["file"].ContentLength);

            string result = System.Text.Encoding.UTF8.GetString(binData);

            subTitleFile.theFileInString = result;

            if (ModelState.IsValid)
            {
                repo.AddSubTitleFile(subTitleFile);
                repo.Save();
                return RedirectToAction("Index");
            }

            return View(subTitleFile);
        }

        // GET: SubTitleFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTitleFiles subTitleFiles = repo.FindSubTitleFileById(id);
            if (subTitleFiles == null)
            {
                return HttpNotFound();
            }
            return View(subTitleFiles);
        }

        // POST: SubTitleFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "fileTitle,titleOfMovie,language,date,director,type,genre")] SubTitleFiles subTitleFiles)
        {
            if (ModelState.IsValid)
            {
                repo.GetDbContext().Entry(subTitleFiles).State = EntityState.Modified;
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(subTitleFiles);
        }

        // GET: SubTitleFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubTitleFiles subTitleFiles = repo.FindSubTitleFileById(id);
            if (subTitleFiles == null)
            {
                return HttpNotFound();
            }
            return View(subTitleFiles);
        }

        // POST: SubTitleFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubTitleFiles subTitleFiles = repo.FindSubTitleFileById(id);
            repo.RemoveSubTitleFiles(subTitleFiles);
            repo.Save();
            return RedirectToAction("Index");
        }
    }
}
