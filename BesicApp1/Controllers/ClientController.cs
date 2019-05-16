using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BesicApp1.Models;

namespace BesicApp1.Controllers
{
    public class ClientController : Controller
    {
        private Demo1Entities db = new Demo1Entities();

        // GET: Client
        public ActionResult Index()
        {
            return View(db.TBL_REGISTRATION_MASTER.ToList());
        }
        [HttpGet]
        public JsonResult GetClient()
        {
           // List<TBL_REGISTRATION_MASTER> um = db.TBL_REGISTRATION_MASTER.Where(e => e.IS_DELETE != true).ToList();
            return Json(Client(), JsonRequestBehavior.AllowGet);
        }

        // GET: Client/Details/5
        [HttpPost]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_REGISTRATION_MASTER tBL_REGISTRATION_MASTER = db.TBL_REGISTRATION_MASTER.Find(id);
            if (tBL_REGISTRATION_MASTER == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (tBL_REGISTRATION_MASTER.IS_ACTIVE == true)
                {
                    tBL_REGISTRATION_MASTER.IS_ACTIVE = false;
                }
                else
                {
                    tBL_REGISTRATION_MASTER.IS_ACTIVE = true;
                }
                db.Entry(tBL_REGISTRATION_MASTER).State = EntityState.Modified;
                db.SaveChanges();
            }
           // List<TBL_REGISTRATION_MASTER> um = db.TBL_REGISTRATION_MASTER.Where(e => e.IS_DELETE != true).ToList();
            return Json(Client(), JsonRequestBehavior.AllowGet);
            // return View(tBL_REGISTRATION_MASTER);
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Create(TBL_REGISTRATION_MASTER tBL_REGISTRATION_MASTER)
        {
            if (ModelState.IsValid)
            {
                tBL_REGISTRATION_MASTER.CREATED_ON = DateTime.Now;
                tBL_REGISTRATION_MASTER.CREATED_BY = 1;
                tBL_REGISTRATION_MASTER.IS_DELETE = false;
                db.TBL_REGISTRATION_MASTER.Add(tBL_REGISTRATION_MASTER);
                db.SaveChanges();
                return Json("../Client/");
            }

            return View(tBL_REGISTRATION_MASTER);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_REGISTRATION_MASTER tBL_REGISTRATION_MASTER = db.TBL_REGISTRATION_MASTER.Find(id);
            if (tBL_REGISTRATION_MASTER == null)
            {
                return HttpNotFound();
            }
            return View(tBL_REGISTRATION_MASTER);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "REG_ID,F_NAME,M_NAME,L_NAME,DOB,COUNTRY_ID,STATE_ID,CITY_ID,ADDRESS_1,PHONE_1,GENDER,PHOTO,IS_ACTIVE,IS_DELETE,CREATED_ON,CREATED_BY,MODIFIED_ON,MODIFIED_BY")] TBL_REGISTRATION_MASTER tBL_REGISTRATION_MASTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_REGISTRATION_MASTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_REGISTRATION_MASTER);
        }


        // GET: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_REGISTRATION_MASTER tBL_REGISTRATION_MASTER = db.TBL_REGISTRATION_MASTER.Find(id);
            if (tBL_REGISTRATION_MASTER == null)
            {
                return HttpNotFound();
            }
            else
            {
                tBL_REGISTRATION_MASTER.IS_DELETE = true;
                db.Entry(tBL_REGISTRATION_MASTER).State = EntityState.Modified;
                db.SaveChanges();
              // return Json("Index");
            }
           // List<TBL_REGISTRATION_MASTER> um = db.TBL_REGISTRATION_MASTER.Where(e => e.IS_DELETE != true).ToList();
            return Json(Client(), JsonRequestBehavior.AllowGet);
            //return View(tBL_REGISTRATION_MASTER);
        }

       protected List<Registrationmaster> Client()
        {          
            List<TBL_REGISTRATION_MASTER> TRM = db.TBL_REGISTRATION_MASTER.Where(e => e.IS_DELETE == false).OrderBy(e => e.REG_ID).ToList();
            List<Registrationmaster> RM = new List<Registrationmaster>();
            foreach (var tms in TRM)
            {
                RM.Add(new Registrationmaster
                {
                    F_NAME = tms.F_NAME,
                    M_NAME = tms.M_NAME,
                    L_NAME = tms.L_NAME,
                    ADDRESS_1 = tms.ADDRESS_1,
                    DOB = Convert.ToString(tms.DOB),
                    GENDER = tms.GENDER,
                    CREATED_ON = Convert.ToString(tms.CREATED_ON),
                    IS_ACTIVE = tms.IS_ACTIVE == true ? "Active" : "InActive",
                    PHONE_1 = tms.PHONE_1,
                    PHOTO = tms.PHOTO,
                    REG_ID = tms.REG_ID,
                    geoLocation = db.TBL_CITY_MASTER.Where(e => e.CITY_ID == tms.CITY_ID && e.STATE_ID == tms.STATE_ID && e.ISACTIVE == true && e.ISDELETE == false).Select(e => e.CITY_NAME).SingleOrDefault().ToString() + "," + db.TBL_STATE_MASTER.Where(e => e.STATE_ID == tms.STATE_ID && e.COUNTRY_ID == tms.COUNTRY_ID && e.ISACTIVE == true && e.ISDELETE == false).Select(e => e.STATE_NAME).SingleOrDefault().ToString() + " ," + db.TBL_COUNTRY_MASTER.Where(e => e.COUNTRY_ID == tms.COUNTRY_ID && e.ISACTIVE == true && e.ISDELETE == false).Select(e => e.COUNTRY_NAME).SingleOrDefault().ToString(),

                });
            }
            return RM.ToList();
        }

        [HttpPost]
        public ContentResult Upload()
        {
            string path = Server.MapPath("~/Uploads/");
            string filename = "";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (string key in Request.Files)
            {
                HttpPostedFileBase postedFile = Request.Files[key];
                filename = postedFile.FileName;
                postedFile.SaveAs(path + postedFile.FileName);
            }

            return Content("/Uploads/"+ filename);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
