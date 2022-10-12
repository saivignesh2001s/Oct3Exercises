using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sep31Exercises
{
    public partial class count : System.Web.UI.Page
    {
         int count1;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (!IsPostBack)
            {
               
                
                HiddenField1.Value ="0";
            }
            else
            {
                count1 =Convert.ToInt32(ViewState["count2"]);
               
               
            }*/

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                count1 = 0;
                
                count1 += 1;
            }
            else
            {
                count1 =Convert.ToInt32(Request.QueryString["counts"]);
                Response.Write(count1);
               
                count1+= 1;
            }
            TextBox1.Text=count1.ToString();
            
            //ViewState["count2"] = count1;
           
            Response.Redirect($"~/count.aspx?counts={count1}");
           

        }
    }
}