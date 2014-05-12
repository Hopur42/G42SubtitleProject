using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H42Skjatextar.Models;

namespace H42Skjatextar.DAL
{
    public class VideoTitleRepository
    {
        H42SkjatextarContext db = new H42SkjatextarContext();
        public IEnumerable<VideoTitle> GetAllVideos()
        {
            return db.VideoTitles;
        }
        public VideoTitle GetVideoTitle(string videoTitle)
        {
            var result = (from item in db.VideoTitles
                         where item.title == videoTitle
                         select item).FirstOrDefault();
            return result;
        }
        public void AddVideoTitle(VideoTitle videoTitle)
        {
            db.VideoTitles.Add(videoTitle);
            db.SaveChanges();
        }
    }
}