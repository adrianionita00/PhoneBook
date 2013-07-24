using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StefaniniPhoneBook.Models;

namespace StefaniniPhoneBook.Controllers
{ 
    public class DetailController : Controller
    {
        private PhoneBookContext db = new PhoneBookContext();

        //
        // GET: /Detail/

        public ViewResult Index()
        {
            var details = db.Details.Include(d => d.DetailType).Include(d => d.Contact);
            return View(details.ToList());
        }

        //
        // GET: /Detail/Details/5

        public ViewResult Details(int id)
        {
            Detail detail = db.Details.Find(id);
            return View(detail);
        }

        //
        // GET: /Detail/Create

        public ActionResult Create(int id)
        {
            ViewBag.DetailTypeID = new SelectList(db.DetailsTypes, "DetailTypeID", "DetailTypeData");
            ViewBag.ContactID = new SelectList(db.Contacts, "ContactID", "LastName");
            return View();
        } 

        //
        // POST: /Detail/Create

        [HttpPost]
        public ActionResult Create(Detail detail)
        {
            if (ModelState.IsValid)
            {
                detail.ContactID = int.Parse(RouteData.Values["id"].ToString());
                db.Details.Add(detail);
                db.SaveChanges();
                return RedirectToAction("Details", "Contact", new { id = detail.ContactID });
            }

            ViewBag.DetailTypeID = new SelectList(db.DetailsTypes, "DetailTypeID", "DetailTypeData", detail.DetailTypeID);
            ViewBag.ContactID = new SelectList(db.Contacts, "ContactID", "LastName", detail.ContactID);
            return View(detail);
            //return RedirectToAction("Details", "Contact", new { id=detail.ContactID});
        }
        
        //
        // GET: /Detail/Edit/5
 
        public ActionResult Edit(int id)
        {
            Detail detail = db.Details.Find(id);
            ViewBag.DetailTypeID = new SelectList(db.DetailsTypes, "DetailTypeID", "DetailTypeData", detail.DetailTypeID);
            ViewBag.ContactID = new SelectList(db.Contacts, "ContactID", "LastName", detail.ContactID);
            
            return View(detail);
        }

        //
        // POST: /Detail/Edit/5

        [HttpPost]
        public ActionResult Edit(Detail detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DetailTypeID = new SelectList(db.DetailsTypes, "DetailTypeID", "DetailTypeData", detail.DetailTypeID);
            ViewBag.ContactID = new SelectList(db.Contacts, "ContactID", "LastName", detail.ContactID);
            return View(detail);
        }

        //
        // GET: /Detail/Delete/5
 
        public ActionResult Delete(int id)
        {
            Detail detail = db.Details.Find(id);
            return View(detail);
        }

        //
        // POST: /Detail/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Detail detail = db.Details.Find(id);
            db.Details.Remove(detail);
            db.SaveChanges();
            return RedirectToAction("Details", "Contact", new { id = detail.ContactID });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}