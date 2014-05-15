using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H42Skjatextar.Models
{
    public class SubTitleFiles
    {
        public string titleOfMovie { get; set; }
        public string fileTitle { get; set; }
        public int Id { get; set; }
        public int fileUserId { get; set; }
        public string language { get; set; }
        public DateTime date { get; set; }
        public string director { get; set; }
        public string type { get; set; }
        public string genre { get; set; }

    }
}