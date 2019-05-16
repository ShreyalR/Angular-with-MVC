using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BesicApp1.Models;

namespace BesicApp1.Controllers
{
    public class HomeController : Controller
    {
        Demo1Entities db = new Demo1Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            List<object> ab = new List<object>();
             
            ViewBag.country = db.TBL_COUNTRY_MASTER.ToList();
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod(string name)
        {
            PersonModel person = new PersonModel
            {
                Name = name,
                DateTime = DateTime.Now.ToString()
            };
            return Json(person);
        }
        [HttpPost]
        public JsonResult AjaxMethod2(PersonModel2 name)
        {
            PersonModel2 person = new PersonModel2
            {
                FName = name.FName,
                MName = name.MName,
                LName = name.LName,
                Age = name.Age,
            };
            return Json(person);
        }

        [HttpGet]
        public JsonResult GetCountry()
        {
            List<TBL_COUNTRY_MASTER> TCM = new List<TBL_COUNTRY_MASTER>();

            TCM = db.TBL_COUNTRY_MASTER.ToList();
            return Json(TCM, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public void Upload(System.Web.HttpPostedFileBase aFile)
        {
            string path = Server.MapPath("~/Upload//");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string file = aFile.FileName;
            //string path = Server.MapPath("../Upload//");
            aFile.SaveAs(path + Guid.NewGuid() + "." + file.Split('.')[1]);
        }
        [HttpPost]
        public JsonResult login(USER_MASTER UM)
        {
            try
            {
                if (UM.USER_NAME.ToString() != null && UM.USER_NAME.ToString() != "" && UM.PASSWORD.ToString() != null && UM.PASSWORD.ToString() != "")
                {
                    string username = UM.USER_NAME.ToString();
                    string password = UM.PASSWORD.ToString();
                    var checklogin = db.TBL_USER_MASTER.Where(x => x.USER_NAME == username && x.PASSWORD == password && x.IS_ACTIVE == true && (x.IS_DELETE == null || x.IS_DELETE == false)).FirstOrDefault();
                    if (checklogin != null)
                    {
                        Session["user_login"] = "1";
                        return Json("../Client/");

                    }
                    else
                    {
                        ViewBag.Message = "UserName or password is wrong";
                        return Json(RStatus("300", "UserName or password is wrong"));
                    }
                }
                else
                {
                    ViewBag.Message = "UserName and password is wrong";
                    return Json(RStatus("300", "UserName or password is wrong"));
                }
            }
            catch (Exception)
            {
                return Json(RStatus("300", "UserName or password is wrong"));
            }


           // return View();

        }

        [HttpPost]
        public ActionResult Country()
        {
            // geoloc ab = new geoloc();
            List<Country> Countries = new List<Country>();
            foreach (var country in db.TBL_COUNTRY_MASTER)
            {
                Countries.Add(new Country
                {
                    Text = country.COUNTRY_NAME,
                    Value = country.COUNTRY_ID.ToString()
                });
            }

            return Json(Countries);
        }
        [HttpPost]
        public ActionResult State(int id)
        {
            // geoloc ab = new geoloc();
            List<State> State = new List<State>();
            foreach (var States in db.TBL_STATE_MASTER.Where(e => e.COUNTRY_ID == id))
            {
                State.Add(new State
                {
                    Text = States.STATE_NAME,
                    Value = States.STATE_ID.ToString()
                });
            }

            return Json(State);
        }

        [HttpPost]
        public ActionResult City(int id)
        {
            // geoloc ab = new geoloc();
            List<City> City = new List<City>();
            foreach (var Ct in db.TBL_CITY_MASTER.Where(e => e.STATE_ID == id))
            {
                City.Add(new City
                {
                    Text = Ct.CITY_NAME,
                    Value = Ct.CITY_ID.ToString()
                });
            }

            return Json(City);
        }

        public List<status> RStatus(string code, string msg)
        {
            List<status> SM = new List<status>();
            SM.Add(new status {
                statusCode = code,
                StatusMsg = msg
            });
            return SM;
        }
    }
}