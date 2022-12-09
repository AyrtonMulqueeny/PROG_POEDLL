using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PROG_POEDLL.Models;

namespace PROG_POEDLL
{
   public  class Query
    {
        private readonly StudentContext _context = new StudentContext();

        //default constructor
        public Query()
        {
        }


        //returns a list of session based of a id
        public List<Session> sessions(int mid)
        {
            List<Session> session = _context.Sessions.Where(s => s.ModuleId == mid).ToList();
            return session;
        }


       
        public SUser Login(string UserName,string password)
        {
            using (var context = new StudentContext())
            {
                foreach (var item in context.SUsers)
                {
                    if (item.UserName.Equals(UserName) && item.Password.SequenceEqual(password))
                    {
                        return item;
                    }
                }
                return null;

            }
        }






        //returns a user based on username
        public SUser getUser(string username)
        {
            {
                foreach (var item in _context.SUsers)
                {
                    if (item.UserName.Equals(username))
                    {
                        return item;
                    }
                }
                return null;
            }
        }

        //returns a semester based on id
        public Semester getSemester(int UserId)
        {

            using (var context = new StudentContext())
            {
                foreach (var item in context.Semesters)
                {
                    if (item.UserId == UserId)
                    {
                        return item;
                    }
                }
            }
            return null;
        }


        //returns all the modules of teh user
        public List<Module> mods(int id)
        {
            return _context.Modules.Where(m => m.SemesterId == id).ToList();

        }


        //uses the inputs and gets the sum of the hours and the week for the main data point
        public List<Session> hours(int curr, string d, int id)
        {
            int cur = (curr) - 1;
            DateTime weekstart = DateTime.Parse(d).AddDays(cur * 7);
            DateTime weekend = weekstart.AddDays(7);
            var modules = _context.Modules.Where(m => m.SemesterId == id);
            var ids = modules.Select(m => m.ModuleId);
            var sessions = _context.Sessions.Where(s => ids.Contains(s.ModuleId) && s.Date >= weekstart && s.Date < weekend)
                           .OrderBy(s => s.Date).Include(s => s.Module);
            //all can be methods in dll below as well
            List<Session> sess = sessions.ToList<Session>();
            foreach (var item in modules)
            {
                item.sess = sess.Where(s => s.ModuleId == item.ModuleId).ToList<Session>();
            }
            return sess;
        }


        //gets the enddate of the date 
        public string endDate(DateTime d, int i)
        {
            string g = d.AddDays((i * 7) - 1).ToShortDateString();
            return g;
        }
        //changed returing variable type due to error in ModuleController (Line 73) with thsi changed now its fixed
        public decimal selfstudy(int credit, int num, decimal hours)
        {
            decimal self = (((credit * 10) / (num)) - hours);
            return self;
        }
        //originally i had
/*public double selfstudy(int credit, int num, double hours)
{
    double self = (((credit * 10) / (num)) - hours);
    return self;
}



*/
}
}
