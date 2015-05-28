using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wn_web.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using wn_web.Models.Reclaimation;
using WN_Reclaimation;
using wn_web.Models.Reclaimation.Report;
using System.Data.Entity;



namespace wn_web.Controllers.Reclaimation
{
    public class RDataController : Controller
    {
        private wn_webContext db = new wn_webContext();

        private string getRole(string email)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            ApplicationUser user = db.Users.Where(w => w.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            List<string> roles = new List<string>();
            roles = userManager.GetRoles(user.Id) as List<string>;

            if (roles != null && roles.Count() > 0)
            {
                return roles[0];
            }


            return null;
        }

        public async Task All(string email, string password)
        {
            //string email = e;
            //string password = p;
            ApplicationSignInManager manager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            if (email != null && password != null) { 
                var result = await manager.PasswordSignInAsync(email, password, false, false);
                string role = getRole(email);
            
                switch (result)
                {
                    case SignInStatus.Success:
                        List<ReviewSite> reviewSites = new List<ReviewSite>();
                        List<DesktopReview> list = new List<DesktopReview>();

                        if (role != null)
                        {
                            if (role.Equals("super admin")) {

                                //var drs = data.DesktopReviews.ToList();
                                var rss = db.ReviewSites.ToList();
                                var fts = db.FacilityTypes.ToList();

                                var o = new { RS = rss, FT = fts };


                                string json = new JavaScriptSerializer().Serialize(Json(o, JsonRequestBehavior.AllowGet).Data);
                                Response.Write(json);
                            }
                            else
                            {

                                var drs = (from a in db.ReviewSites
                                                 join b in db.DesktopReviews
                                                 on a.ReviewSiteID equals b.SiteID
                                                 where a.DataOwner.Equals(role, StringComparison.CurrentCultureIgnoreCase)
                                                 select b).ToList();

                                var rss = db.ReviewSites
                                    .Where(w => w.DataOwner.Equals(role, StringComparison.CurrentCultureIgnoreCase))
                                    .ToList();

                                var fts = db.FacilityTypes.ToList();

                                var o = new { DR = drs, RS = rss, FT = fts };

                                string json = new JavaScriptSerializer().Serialize(Json(o, JsonRequestBehavior.AllowGet).Data);
                                Response.Write(json);
                            }

                        }

                        break;
                }

            }
 
        }

        public async Task ReviewSites(string email, string password)
        {
            //string email = e;
            //string password = p;
            ApplicationSignInManager manager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            if (email != null && password != null)
            {
                var result = await manager.PasswordSignInAsync(email, password, false, false);
                string role = getRole(email);

                switch (result)
                {
                    case SignInStatus.Success:
                        List<ReviewSite> list = new List<ReviewSite>();
                        if (role != null)
                        {
                            if (role.Equals("super admin"))
                            {
                                list = db.ReviewSites.ToList();
                            }
                            else
                            {
                                //list = data.ReviewSites.Where(w => w.Client.Equals(role, StringComparison.CurrentCultureIgnoreCase)).ToList();
                                list = db.ReviewSites.Where(w => w.DataOwner.Equals(role)).ToList();
                            }
                            string json = new JavaScriptSerializer().Serialize(Json(list, JsonRequestBehavior.AllowGet).Data);
                            Response.Write(json);
                        }

                        break;
                }

            }

        }

        public async Task FacilityTypes(string email, string password)
        {
            //string email = e;
            //string password = p;
            ApplicationSignInManager manager = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            if (email != null && password != null)
            {
                var result = await manager.PasswordSignInAsync(email, password, false, false);

                switch (result)
                {
                    case SignInStatus.Success:
                        List<FacilityType> list = new List<FacilityType>();
                        
                        list = db.FacilityTypes.ToList();
                        string json = new JavaScriptSerializer().Serialize(Json(list, JsonRequestBehavior.AllowGet).Data);
                        Response.Write(json);
                        
                        break;
                }

            }

        }

        [HttpPost]
        public async Task SiteVisitSubmit(FormCollection fc, [Bind(Include="NumberOfImages")]int NumberOfImages,[Bind(Include="SiteVisitReportID,ReviewSiteID,FacilityTypeName,Date,Username,Group,Client,RefusePF,RefuseComment,DrainagePF,DrainageComment,RockGravelPF,RockGravelComment,BareGroundPF,BareGroundComment,SoilStabilityPF,SoilStabilityComment,ContoursPF,ContoursComment,CWDPF,CWDComment,ErosionPF,ErosionComment,SoilCharPF,SoilCharComment,TopsoilDepthPF,TopsoilDepthComment,RootingPF,RootingComment,WSDPF,WSDComment,TreeHealthPF,TreeHealthComment,WeedsInvasivesPF,WeedsInvasivesComment,NSCPF,NSCComment,LitterPF,LitterComment,Recommendation,ReviewSite,FacilityType")]SiteVisitReport svr)
        {
            if (Request != null)
            {

                var username = fc["Username"];
                var password = fc["Password"];

                ApplicationSignInManager sm = HttpContext.GetOwinContext().Get<ApplicationSignInManager>();

                var result = await sm.PasswordSignInAsync(username, password, false, false);

                if (result == SignInStatus.Success)
                {

                    SiteVisitReport siteVisitReport = db.SiteVisitReports
                        .Where(w => w.ReviewSiteID.Equals(svr.ReviewSiteID) 
                            && w.FacilityTypeName.Equals(svr.FacilityTypeName)
                            && w.Date.Equals(svr.Date)).FirstOrDefault();
                    int formID;
                    if (siteVisitReport == null)
                    {

                        db.SiteVisitReports.Add(svr);
                        db.SaveChanges();

                        formID = svr.SiteVisitReportID;

                    }
                    else
                    {
                        formID = siteVisitReport.SiteVisitReportID;
                    }

                    for (int i = 0; i < NumberOfImages; i++)
                    {
                        Photo p = new Photo();
                        p.PhotoID = 0;
                        p.Path = fc["Path" + i];
                        p.FormTypeName = fc["FormType" + i];
                        p.FormID = formID;
                        p.Description = fc["Desc" + i];
                        p.Classification = fc["Classification" + i];


                        Photo tempPhoto = db.Photos.Where(w => w.Path.Equals(p.Path)).FirstOrDefault();
                        if (tempPhoto == null)
                        {
                            db.Photos.Add(p);
                        }

                    }

                    db.SaveChanges();


                    Response.Write("Form Submitted");
                }

            }
        }

    }
}