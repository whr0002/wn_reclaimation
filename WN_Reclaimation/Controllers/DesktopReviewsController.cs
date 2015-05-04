using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WN_Reclaimation.Models;

namespace WN_Reclaimation.Controllers
{
    public class DesktopReviewsController : Controller
    {
        private Reclaimation_Context db = new Reclaimation_Context();

        // GET: DesktopReviews
        public ActionResult Index()
        {
            var destopReviews = db.DestopReviews.Include(d => d.Client).Include(d => d.FacilityType);
            return View(destopReviews.ToList());
        }

        // GET: DesktopReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesktopReview desktopReview = db.DestopReviews.Find(id);
            if (desktopReview == null)
            {
                return HttpNotFound();
            }
            return View(desktopReview);
        }

        // GET: DesktopReviews/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName");
            ViewBag.FacilityTypeID = new SelectList(db.FacilityTypes, "FacilityTypeID", "FacilityTypeName");
            return View();
        }

        // POST: DesktopReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DesktopReviewID,FacilityTypeID,Site,ClientID")] DesktopReview desktopReview)
        {
            if (ModelState.IsValid)
            {
                db.DestopReviews.Add(desktopReview);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", desktopReview.ClientID);
            ViewBag.FacilityTypeID = new SelectList(db.FacilityTypes, "FacilityTypeID", "FacilityTypeName", desktopReview.FacilityTypeID);
            return View(desktopReview);
        }

        // GET: DesktopReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesktopReview desktopReview = db.DestopReviews.Find(id);
            if (desktopReview == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", desktopReview.ClientID);
            ViewBag.FacilityTypeID = new SelectList(db.FacilityTypes, "FacilityTypeID", "FacilityTypeName", desktopReview.FacilityTypeID);
            return View(desktopReview);
        }

        // POST: DesktopReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DesktopReviewID,FacilityTypeID,Site,ClientID")] DesktopReview desktopReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desktopReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", desktopReview.ClientID);
            ViewBag.FacilityTypeID = new SelectList(db.FacilityTypes, "FacilityTypeID", "FacilityTypeName", desktopReview.FacilityTypeID);
            return View(desktopReview);
        }

        // GET: DesktopReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesktopReview desktopReview = db.DestopReviews.Find(id);
            if (desktopReview == null)
            {
                return HttpNotFound();
            }
            return View(desktopReview);
        }

        // POST: DesktopReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DesktopReview desktopReview = db.DestopReviews.Find(id);
            db.DestopReviews.Remove(desktopReview);
            db.SaveChanges();
            return RedirectToAction("Index");
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
