using H42Skjatextar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H42Skjatextar.ViewModel
{
    public class TitleRequestViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "required")]
        public string name { get; set; }
        
        public DateTime date { get; set; }

        public string director { get; set; }

        [Required(ErrorMessage = "required")]
        public string type { get; set; }

        public string genre { get; set; }

        public virtual ICollection<TitleRequest> TiteRequest { get; set; }
    }
}