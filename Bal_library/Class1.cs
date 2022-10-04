using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bal_library
{
    public class Bal_Book
    {
        public int Bookid
        {
            get;
            set;
        }
        public string Bname
        {
            get;
            set;
        }
        public string Author
        {
            get;
            set;
        }
        public double Cost
        {
            get;
            set;
        }
        public string Category
        {
            get;
            set;
        }
        public Bal_Book(int Book_No,string Name)
        {
            Bookid=Book_No;
            Bname= Name;
        }
        public Bal_Book()
        {

        }

    }
    public class Bal_member
    {
        public int member_id
        {
            get;
            set;
        }
        public string member_name
        {
            get;
            set;
        }
        public DateTime Accopen
        {
            get;
            set;
        }
        public int maxbooks
        {
            get;
            set;
        }
        public int penalty
        {
            get;
            set;
        }
    }
    public class Bal_issue
    {
        public int issueId
        {
            get;
            set;
        }
        public int memberid
        {
            get;
            set;
        }
        public int bookid
        {
            get;
            set;
        }
        public DateTime? issuedate
        {
            get;
            set;
        }
        public DateTime? returndate
        {
            get;
            set;
        }
        public string comments
        {
            get;
            set;
        }
    }
}
