using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using H42Skjatextar.Models;

namespace H42Skjatextar.DAL
{
    public class H42SkjatextarInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<H42SkjatextarContext>
    {
        protected override void Seed(H42SkjatextarContext context)
        {
            var videoTitles = new List<VideoTitle>
            {
                new VideoTitle{title="Captain America: The Winter Soldier",ID=2},
                new VideoTitle{title="Clerks II",ID=3},
                new VideoTitle{title="Office Space",ID=5},
            };
            videoTitles.ForEach(s => context.VideoTitles.Add(s));
            context.SaveChanges();
        }
    }
}