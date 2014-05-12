﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using H42Skjatextar.Models;

namespace H42Skjatextar.DAL
{
    public interface IVideoTitleRepository : IDisposable
    {
        IEnumerable<VideoTitle> GetAllVideos();
        VideoTitle GetVideoTitle(string videoTitle);
        void AddVideoTitle(string videoTitle);
        //void RemoveVideoTitle(string videoTitle);
        //void UpdateVideoTitle(string videoTitle);
        //void Save();
    }
}