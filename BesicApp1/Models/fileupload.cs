using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BesicApp1.Models
{
    public class fileupload
    {
        [required]
        public HttpPostedFileBase postedFile { get; set; }
        [required]
        public string filename { get; set; }
        [required]
        public string filetype { get; set; }
    }
}