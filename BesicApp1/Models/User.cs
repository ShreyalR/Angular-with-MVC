using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BesicApp1.Models
{
    public class User
    {
    }
    public partial class USER_MASTER
    {
        public int USERID { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string USER_NAME { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string PASSWORD { get; set; }
    }
}