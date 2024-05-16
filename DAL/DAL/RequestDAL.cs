using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.DAL
{
    public class RequestDAL
    {
        public List<Request> GetAllByExpression(Expression<Func<Request, bool>> _Expression)
        {
            using (var db = new Entities())
            {
                try
                {
                    return db.Requests.Where(_Expression).ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                    return null;
                }
            }
        }

        public bool Add(Request request)
        {
            using (var db = new Entities())
            {
                try
                {
                    db.Requests.Add(request);
                    db.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e);
                    return false;
                }
            }
        }
    }
}
