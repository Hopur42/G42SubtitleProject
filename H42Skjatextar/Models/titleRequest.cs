using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace H42Skjatextar.Models
{
    public class TitleRequest
    {
        public int Id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public string director { get; set; }
        public string type { get; set; }
        public string genre { get; set; }
    }
}