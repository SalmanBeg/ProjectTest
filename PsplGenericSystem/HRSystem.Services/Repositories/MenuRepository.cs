using HRSystem.Services.Interfaces;
using HRSystem.Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HRSystem.Services.Repositories
{
    public class MenuRepository : IMenu
    {
        public void addMenu(string menuName, string URL, string owner, string cssClass, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("AddMenuItems", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@menuName", menuName);
            cmd.Parameters.AddWithValue("@url", URL);
            cmd.Parameters.AddWithValue("@ownerName", owner);
            cmd.Parameters.AddWithValue("@cssClass", cssClass);
            cmd.Connection = con;
            int result = cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<NavigationMenuItems> getMenuItems(string connectionString)
        {
            List<NavigationMenuItems> objMenuItems = new List<NavigationMenuItems>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandText = "GetMenuItems";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                NavigationMenuItems MenuItems = new NavigationMenuItems();
                MenuItems.Id = Convert.ToInt32(row.ItemArray[0]);
                MenuItems.Name = Convert.ToString(row.ItemArray[1]);
                MenuItems.URL = Convert.ToString(row.ItemArray[2]);
                MenuItems.Owner = Convert.ToString(row.ItemArray[3]);
                MenuItems.CssClass = Convert.ToString(row.ItemArray[4]);
                objMenuItems.Add(MenuItems);
            }
            return objMenuItems;
        }
        public List<NavigationMenuItems> getMenuItemByName(string Name, string connectionString)
        {
            List<NavigationMenuItems> objMenuItems = new List<NavigationMenuItems>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandText = "GetMenuItemByName";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@menuName", Name.Trim());
            cmd.Connection = con;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                NavigationMenuItems MenuItems = new NavigationMenuItems();
                MenuItems.Id = Convert.ToInt32(row.ItemArray[0]);
                MenuItems.Name = Convert.ToString(row.ItemArray[1]);
                MenuItems.URL = Convert.ToString(row.ItemArray[2]);
                MenuItems.Owner = Convert.ToString(row.ItemArray[3]);
                MenuItems.CssClass = Convert.ToString(row.ItemArray[4]);
                objMenuItems.Add(MenuItems);
            }
            return objMenuItems;
        }
        public void updateMenuItemById(int? Id, string Name, string Url, string Owner, string CssClass, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateMenuItem", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@menuName", Name.Trim());
            cmd.Parameters.AddWithValue("@url", Url.Trim());
            cmd.Parameters.AddWithValue("@Owner", Owner.Trim());
            cmd.Parameters.AddWithValue("@cssClass", CssClass.Trim());
            cmd.Connection = con;
            int result = cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteMenuItem(int Id, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteMenuItem", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            int result = cmd.ExecuteNonQuery();
            con.Close();
        }
        public void AddWidget(string zone, string title, string position, string Name, bool renderTitle, int layerId, string cssClass, string owner, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("AddWidgetItem", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@zone", zone.Trim());
            cmd.Parameters.AddWithValue("@title", title.Trim());
            cmd.Parameters.AddWithValue("@position", position.Trim());
            cmd.Parameters.AddWithValue("@name", Name.Trim());
            cmd.Parameters.AddWithValue("@rendertitle", renderTitle);
            cmd.Parameters.AddWithValue("@layerid", layerId);
            cmd.Parameters.AddWithValue("@cssClass", cssClass.Trim());
            cmd.Parameters.AddWithValue("@owner", owner.Trim());
            cmd.Connection = con;
            int result = cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<WidgetLayerViewModel> getWidgetList(string connectionString)
        {
            List<WidgetLayerViewModel> objWidgetItems = new List<WidgetLayerViewModel>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandText = "GetWidgetLayerItems";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                WidgetLayerViewModel WidgetItems = new WidgetLayerViewModel();
                WidgetItems.Id = Convert.ToInt32(row.ItemArray[0]);
                WidgetItems.Title = Convert.ToString(row.ItemArray[1]);
                WidgetItems.Zone = Convert.ToString(row.ItemArray[2]);
                WidgetItems.RenderTitle = Convert.ToBoolean(row.ItemArray[3]);
                WidgetItems.Position = Convert.ToString(row.ItemArray[4]);
                WidgetItems.Name = Convert.ToString(row.ItemArray[5]);
                WidgetItems.LayerId = Convert.ToInt32(row.ItemArray[6]);
                WidgetItems.CssClasses = Convert.ToString(row.ItemArray[7]);
                WidgetItems.Owner = Convert.ToString(row.ItemArray[8]);
                objWidgetItems.Add(WidgetItems);
            }
            return objWidgetItems;
        }
        public List<WidgetLayerViewModel> getWidgetItemById(int Id, string connectionString)
        {
            List<WidgetLayerViewModel> objWidgetItems = new List<WidgetLayerViewModel>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandText = "GetWidgetLayerItemById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                WidgetLayerViewModel WidgetItems = new WidgetLayerViewModel();
                WidgetItems.Id = Convert.ToInt32(row.ItemArray[0]);
                WidgetItems.Title = Convert.ToString(row.ItemArray[1]);
                WidgetItems.Zone = Convert.ToString(row.ItemArray[2]);
                WidgetItems.RenderTitle = Convert.ToBoolean(row.ItemArray[3]);
                WidgetItems.Position = Convert.ToString(row.ItemArray[4]);
                WidgetItems.Name = Convert.ToString(row.ItemArray[5]);
                WidgetItems.LayerId = Convert.ToInt32(row.ItemArray[6]);
                WidgetItems.CssClasses = Convert.ToString(row.ItemArray[7]);
                WidgetItems.Owner = Convert.ToString(row.ItemArray[8]);
                objWidgetItems.Add(WidgetItems);
            }
            return objWidgetItems;
        }
        public void updateWidgetById(int? Id, string title, string zone, bool renderTitle, string position, string Name, int layerId, string cssClass, string owner, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateWidgetLayerItem", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@title", title.Trim());
            cmd.Parameters.AddWithValue("@zone", zone.Trim());
            cmd.Parameters.AddWithValue("@rendertitle", renderTitle);
            cmd.Parameters.AddWithValue("@position", position.Trim());
            cmd.Parameters.AddWithValue("@name", Name.Trim());
            cmd.Parameters.AddWithValue("@layerid", layerId);
            cmd.Parameters.AddWithValue("@cssClass", cssClass.Trim());
            cmd.Parameters.AddWithValue("@owner", owner.Trim());
            cmd.Connection = con;
            int result = cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DeleteWidgetById(int Id, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteWidgetById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            int result = cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<BlogModelView> getBlogList(string connectionString)
        {
            List<BlogModelView> objblogList = new List<BlogModelView>();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandText = "getBlogListDetails";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                BlogModelView blogItems = new BlogModelView();
                blogItems.Id = Convert.ToInt32(row.ItemArray[0]);
                blogItems.Title = Convert.ToString(row.ItemArray[1]);
                blogItems.permalink = Convert.ToString(row.ItemArray[2]);
                blogItems.SetAsHomepage = Convert.ToBoolean(row.ItemArray[3]);
                blogItems.Description = Convert.ToString(row.ItemArray[4]);
                blogItems.Body = (row.ItemArray[5]).ToString();
                blogItems.FeedProxyUrl = Convert.ToString(row.ItemArray[6]);
                blogItems.postsperPage = Convert.ToInt32(row.ItemArray[7]);
                blogItems.Post = Convert.ToString(row.ItemArray[8]);
                blogItems.Owner = Convert.ToString(row.ItemArray[9]);
                objblogList.Add(blogItems);
            }
            return objblogList;
        }
        public void createBlog(string title, string permalink, bool setashomepage, string desc, string body, string feedproxyurl, int postsperpage, string post, string owner, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("createNewBlog", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@title", title.Trim());
            cmd.Parameters.AddWithValue("@permalink", permalink.Trim());
            cmd.Parameters.AddWithValue("@setashomepage", setashomepage);
            cmd.Parameters.AddWithValue("@desc", desc.Trim());
            cmd.Parameters.AddWithValue("@body", body);
            cmd.Parameters.AddWithValue("@feedproxyurl", feedproxyurl.Trim());
            cmd.Parameters.AddWithValue("@postperpage", postsperpage);
            cmd.Parameters.AddWithValue("@post", post.Trim());
            cmd.Parameters.AddWithValue("@owner", owner.Trim());
            cmd.Connection = con;
            int result = cmd.ExecuteNonQuery();
            con.Close();
        }
        public void updateBlogById(int? Id, string title, string permalink, bool setashomepage, string desc, string body, string feedproxyurl, int postsperpage, string post, string owner, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("UpdateBlogById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@title", title.Trim());
            cmd.Parameters.AddWithValue("@permalink", permalink.Trim());
            cmd.Parameters.AddWithValue("@setashomepage", setashomepage);
            cmd.Parameters.AddWithValue("@desc", desc.Trim());
            cmd.Parameters.AddWithValue("@body", body == null ? "" : body.Trim());
            cmd.Parameters.AddWithValue("@feedproxyurl", feedproxyurl.Trim());
            cmd.Parameters.AddWithValue("@postperpage", postsperpage);
            cmd.Parameters.AddWithValue("@post", post.Trim());
            cmd.Parameters.AddWithValue("@owner", owner.Trim());
            cmd.Connection = con;
            int result = cmd.ExecuteNonQuery();
            con.Close();
        }
        public BlogModelView getBlogById(int Id, string connectionString)
        {
            BlogModelView objblogs = new BlogModelView();
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            cmd.CommandText = "getBlogById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                objblogs.Id = Convert.ToInt32(row.ItemArray[0]);
                objblogs.Title = Convert.ToString(row.ItemArray[1]);
                objblogs.permalink = Convert.ToString(row.ItemArray[2]);
                objblogs.SetAsHomepage = Convert.ToBoolean(row.ItemArray[3]);
                objblogs.Description = Convert.ToString(row.ItemArray[4]);
                objblogs.Body = (row.ItemArray[5]).ToString();
                objblogs.FeedProxyUrl = Convert.ToString(row.ItemArray[6]);
                objblogs.postsperPage = Convert.ToInt32(row.ItemArray[7]);
                objblogs.Post = Convert.ToString(row.ItemArray[8]);
                objblogs.Owner = Convert.ToString(row.ItemArray[9]);
            }
            return objblogs;
        }
        public void DeleteBlogById(int Id, string connectionString)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("DeleteBlogById", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Connection = con;
            int result = cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
