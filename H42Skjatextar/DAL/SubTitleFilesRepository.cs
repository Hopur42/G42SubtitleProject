using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H42Skjatextar.Models;

namespace H42Skjatextar.DAL
{
    public class SubTitleFilesRepository : ISubTitleFilesRepository
    {
        private H42SkjatextarContext db = new H42SkjatextarContext();

        public IEnumerable<SubTitleFiles> GetAllSubTitleFiles()
        {
            return db.subTitleFiles;
        }

        public SubTitleFiles FindSubTitleFileById(int? id)
        {
            return db.subTitleFiles.Find(id);
        }

        public SubTitleFiles GetSubTitleFile(string subTitleFiles)
        {
            var result = (from item in db.subTitleFiles
                          where item.fileTitle == subTitleFiles
                          select item).FirstOrDefault();
            return result;
        }
        public void AddSubTitleFile(SubTitleFiles subTitleFiles)
        {
            db.subTitleFiles.Add(subTitleFiles);
            db.SaveChanges();
        }
        public void RemoveSubTitleFiles(SubTitleFiles subTitleFiles)
        {
            db.subTitleFiles.Remove(subTitleFiles);
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