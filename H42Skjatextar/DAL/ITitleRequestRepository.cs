using H42Skjatextar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H42Skjatextar.DAL
{
    public interface ITitleRequestRepository
    {
        IEnumerable<TitleRequest> GetAllRequest();
        TitleRequest GetTitleRequest(string titleRequest);
        void AddTitleRequest(TitleRequest titleRequest);
        void RemoveTitleRequest(TitleRequest titleRequest);
        //void UpdateTitleRequest(string videoTitle);
        void Save();
        TitleRequest FindTitleRequestById(int? id);
        H42SkjatextarContext GetDbContext();
    }
}