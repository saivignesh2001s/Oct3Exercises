using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sep31Exercises
{
    public partial class Problem1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string username=TextBox1.Text;
            string password=TextBox2.Text;
            Session["uname"]=username;
            Session["pword"]=password;
            Response.Redirect("~/Problem1.1f");

        }
    }
}