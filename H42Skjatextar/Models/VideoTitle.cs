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
        
        // Stores information about each SubtitleFile belonging to a certain VideoTitle.
        //public virtual ICollection<SubtitleFile> subtitleFiles { get; set; }
    }
}