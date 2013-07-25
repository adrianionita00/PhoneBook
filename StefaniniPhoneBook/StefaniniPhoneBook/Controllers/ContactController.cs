using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StefaniniPhoneBook.Models;
using PagedList;

namespace StefaniniPhoneBook.Controllers
{
    /// <summary>
    ///  This class performs display of data to the Page.
    /// </summary>
    public class ContactController : Controller
    {
        private PhoneBookContext db = new PhoneBookContext();

        //
        // GET: /Contact/

        //public ViewResult Index()
        //{
        //    return View(db.Contacts.ToList());
        //}

        public ViewResult Index(string sortOrder, string searchString)
        {
            ViewBag.FirstNameSortParm = String.IsNullOrEmpty(sortOrder) ? "FirstName desc" : "";
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "LastName desc" : "";

            var contacts = from c in db.Contacts
                           select c;

            if (!String.IsNullOrEmpty(searchString))
            {
                contacts = contacts.Where(s => s.LastName.ToUpper().Contains(searchString.ToUpper())
                                       || s.FirstName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "FirstName desc":
                    contacts = contacts.OrderByDescending(c => c.FirstName);
                    break;
                case "LastName desc":
                    contacts = contacts.OrderByDescending(c => c.LastName);
                    break;
                default:
                    contacts = contacts.OrderBy(s => s.LastName);
                    break;
            }
            return View(contacts.ToList());
        }

        //
        // GET: /Contact/Details/5

        public ViewResult Details(int id)
        {
            Contact contact = db.Contacts.Find(id);
            return View(contact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Contact/Create

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(
                    "","Unable to save..."
                    );
            }
            return View(contact);
        }
        
        //
        // GET: /Contact/Edit/5
 
        public ActionResult Edit(int id)
        {
            Contact contact = db.Contacts.Find(id);
            return View(contact);
        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(contact).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(
                    "","Unable to save..."
                    );
            }
            return View(contact);
        }

        //
        // GET: /Contact/Delete/5
 
        //public ActionResult Delete(int id)
        //{
        //    Contact contact = db.Contacts.Find(id);
        //    return View(contact);
        //}

        public ActionResult Delete(int id, bool? saveChangesError)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Unable to save...";
            }
            return View(db.Contacts.Find(id));
        }

        //
        // POST: /Contact/Delete/5

        //[HttpPost, ActionName("Delete")]
        //public ActionResult DeleteConfirmed(int id)
        //{            
        //    Contact contact = db.Contacts.Find(id);
        //    db.Contacts.Remove(contact);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Contact contact = db.Contacts.Find(id);
                db.Contacts.Remove(contact);
                db.SaveChanges();
            }
            catch (DataException)
            {
                return RedirectToAction(
                    "Delete",
                    new System.Web.Routing.RouteValueDictionary { 
                        {"id",id},
                        {"saveChangesError",true}
                    }
                    );
            }
            return RedirectToAction("Index");

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}