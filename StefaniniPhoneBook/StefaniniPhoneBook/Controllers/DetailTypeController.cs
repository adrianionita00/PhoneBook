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
    public class DetailTypeController : Controller
    {
        private PhoneBookContext db = new PhoneBookContext();

        //
        // GET: /DetailTypes/

        public ViewResult Index()
        {
            return View(db.DetailsTypes.ToList());
        }

        //
        // GET: /DetailTypes/Details/5

        public ViewResult Details(int id)
        {
            DetailType detailtype = db.DetailsTypes.Find(id);
            return View(detailtype);
        }

        //
        // GET: /DetailTypes/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /DetailTypes/Create

        [HttpPost]
        public ActionResult Create(DetailType detailtype)
        {
            if (ModelState.IsValid)
            {
                db.DetailsTypes.Add(detailtype);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(detailtype);
        }
        
        //
        // GET: /DetailTypes/Edit/5
 
        public ActionResult Edit(int id)
        {
            DetailType detailtype = db.DetailsTypes.Find(id);
            return View(detailtype);
        }

        //
        // POST: /DetailTypes/Edit/5

        [HttpPost]
        public ActionResult Edit(DetailType detailtype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detailtype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(detailtype);
        }

        //
        // GET: /DetailTypes/Delete/5
 
        public ActionResult Delete(int id)
        {
            DetailType detailtype = db.DetailsTypes.Find(id);
            return View(detailtype);
        }

        //
        // POST: /DetailTypes/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            DetailType detailtype = db.DetailsTypes.Find(id);
            db.DetailsTypes.Remove(detailtype);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}