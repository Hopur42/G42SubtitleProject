using H42Skjatextar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H42Skjatextar.DAL
{
    public class TitleRequestRepository : ITitleRequestRepository
    {
        private H42SkjatextarContext db = new H42SkjatextarContext();

        public IEnumerable<TitleRequest> GetAllRequest()
        {
            return db.titleRequests;
        }

        public TitleRequest FindTitleRequestById(int? id)
        {
            return db.titleRequests.Find(id);
        }

        public TitleRequest GetTitleRequest(string titleRequest)
        {
            var result = (from item in db.titleRequests
                          where item.name == titleRequest
                          select item).FirstOrDefault();
            return result;
        }
        public void AddTitleRequest(TitleRequest titleRequest)
        {
            db.titleRequests.Add(titleRequest);
            db.SaveChanges();
        }
        public void RemoveTitleRequest(TitleRequest titleRequest)
        {
            db.titleRequests.Remove(titleRequest);
            db.SaveChanges();
        }
        public void Save()
        {
            db.SaveChanges();
        }

        public H42SkjatextarContext GetDbContext()
        {
            return db;
        }
    }
}