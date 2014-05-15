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

        private ITitleRequestRepository repo = null;

        // This constructor is called when the web app is being used by users.
        public TitleRequestController()
        {
            repo = new TitleRequestRepository();
        }
        
        // This constructor is called when we're testing the controller and we
        // need to use a fake database.
        public TitleRequestController(ITitleRequestRepository rep)
        {
            repo = rep;
        }

        // GET: /TitleRequest/
        public ActionResult Index()
        {
            return View(repo.GetAllRequest());
        }

        // GET: /TitleRequest/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleRequest titleRequest = repo.FindTitleRequestById(id);
            if (titleRequest == null)
            {
                return HttpNotFound();
            }
            return View(titleRequest);
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
        public ActionResult Create([Bind(Include="Id,name,date,director,type,genre,language")] TitleRequest titleRequest)
        {
            if (ModelState.IsValid)
            {
                repo.AddTitleRequest(titleRequest);
                repo.Save();
                return RedirectToAction("Index");
            }

            return View(titleRequest);
        }

        // GET: /TitleRequest/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleRequest titleRequest = repo.FindTitleRequestById(id);
            if (titleRequest == null)
            {
                return HttpNotFound();
            }
            return View(titleRequest);
        }

        // POST: /TitleRequest/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,name,year,director,type,genre")] TitleRequest titleRequest)
        {
            if (ModelState.IsValid)
            {
                repo.GetDbContext().Entry(titleRequest).State = EntityState.Modified;
                repo.Save();
                return RedirectToAction("Index");
            }
            return View(titleRequest);
        }

        // GET: /TitleRequest/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TitleRequest titleRequest = repo.FindTitleRequestById(id);
            if (titleRequest == null)
            {
                return HttpNotFound();
            }
            return View(titleRequest);
        }

        // POST: /TitleRequest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TitleRequest titleRequest = repo.FindTitleRequestById(id);
            repo.RemoveTitleRequest(titleRequest);
            repo.Save();
            return RedirectToAction("Index");
        }
    }
}
