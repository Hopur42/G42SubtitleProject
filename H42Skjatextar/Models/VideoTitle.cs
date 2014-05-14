using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H42Skjatextar.Models
{
    // This class is for storing information about each video that there are subtitle files for.
    public class VideoTitle
    {
        public string title { get; set; }
        public int ID { get; set; }
        public string imdbLink { get; set; }
        public string typeOfVideo { get; set; }
    }
}