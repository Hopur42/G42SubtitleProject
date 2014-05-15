using H42Skjatextar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace H42Skjatextar.ViewModel
{
    public class SubTitleFilesViewModel
    {
        [FileSize(1000)]
        [FileTypes("srt")]
        public HttpPostedFileBase File { get; set; }

        [Required(ErrorMessage = "required")]
        public string titleOfMovie { get; set; }

        [Required(ErrorMessage = "required")]
        public string fileTitle { get; set; }

        [key]
        public int fileId { get; set; }
        
       
        public int fileUserId { get; set; }

        [Required(ErrorMessage = "required")]
        public string language { get; set; }

        public DateTime date { get; set; }

        public string director { get; set; }

        [Required(ErrorMessage = "required")]
        public string type { get; set; }

        public string genre { get; set; }

        public virtual ICollection<SubTitleFiles> SubTiteFile { get; set; }

        internal void saveAs(string path)
        {
            throw new NotImplementedException();
        }
    }
}