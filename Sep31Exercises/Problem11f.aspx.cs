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
    public partial class Problem1__1f : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("Welcome" +" "+ Session["uname"].ToString());
          int cnt = Convert.ToInt32(Session["uname"]);
            dal_issue lo = new dal_issue();
            List<Tuple<string,string>> gh = lo.pastbooks(cnt);
            GridView1.DataSource = gh;
            GridView1.DataBind();
            dal_issue ol = new dal_issue();
            List<Tuple<string, string>> hg = ol.presentbooks(cnt);
            GridView2.DataSource = hg;
            GridView2.DataBind();



        }
    }
}