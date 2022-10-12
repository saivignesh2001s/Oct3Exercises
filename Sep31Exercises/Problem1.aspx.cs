using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal_library;
using Bal_library;

namespace Sep31Exercises
{
    public partial class Problem1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Focus();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int username=Convert.ToInt32(TextBox1.Text);
            string password=TextBox2.Text;
           dal_user ls = new dal_user();
            List<Bal_User> us=ls.listbooks();
            bool status = false;
            foreach(var item in us)
            {
                if(username==item.uname && item.password == password)
                {
                    status = true;
                }
            }
            if (status)
            {
                Session["uname"] = username;
                Session["pword"] = password;

                Response.Redirect("~/Problem11f.aspx");
            }
            else
            {
                Label1.Text = "Invalid login credentials..Try again";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = string.Empty;
            TextBox2.Text = string.Empty;
            TextBox1.Focus();
        }
    }
}