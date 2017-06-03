using HRSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Services.Interfaces
{
    public interface IMenu
    {
        void addMenu(string menuName, string URL, string owner, string cssClass, string connectionString);
        List<NavigationMenuItems> getMenuItems(string connectionString);
        List<NavigationMenuItems> getMenuItemByName(string Name, string connectionString);
        void updateMenuItemById(int? Id,string Name,string Url,string owner,string cssclass, string connectionString);
        void DeleteMenuItem(int Id,string connectionString);
        void AddWidget(string zone, string title, string position, string Name, bool renderTitle, int layerId, string cssClass,string owner, string connectionString);
        List<WidgetLayerViewModel> getWidgetList(string connectionString);
        List<WidgetLayerViewModel> getWidgetItemById(int Id, string connectionString);
        void updateWidgetById(int? Id, string title, string zone, bool renderTitle, string position, string name, int layerId, string cssClass,string owner, string connectionString);
        void DeleteWidgetById(int Id, string connectionString);
        List<BlogModelView> getBlogList(string connectionString);
        void createBlog(string title, string permalink, bool setashomepage, string desc, string body, string feedproxyurl, int postsperpage, string post, string owner, string connectionString);
        void updateBlogById(int? Id,string title, string permalink, bool setashomepage, string desc, string body, string feedproxyurl, int postsperpage, string post, string owner, string connectionString);
        BlogModelView getBlogById(int Id, string connectionString);
        void DeleteBlogById(int Id, string connectionString);
    }
}
