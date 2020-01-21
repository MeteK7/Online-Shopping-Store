using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using OnlineShoppingStore.Models;
using System.Data.SqlClient;

namespace OnlineShoppingStore.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        //GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        void ConnectionString()
        {
            con.ConnectionString = @"Data Source=DESKTOP-MIB20HI\SQLEXPRESS;Initial Catalog=dbOnlineShopping;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
        }
        [HttpPost]

        public ActionResult Verify(Account acc)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText="SELECT * FROM Tbl_Login WHERE username='"+acc.Name+"' AND password='"+acc.Password+"'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                return View("Create");
            }
            else
            {
                con.Close();
                return View("Error");
            }
            
        }

    }
}