using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Bal_library;

namespace Dal_library
{
    public class Dal_book
    {
        public List<Bal_Book> listbooks()
        {
            List<Bal_Book> co=new List<Bal_Book> ();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["librarydb"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from Book", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Bal_Book book = new Bal_Book();
                book.Bookid = Convert.ToInt32(dr[0]);
                book.Bname = dr[1].ToString();
                book.Author=dr[2].ToString();
                book.Cost = Convert.ToDouble(dr[3]);
                book.Category = dr[4].ToString();
                co.Add(book);
            }
            conn.Close();
            conn.Dispose();
            return co;
        }
        public Bal_Book findbook(int no)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["librarydb"].ConnectionString);
            SqlCommand cmd = new SqlCommand($"Select * from Book where Book_id={no}", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Bal_Book book = new Bal_Book();
            while (dr.Read())
            {
               
                book.Bookid = Convert.ToInt32(dr[0]);
                book.Bname = dr[1].ToString();
                book.Author = dr[2].ToString();
                book.Cost = Convert.ToDouble(dr[3]);
                book.Category = dr[4].ToString();
               
            }
            conn.Close();
            conn.Dispose();
            return book;



        }
        
    }
    public class Dal_member
    {
        public Bal_member findmember(int no)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["librarydb"].ConnectionString);
            SqlCommand cmd = new SqlCommand($"Select * from member where Member_Id={no}", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            Bal_member n1 = new Bal_member();
            while (dr.Read())
            {
                n1.member_id = Convert.ToInt32(dr[0]);
                n1.member_name = dr[1].ToString();
                n1.Accopen = Convert.ToDateTime(dr[2]);
                n1.maxbooks = Convert.ToInt32(dr[3]);
                n1.penalty = Convert.ToInt32(dr[4]);

            }
            conn.Close();
            conn.Dispose();
            return n1;



        }
    }
    public class dal_issue
    {
        public bool insertissue(Bal_issue p)
        {
            List<Bal_issue> c2 = listissues();
            bool status = true;
            foreach(var item in c2)
            {
                if (item.issueId == p.issueId)
                {
                    status= false;
                }
                else if (item.issueId != p.issueId && item.bookid == p.bookid && item.memberid == p.memberid && item.returndate == null)
                {
                    status=false;
                }
                
               
            }
            if (status)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["librarydb"].ConnectionString);
                SqlCommand cmd = new SqlCommand("insert into issue(Lib_Issue_Id,Member_Id,Book_No,issue_date) values (@para1,@para2,@para3,@para4)", conn);
                cmd.Parameters.AddWithValue("@para1",p.issueId);
                cmd.Parameters.AddWithValue("@para2", p.memberid);
                cmd.Parameters.AddWithValue("@para3", p.bookid);
                cmd.Parameters.AddWithValue("@para4", p.issuedate);
               


                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                if (i==1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                

            }
            else
            {
                return false;
            }

        }
        public bool updateissue(int i)
        {
            
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["librarydb"].ConnectionString);
                SqlCommand cmd = new SqlCommand($"update issue set return_date=@para1,comments=@para2 where lib_issue_id={i} and comments is null",conn);
                cmd.Parameters.AddWithValue("@para1",DateTime.Now);
                cmd.Parameters.AddWithValue("@para2","returned");
            


                conn.Open();
                int j = cmd.ExecuteNonQuery();
                conn.Close();
                conn.Dispose();
                if (j == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


           

        }
        public List<Tuple<string,string>> presentbooks(int no)
        {
            List<Tuple<string,string>> s = new List<Tuple<string,string>>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["librarydb"].ConnectionString);
            SqlCommand cmd = new SqlCommand($"Select j.member_id,i.Book_No,i.Book_Name from Book i join issue j on i.Book_No=j.Book_No where j.comments is null group by j.member_id,i.Book_No,i.Book_Name having j.member_id={no}",conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                
                string j = dr[1].ToString();
                string s1 = dr[2].ToString();
                Tuple<string,string> s2=Tuple.Create<string,string>(j,s1);

                s.Add(s2);

            }
            conn.Close();
            conn.Dispose();
            return s;

        }
        public List<Tuple<string, string>> pastbooks(int no)
        {
            List<Tuple<string, string>> s = new List<Tuple<string, string>>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["librarydb"].ConnectionString);
            SqlCommand cmd = new SqlCommand($"Select j.member_id,i.Book_No,i.Book_Name from Book i join issue j on i.Book_No=j.Book_No where j.comments='returned' group by j.member_id,i.Book_No,i.Book_Name having j.member_id={no}", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string j = dr[1].ToString();
                string s1 = dr[2].ToString();
                Tuple<string, string> s2 = Tuple.Create<string, string>(j, s1);

                s.Add(s2);


            }
            conn.Close();
            conn.Dispose();
            return s;

        }
        public List<Bal_issue> listissues()
        {
            List<Bal_issue> co1 = new List<Bal_issue>();
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["librarydb"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * from issue", conn);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Bal_issue book = new Bal_issue();
                book.issueId = Convert.ToInt32(dr[0]);
                book.bookid = Convert.ToInt32(dr[1]);
                book.memberid = Convert.ToInt32(dr[2]);
                if (dr[3] is DBNull)
                {
                    book.issuedate =null;
                }
                else
                {
                    book.issuedate = Convert.ToDateTime(dr[3]);
                   
                }
                if (dr[4] is DBNull)
                {
                    book.returndate =null;

                }
                else
                {
                    book.returndate = Convert.ToDateTime(dr[4]);
                    
                }
                if (dr[5] is DBNull)
                {
                    book.comments = null;

                }
                else
                {
                    book.comments = dr[5].ToString();
                 
                }
                co1.Add(book);
            }
            conn.Close();
            conn.Dispose();
            return co1;
        }

    }
}
