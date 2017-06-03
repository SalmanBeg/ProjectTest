using HRSystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HRSystem.Services.Interfaces;
using HRSystem.Web.Common;
using HRSystem.Services.Models;
using HRSystem.Services.Repositories;


namespace HRSystem.Web.Controllers
{
    [OutputCache(Duration = 15, VaryByParam = "None")]
    public class EmployeePortalViewController : Controller
    {
        private readonly IMenu _menu;

        public EmployeePortalViewController() : this(new MenuRepository()) { }

        public EmployeePortalViewController(IMenu menu)
        {
            _menu = menu;
        }
        // GET: EmployeePortalView
        public ActionResult Index()
        {
            MenuItemViewModels obj = new MenuItemViewModels();
            string owner = Globals.gUserName;
            Session["ownerName"] = owner;
            obj.Owner = owner;
            var objMenuitems = new List<NavigationMenuItems>();
            objMenuitems = _menu.getMenuItems(Globals.connectionString);
            ViewBag.menuList = objMenuitems;
            return View();
        }
        [HttpPost]
        public ActionResult Index(int? Id, string Name, string Url, string owner, string cssclass)
        {
            owner = Globals.gUserName;
            if (Id == 0 || Id == null)
            {
                List<NavigationMenuItems> objmenulist = new List<NavigationMenuItems>();
                objmenulist = _menu.getMenuItemByName(Name.Trim(), Globals.connectionString);
                if (objmenulist == null || objmenulist.Count == 0)
                {
                    _menu.addMenu(Name, Url, owner, cssclass, Globals.connectionString);
                }
                else
                {
                    ViewBag.Error = "The menu name already exists!";
                }
            }
            else
            {
                _menu.updateMenuItemById(Id, Name.Trim(), Url.Trim(), owner.Trim(), cssclass.Trim(), Globals.connectionString);
            }
            var objMenuitems = new List<NavigationMenuItems>();
            objMenuitems = _menu.getMenuItems(Globals.connectionString);
            ViewBag.menuList = objMenuitems;
            return View();
        }
        [HttpPost]
        public JsonResult DeleteMenu(int Id)
        {
            List<NavigationMenuItems> objMenu = new List<NavigationMenuItems>();
            _menu.DeleteMenuItem(Id, Globals.connectionString);
            objMenu = _menu.getMenuItems(Globals.connectionString);
            ViewBag.menuList = objMenu;
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Widgets()
        {
            var objWidgetitems = new List<WidgetLayerViewModel>();
            objWidgetitems = _menu.getWidgetList(Globals.connectionString);
            ViewBag.widgetList = objWidgetitems;
            return View();
        }
        public ActionResult AddWidget()
        {
            string owner = Globals.gUserName;
            Session["ownerName"] = owner;
            return View();
        }
        [HttpPost]
        public ActionResult AddWidget(int? Id, string zone, string title, string position, string Name, string cssClass, string Owner, IEnumerable<bool> renderTitle, int layerId = 1)
        {
            bool RenderTitle;
            if (renderTitle != null && renderTitle.Count() == 2)
            {
                RenderTitle = true;
            }
            else
            {
                RenderTitle = false;
            }
            if (Id == null)
            {
                zone = Request.Form[2].ToString();
                layerId = Convert.ToInt32(Request.Form[3].ToString());
                position = Request.Form[4].ToString();
                title = Request.Form[5].ToString();
                Name = Request.Form[7].ToString();
                cssClass = Request.Form[8].ToString();
                Owner = Request.Form[9].ToString();
            }
            if (Id == null || Id == 0)
            {
                _menu.AddWidget(zone.Trim(), title.Trim(), position.Trim(), Name.Trim(), RenderTitle, layerId, cssClass, Owner, Globals.connectionString);
            }
            else
            {
                _menu.updateWidgetById(Id, title.Trim(), zone.Trim(), RenderTitle, position.Trim(), Name.Trim(), layerId, cssClass.Trim(), Owner.Trim(), Globals.connectionString);
            }
            ViewBag.Id = Id;
            var objWidgetitems = new List<WidgetLayerViewModel>();
            objWidgetitems = _menu.getWidgetList(Globals.connectionString);
            ViewBag.widgetList = objWidgetitems;
            return RedirectToAction("Widgets");
        }
        public ActionResult EditWidget(int Id)
        {
            List<WidgetLayerViewModel> objwidgetlist = new List<WidgetLayerViewModel>();
            objwidgetlist = _menu.getWidgetItemById(Id, Globals.connectionString);
            WidgetLayerViewModel objwidgetitem = new WidgetLayerViewModel();
            foreach (var item in objwidgetlist)
            {
                objwidgetitem.Id = item.Id;
                objwidgetitem.Zone = item.Zone;
                objwidgetitem.LayerId = item.LayerId;
                objwidgetitem.Position = item.Position;
                objwidgetitem.RenderTitle = item.RenderTitle;
                objwidgetitem.Title = item.Title;
                objwidgetitem.Name = item.Name;
                objwidgetitem.CssClasses = item.CssClasses;
                objwidgetitem.Owner = item.Owner;
            }
            objwidgetlist.Add(objwidgetitem);
            ViewData["Id"] = objwidgetitem.Id;
            ViewData["widgetzone"] = objwidgetitem.Zone;
            ViewData["layer"] = objwidgetitem.LayerId;
            ViewData["position"] = objwidgetitem.Position;
            ViewData["RenderTitle"] = objwidgetitem.RenderTitle;
            ViewData["Title"] = objwidgetitem.Title;
            ViewData["Name"] = objwidgetitem.Name;
            ViewData["CssClass"] = objwidgetitem.CssClasses;
            ViewData["Owner"] = objwidgetitem.Owner;
            ViewBag.Id = Id;
            ViewBag.widgetList = objwidgetlist;
            return PartialView("EditWidgets");
        }
        [HttpPost]
        public JsonResult DeleteWidget(int Id)
        {
            List<WidgetLayerViewModel> objwidget = new List<WidgetLayerViewModel>();
            _menu.DeleteWidgetById(Id, Globals.connectionString);
            objwidget = _menu.getWidgetList(Globals.connectionString);
            ViewBag.widgetList = objwidget;
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Dashboard()
        {
            var objWidgetitems = new List<WidgetLayerViewModel>();
            objWidgetitems = _menu.getWidgetList(Globals.connectionString);
            ViewBag.widgetList = objWidgetitems;
            var objMenuitems = new List<NavigationMenuItems>();
            objMenuitems = _menu.getMenuItems(Globals.connectionString);
            ViewBag.menuList = objMenuitems;
            var objBlogitems = new List<BlogModelView>();
            objBlogitems = _menu.getBlogList(Globals.connectionString);
            Session["BlogList"] = objBlogitems;
            return View();
        }
        public ActionResult Blogs()
        {
            string owner = Globals.gUserName;
            Session["ownerName"] = owner;
            var objBlogitems = new List<BlogModelView>();
            objBlogitems = _menu.getBlogList(Globals.connectionString);
            ViewBag.blogList = objBlogitems;
            return View();
        }
        [ValidateInput(false)]
        public ActionResult CreateBlog()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateBlog(int? Id, string title, string permalink, IEnumerable<bool> setashomepage, string description, string body, string feedproxyurl, int postsperpage, string post, string owner)
        {
            bool Setashomepage;
            if (setashomepage != null && setashomepage.Count() == 2)
            {
                Setashomepage = true;
            }
            else
            {
                Setashomepage = false;
            }
            if (Id == null)
            {
                title = Request.Form[1].ToString();
                permalink = Request.Form[2].ToString();
                description = Request.Form[4].ToString();
                feedproxyurl = Request.Form[7].ToString();
                postsperpage = Convert.ToInt32(Request.Form[8].ToString());
                post = Request.Form[9].ToString();
                owner = Request.Form[10].ToString();
            }
            if (Id == null || Id == 0)
            {
                _menu.createBlog(title.Trim(), permalink.Trim(), Setashomepage, description.Trim(), body, feedproxyurl.Trim(), postsperpage, post.Trim(), owner.Trim(), Globals.connectionString);
            }
            else
            {
                _menu.updateBlogById(Id, title.Trim(), permalink.Trim(), Setashomepage, description.Trim(), body, feedproxyurl.Trim(), postsperpage, post.Trim(), owner.Trim(), Globals.connectionString);
            }
            ViewBag.Id = Id;
            var objblogitems = new List<BlogModelView>();
            objblogitems = _menu.getBlogList(Globals.connectionString);
            ViewBag.blogList = objblogitems;
            return RedirectToAction("Blogs");
        }
        public ActionResult EditBlog(int Id)
        {
            BlogModelView objblogs = new BlogModelView();
            objblogs = _menu.getBlogById(Id, Globals.connectionString);
            TempData["BlogList"] = objblogs;
            ViewBag.Id = Id;
            TempData.Keep("BlogList");
            ViewData["Id"] = objblogs.Id;
            ViewData["Title"] = objblogs.Title;
            ViewData["Permalink"] = objblogs.permalink;
            ViewData["SetAsHomepage"] = objblogs.SetAsHomepage;
            ViewData["Description"] = objblogs.Description;
            ViewData["Body"] = objblogs.Body;
            ViewData["FeedProxyUrl"] = objblogs.FeedProxyUrl;
            ViewData["PostsPerPage"] = objblogs.postsperPage;
            ViewData["Post"] = objblogs.Post;
            ViewData["Owner"] = objblogs.Owner;
            return PartialView("EditBlog");
        }
        [HttpPost]
        public JsonResult DeleteBlog(int Id)
        {
            List<BlogModelView> objblogs = new List<BlogModelView>();
            _menu.DeleteBlogById(Id, Globals.connectionString);
            objblogs = _menu.getBlogList(Globals.connectionString);
            ViewBag.blogList = objblogs;
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}