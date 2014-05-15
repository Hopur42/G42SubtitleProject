using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H42Skjatextar.Models;
using System.Text.RegularExpressions;

namespace H42Skjatextar.DAL
{
    public interface IVideoTitleRepository //: IDisposable
    {
        IEnumerable<VideoTitle> GetAllVideos();
        VideoTitle GetVideoTitle(string videoTitle);
        void AddVideoTitle(VideoTitle videoTitle);
        void RemoveVideoTitle(VideoTitle videoTitle);
        //void UpdateVideoTitle(string videoTitle);
        void Save();
        VideoTitle FindVideoTitleById(int? id);
        H42SkjatextarContext GetDbContext();
    }
}