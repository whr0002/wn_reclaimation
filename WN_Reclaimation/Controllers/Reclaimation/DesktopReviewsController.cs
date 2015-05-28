using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using wn_web.Models;
using wn_web.Models.Reclaimation;

namespace wn_web.Controllers.Reclaimation
{
    public class DesktopReviewsController : Controller
    {
        private wn_webContext db = new wn_webContext();

        // GET: DesktopReviews
        public ActionResult Index()
        {
            var desktopReviews = db.DesktopReviews.Include(d => d.FacilityType).Include(d => d.Landscape).Include(d => d.LSDQuarter).Include(d => d.RelevantCriteria).Include(d => d.Soil).Include(d => d.Vegetation);
            return View(desktopReviews.ToList());
        }

        // GET: DesktopReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesktopReview desktopReview = db.DesktopReviews.Find(id);
            if (desktopReview == null)
            {
                return HttpNotFound();
            }
            return View(desktopReview);
        }

        // GET: DesktopReviews/Create
        public ActionResult Create()
        {
            ViewBag.FacilityTypeName = new SelectList(db.FacilityTypes, "FacilityTypeName", "FacilityTypeName");
            ViewBag.LandscapeName = new SelectList(db.Landscapes, "LandscapeName", "LandscapeName");
            ViewBag.AspectName = new SelectList(db.Aspects, "AspectName", "AspectName");
            ViewBag.RelevantCriteriaName = new SelectList(db.RelevantCriterias, "RelevantCriteriaName", "RelevantCriteriaName");
            ViewBag.SoilName = new SelectList(db.Soils, "SoilName", "SoilName");
            ViewBag.VegetationName = new SelectList(db.Vegetations, "VegetationName", "VegetationName");

            ViewBag.CountyName = new SelectList(db.Countys, "CountyName", "CountyName");
            ViewBag.FMAHolderName = new SelectList(db.FMAHolders, "FMAHolderName", "FMAHolderName");
            ViewBag.NaturalRegionName = new SelectList(db.NaturalRegions, "NaturalRegionName", "NaturalRegionName");
            ViewBag.NaturalSubRegionName = new SelectList(db.NaturalSubRegions, "NaturalSubRegionName", "NaturalSubRegionName");
            ViewBag.OperatingAreaName = new SelectList(db.OperatingAreas, "OperatingAreaName", "OperatingAreaName");
            ViewBag.ProvincialAreaName = new SelectList(db.ProvincialAreas, "ProvincialAreaName", "ProvincialAreaName");
            ViewBag.ProvincialAreaTypeName = new SelectList(db.ProvincialAreaTypes, "ProvincialAreaTypeName", "ProvincialAreaTypeName");
            return View();
        }

        // POST: DesktopReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DesktopReviewID,SiteID,FacilityTypeName,Notes,Client,ApprovalStatus,WorkPhase,Occupant,OccupantInfo,Disposition,SoilClass,SoilGroup,ERCBLic,Width,Length,AreaHA,AreaAC,Northing,Easting,Latitude,Longitude,Elevation,AspectName,LSD,SurveyDate,ConstructionDate,SpudDate,AbandonmentDate,ReclamationDate,RelevantCriteriaName,LandscapeName,SoilName,VegetationName,RCADate,RCNumber,DSAComments,Exemptions,AmendDate,AmendDetail,RevegDate,RevegDetail")] DesktopReview desktopReview,
            [Bind(Include = "AFE,ProvincialAreaName,ProvincialAreaTypeName,OperatingAreaName,CountyName,NaturalRegionName,NaturalSubRegionName,FMAHolderName,SeedZone,WellboreID,UWI,WellsiteName,UTMZone")] ReviewSite reviewSite)
        {
            if (desktopReview != null && desktopReview.SiteID != null && desktopReview.SiteID.Length > 0)
            {
                reviewSite.ReviewSiteID = desktopReview.SiteID;

                var b = db.ReviewSites.Find(reviewSite.ReviewSiteID);
                if (b == null)
                {
                    db.ReviewSites.Add(reviewSite);
                    db.SaveChanges();
                    db.DesktopReviews.Add(desktopReview);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error_Create", "Error");
                }

                
                
            }
            

            ViewBag.FacilityTypeName = new SelectList(db.FacilityTypes, "FacilityTypeName", "FacilityTypeName", desktopReview.FacilityTypeName);
            ViewBag.LandscapeName = new SelectList(db.Landscapes, "LandscapeName", "LandscapeName", desktopReview.LandscapeName);
            ViewBag.AspectName = new SelectList(db.Aspects, "AspectName", "AspectName", desktopReview.AspectName);
            ViewBag.RelevantCriteriaName = new SelectList(db.RelevantCriterias, "RelevantCriteriaName", "RelevantCriteriaName", desktopReview.RelevantCriteriaName);
            ViewBag.SoilName = new SelectList(db.Soils, "SoilName", "SoilName", desktopReview.SoilName);
            ViewBag.VegetationName = new SelectList(db.Vegetations, "VegetationName", "VegetationName", desktopReview.VegetationName);

            ViewBag.CountyName = new SelectList(db.Countys, "CountyName", "CountyName");
            ViewBag.FMAHolderName = new SelectList(db.FMAHolders, "FMAHolderName", "FMAHolderName");
            ViewBag.NaturalRegionName = new SelectList(db.NaturalRegions, "NaturalRegionName", "NaturalRegionName");
            ViewBag.NaturalSubRegionName = new SelectList(db.NaturalSubRegions, "NaturalSubRegionName", "NaturalSubRegionName");
            ViewBag.OperatingAreaName = new SelectList(db.OperatingAreas, "OperatingAreaName", "OperatingAreaName");
            ViewBag.ProvincialAreaName = new SelectList(db.ProvincialAreas, "ProvincialAreaName", "ProvincialAreaName");
            ViewBag.ProvincialAreaTypeName = new SelectList(db.ProvincialAreaTypes, "ProvincialAreaTypeName", "ProvincialAreaTypeName");
            return View(desktopReview);

        }

        // GET: DesktopReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesktopReview desktopReview = db.DesktopReviews.Find(id);
            if (desktopReview == null)
            {
                return HttpNotFound();
            }


            ReviewSite reviewSite = db.ReviewSites.Find(desktopReview.SiteID);

            if (reviewSite == null)
            {
                return HttpNotFound();
            }

            ViewBag.FacilityTypeName = new SelectList(db.FacilityTypes, "FacilityTypeName", "FacilityTypeName", desktopReview.FacilityTypeName);
            ViewBag.LandscapeName = new SelectList(db.Landscapes, "LandscapeName", "LandscapeName", desktopReview.LandscapeName);
            ViewBag.AspectName = new SelectList(db.Aspects, "AspectName", "AspectName", desktopReview.AspectName);
            ViewBag.RelevantCriteriaName = new SelectList(db.RelevantCriterias, "RelevantCriteriaName", "RelevantCriteriaName", desktopReview.RelevantCriteriaName);
            ViewBag.SoilName = new SelectList(db.Soils, "SoilName", "SoilName", desktopReview.SoilName);
            ViewBag.VegetationName = new SelectList(db.Vegetations, "VegetationName", "VegetationName", desktopReview.VegetationName);

            ViewBag.CountyName = new SelectList(db.Countys, "CountyName", "CountyName", reviewSite.CountyName);
            ViewBag.FMAHolderName = new SelectList(db.FMAHolders, "FMAHolderName", "FMAHolderName", reviewSite.FMAHolderName);
            ViewBag.NaturalRegionName = new SelectList(db.NaturalRegions, "NaturalRegionName", "NaturalRegionName", reviewSite.NaturalRegionName);
            ViewBag.NaturalSubRegionName = new SelectList(db.NaturalSubRegions, "NaturalSubRegionName", "NaturalSubRegionName", reviewSite.NaturalSubRegionName);
            ViewBag.OperatingAreaName = new SelectList(db.OperatingAreas, "OperatingAreaName", "OperatingAreaName", reviewSite.OperatingAreaName);
            ViewBag.ProvincialAreaName = new SelectList(db.ProvincialAreas, "ProvincialAreaName", "ProvincialAreaName", reviewSite.ProvincialAreaName);
            ViewBag.ProvincialAreaTypeName = new SelectList(db.ProvincialAreaTypes, "ProvincialAreaTypeName", "ProvincialAreaTypeName", reviewSite.ProvincialAreaTypeName);

            ViewBag.AFE = reviewSite.AFE;
            ViewBag.SeedZone = reviewSite.SeedZone;
            ViewBag.WellboreID = reviewSite.WellboreID;
            ViewBag.UWI = reviewSite.UWI;
            ViewBag.WellsiteName = reviewSite.WellsiteName;
            ViewBag.UTMZone = reviewSite.UTMZone;

            return View(desktopReview);
        }

        // POST: DesktopReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DesktopReviewID,SiteID,FacilityTypeName,Notes,Client,ApprovalStatus,WorkPhase,Occupant,OccupantInfo,Disposition,SoilClass,SoilGroup,ERCBLic,Width,Length,AreaHA,AreaAC,Northing,Easting,Latitude,Longitude,Elevation,AspectName,LSD,SurveyDate,ConstructionDate,SpudDate,AbandonmentDate,ReclamationDate,RelevantCriteriaName,LandscapeName,SoilName,VegetationName,RCADate,RCNumber,DSAComments,Exemptions,AmendDate,AmendDetail,RevegDate,RevegDetail")] DesktopReview desktopReview,
            [Bind(Include = "AFE,ProvincialAreaName,ProvincialAreaTypeName,OperatingAreaName,CountyName,NaturalRegionName,NaturalSubRegionName,FMAHolderName,SeedZone,WellboreID,UWI,WellsiteName,UTMZone")] ReviewSite reviewSite)
        {

            if (desktopReview != null && desktopReview.SiteID != null && desktopReview.SiteID.Length > 0)
            {
                reviewSite.ReviewSiteID = desktopReview.SiteID;


                db.Entry(reviewSite).State = EntityState.Modified;
                db.SaveChanges();
                db.Entry(desktopReview).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
                
            }

            
            ViewBag.FacilityTypeName = new SelectList(db.FacilityTypes, "FacilityTypeName", "FacilityTypeName", desktopReview.FacilityTypeName);
            ViewBag.LandscapeName = new SelectList(db.Landscapes, "LandscapeName", "LandscapeName", desktopReview.LandscapeName);
            ViewBag.AspectName = new SelectList(db.Aspects, "AspectName", "AspectName", desktopReview.AspectName);
            ViewBag.RelevantCriteriaName = new SelectList(db.RelevantCriterias, "RelevantCriteriaName", "RelevantCriteriaName", desktopReview.RelevantCriteriaName);
            ViewBag.SoilName = new SelectList(db.Soils, "SoilName", "SoilName", desktopReview.SoilName);
            ViewBag.VegetationName = new SelectList(db.Vegetations, "VegetationName", "VegetationName", desktopReview.VegetationName);

            ViewBag.CountyName = new SelectList(db.Countys, "CountyName", "CountyName", reviewSite.CountyName);
            ViewBag.FMAHolderName = new SelectList(db.FMAHolders, "FMAHolderName", "FMAHolderName", reviewSite.FMAHolderName);
            ViewBag.NaturalRegionName = new SelectList(db.NaturalRegions, "NaturalRegionName", "NaturalRegionName", reviewSite.NaturalRegionName);
            ViewBag.NaturalSubRegionName = new SelectList(db.NaturalSubRegions, "NaturalSubRegionName", "NaturalSubRegionName", reviewSite.NaturalSubRegionName);
            ViewBag.OperatingAreaName = new SelectList(db.OperatingAreas, "OperatingAreaName", "OperatingAreaName", reviewSite.OperatingAreaName);
            ViewBag.ProvincialAreaName = new SelectList(db.ProvincialAreas, "ProvincialAreaName", "ProvincialAreaName", reviewSite.ProvincialAreaName);
            ViewBag.ProvincialAreaTypeName = new SelectList(db.ProvincialAreaTypes, "ProvincialAreaTypeName", "ProvincialAreaTypeName", reviewSite.ProvincialAreaTypeName);

            ViewBag.AFE = reviewSite.AFE;
            ViewBag.SeedZone = reviewSite.SeedZone;
            ViewBag.WellboreID = reviewSite.WellboreID;
            ViewBag.UWI = reviewSite.UWI;
            ViewBag.WellsiteName = reviewSite.WellsiteName;
            ViewBag.UTMZone = reviewSite.UTMZone;

            return View(desktopReview);
        }

        // GET: DesktopReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesktopReview desktopReview = db.DesktopReviews.Find(id);
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
            DesktopReview desktopReview = db.DesktopReviews.Find(id);
            db.DesktopReviews.Remove(desktopReview);
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
