using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H42Skjatextar.Models
{
    public class SubTitleFiles
    {
        public int id { get; set; }
        public int fileUserId { get; set; }
        public int videoTitleId { get; set; }
        public string fileTitle { get; set; }
        public string titleOfMovie { get; set; }
        public string language { get; set; }
        public DateTime date { get; set; }
        public string director { get; set; }
        public string type { get; set; }
        public string genre { get; set; }

        public string theFileInString { get; set; }
    }
}