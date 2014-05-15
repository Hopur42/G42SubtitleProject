using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H42Skjatextar.Models;

namespace H42Skjatextar.DAL
{
    public class VideoTitleRepository : IVideoTitleRepository
    {
        private H42SkjatextarContext db = new H42SkjatextarContext();

        public IEnumerable<VideoTitle> GetAllVideos()
        {
            return db.videoTitles;
        }

        public VideoTitle FindVideoTitleById(int? id)
        {
            return db.videoTitles.Find(id);
        }

        public VideoTitle GetVideoTitle(string videoTitle)
        {
            var result = (from item in db.videoTitles
                         where item.title == videoTitle
                         select item).FirstOrDefault();
            return result;
        }
        public void AddVideoTitle(VideoTitle videoTitle)
        {
            db.videoTitles.Add(videoTitle);
            db.SaveChanges();
        }
        public void RemoveVideoTitle(VideoTitle videoTitle)
        {
            db.videoTitles.Remove(videoTitle);
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