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



namespace wn_web.Controllers.Reclaimation
{
    public class RDataController : Controller
    {
        private wn_webContext data = new wn_webContext();

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
                                var rss = data.ReviewSites.ToList();
                                var fts = data.FacilityTypes.ToList();

                                var o = new { RS = rss, FT = fts };


                                string json = new JavaScriptSerializer().Serialize(Json(o, JsonRequestBehavior.AllowGet).Data);
                                Response.Write(json);
                            }
                            else
                            {

                                var drs = (from a in data.ReviewSites
                                                 join b in data.DesktopReviews
                                                 on a.ReviewSiteID equals b.SiteID
                                                 where a.DataOwner.Equals(role, StringComparison.CurrentCultureIgnoreCase)
                                                 select b).ToList();

                                var rss = data.ReviewSites
                                    .Where(w => w.DataOwner.Equals(role, StringComparison.CurrentCultureIgnoreCase))
                                    .ToList();

                                var fts = data.FacilityTypes.ToList();

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
                                list = data.ReviewSites.ToList();
                            }
                            else
                            {
                                //list = data.ReviewSites.Where(w => w.Client.Equals(role, StringComparison.CurrentCultureIgnoreCase)).ToList();
                                list = data.ReviewSites.Where(w => w.DataOwner.Equals(role)).ToList();
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
                        
                        list = data.FacilityTypes.ToList();
                        string json = new JavaScriptSerializer().Serialize(Json(list, JsonRequestBehavior.AllowGet).Data);
                        Response.Write(json);
                        
                        break;
                }

            }

        }

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
    }
}