using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication_Blog.Models
{
    public class BlogDb
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["BlogConn"].ToString();
            con = new SqlConnection(constring);
        }
        private SqlCommand GetCommand(string action)
        {
            connection(); 
            var cmd = new SqlCommand(action, con);
            cmd.CommandType = CommandType.StoredProcedure;
            if (con.State != ConnectionState.Open)
                con.Open();
            return cmd;
        }
        private BlogModel MapBlog(DataRow dr)
        {
            return new BlogModel
            {
                Id = Convert.ToInt32(dr["Id"]),
                title = Convert.ToString(dr["title"]),
                description = Convert.ToString(dr["description"]),
                url = Convert.ToString(dr["url"])
            };
        }

        public bool Add(BlogModel bmodel)
        { 
            var cmd = GetCommand("AddNewBlog");
            cmd.Parameters.AddWithValue("@title", bmodel.title);
            cmd.Parameters.AddWithValue("@description", bmodel.description);
            cmd.Parameters.AddWithValue("@url", bmodel.url);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return (i > 0);
        }

       
        public List<BlogModel> GetAll()
        {
            var blogs = new List<BlogModel>();

            var cmd = GetCommand("GetBlogs");
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                blogs.Add(MapBlog(dr));
            }
            return blogs;
        }

        public BlogModel GetBlog(int Id)
        { 
            SqlCommand cmd = GetCommand("GetBlog");
            cmd.Parameters.AddWithValue("@bId", Id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            con.Close();
            DataRow dr = dt.Rows[0];
            return MapBlog(dr);
        }

        public bool Update(BlogModel bmodel)
        {
            var cmd = GetCommand("UpdateBlog");
            cmd.Parameters.AddWithValue("@bId", bmodel.Id);
            cmd.Parameters.AddWithValue("@title", bmodel.title);
            cmd.Parameters.AddWithValue("@description", bmodel.description);
            cmd.Parameters.AddWithValue("@url", bmodel.url);

            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i > 0;
        }

        public bool Delete(int id)
        {
            var cmd = GetCommand("DeleteBlog");
            cmd.Parameters.AddWithValue("@bId", id);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return (i > 0);
        }

        public bool Login(Login lg)
        {
            var cmd = GetCommand("GetLogin");
            cmd.Parameters.AddWithValue("@uid", lg.UserId);
            cmd.Parameters.AddWithValue("@pwd", lg.Password);
            bool IsLogin = ((int)cmd.ExecuteScalar()) > 0;
            con.Close();
            return IsLogin;
        }
    }
}