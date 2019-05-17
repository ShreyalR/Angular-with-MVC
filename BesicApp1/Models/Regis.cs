using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BesicApp1.Models
{
    public class Regis
    {
        public int REG_ID { get; set; }
        public string F_NAME { get; set; }
        public string M_NAME { get; set; }
        public string L_NAME { get; set; }
        public string DOB { get; set; }
        public string COUNTRY_ID { get; set; }
        public string STATE_ID { get; set; }
        public string CITY_ID { get; set; }
        public string ADDRESS_1 { get; set; }
        public string PHONE_1 { get; set; }
        public string GENDER { get; set; }
        public string PHOTO { get; set; }
        public string IS_ACTIVE { get; set; }
     
    }

    public partial class REGISTRATION_MASTER
    {
        public int REG_ID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string F_NAME { get; set; }
        [Required]
        [Display(Name = "Middle Name")]
        public string M_NAME { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string L_NAME { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        public Nullable<System.DateTime> datetimepicker { get; set; }

        [Required]
        [Display(Name = "Country")]
        public Nullable<int> Country { get; set; }
        [Required]
        [Display(Name = "City")]
        public Nullable<int> City { get; set; }
        [Required]
        [Display(Name = "State")]
        public Nullable<int> State { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string ADDRESS_1 { get; set; }
        [Required]
        [Display(Name = "Phone No")]
        public string PHONE_1 { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Photo")]
        public HttpPostedFileBase PHOTO { get; set; }

        public Nullable<bool> Active { get; set; }

        public Nullable<bool> IS_DELETE { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string User_Name { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Re-Password")]
        [Compare("Password", ErrorMessage = "Please Re-enter Password Again")]
        public string rePassword { get; set; }

    }

    public partial class Registrationmaster
    {
        public int REG_ID { get; set; }
        [Required]
        public string F_NAME { get; set; }
        [Required]
        public string M_NAME { get; set; }
        [Required]
        public string L_NAME { get; set; }

        [Required]
        public string DOB { get; set; }

        [Required]
        public string geoLocation { get; set; }
        [Required]
        public string ADDRESS_1 { get; set; }
        [Required]
        public string PHONE_1 { get; set; }
        [Required]
        public string GENDER { get; set; }
        [Required]
        public string PHOTO { get; set; }
        public string IS_ACTIVE { get; set; }
        public Nullable<bool> IS_DELETE { get; set; }
        public string CREATED_ON { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
    }

    public partial class Add_REGISTRATION_MASTER
    {
        public int REG_ID { get; set; }
        [Required]
        public string F_NAME { get; set; }
        [Required]
        public string M_NAME { get; set; }
        [Required]
        public string L_NAME { get; set; }

        [Required]
        public Nullable<System.DateTime> datetimepicker { get; set; }

        public List<Country> Country { get; set; }
        public List<State> State { get; set; }
        public List<City> City { get; set; }


        [Required]
        public Nullable<int> CountryID { get; set; }
        [Required]
        public Nullable<int> StateID { get; set; }
        [Required]
        public Nullable<int> CityID { get; set; }
        [Required]
        public string ADDRESS_1 { get; set; }
        [Required]
        public string PHONE_1 { get; set; }
        [Required]
        public string Gender { get; set; }


        public HttpPostedFileBase PHOTO { get; set; }

        public string PHOTO_path { get; set; }

        public string Active { get; set; }

        public Nullable<bool> IS_DELETE { get; set; }
        public Nullable<System.DateTime> CREATED_ON { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
    }
}