using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bal_library;
using Dal_library;
namespace Sep31Exercises
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Dal_book book = new Dal_book();
            List<Bal_Book> books = book.listbooks();
            GridView3.DataSource = books;
            GridView3.DataBind();
            dal_issue book1 = new dal_issue();
            List<Bal_issue> books1 = book1.listissues();
            GridView4.DataSource = books1;
            GridView4.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Bal_issue bal_Issue = new Bal_issue();
            bal_Issue.issueId = Convert.ToInt32(TextBox1.Text);
            bal_Issue.memberid= Convert.ToInt32(TextBox2.Text);
            bal_Issue.bookid = Convert.ToInt32(TextBox3.Text);
            bal_Issue.issuedate =Convert.ToDateTime(Calendar2.SelectedDate);
       

           

            dal_issue u = new dal_issue();
            bool f=u.insertissue(bal_Issue);
            if (f)
            {
                TextBox4.Text = "inserted successfully";
            }
            else
            {
                TextBox4.Text = "Mismatches occured";
            }
            dal_issue book11 = new dal_issue();
            List<Bal_issue> books11 = book11.listissues();
            GridView2.DataSource = books11;
            GridView2.DataBind();


        }
        

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Button2_Click1(object sender, EventArgs e)
        {
            dal_issue u3 = new dal_issue();
            int h = Convert.ToInt32(TextBox5.Text);
            List<Tuple<string,string>> sm = u3.pastbooks(h);
            GridView8.DataSource = sm;
            GridView8.DataBind();
            List<Tuple<string,string>> ms = u3.presentbooks(h);
            GridView7.DataSource = ms;
            GridView7.DataBind();
        }


    }
}