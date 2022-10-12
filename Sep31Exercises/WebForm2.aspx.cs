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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           
            try
            {

                int i = Convert.ToInt32(TextBox1.Text);
                Dal_member u = new Dal_member();
                Bal_member s = u.findmember(i);
                TextBox2.Text = s.member_name.ToString();
                ////Burt,a,
                
            }
           catch(Exception ex)
            {
                Response.Redirect("~/notfound.aspx");
            }
        }
    }
}