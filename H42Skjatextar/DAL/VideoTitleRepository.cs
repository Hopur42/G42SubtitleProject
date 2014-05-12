using H42Skjatextar.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H42Skjatextar.DAL
{
    public class VideoTitleRepository
    {
        H42SkjatextarContext db = new H42SkjatextarContext();
        public IEnumerable<VideoTitle> GetAllVideoTitle()
        {
            return db.VideoTitles;
        }
        public IEnumerable<VideoTitle> GetVideoTitle(string Title)
        {
            var result = from item in db.VideoTitles
                         where item.title == Title
                         select item;
            return result;
        }
        public void AddVideoTitle(VideoTitle item)
        {
            db.VideoTitles.Add(item);
            db.SaveChanges();
        }
    }
}