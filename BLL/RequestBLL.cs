using DAL.DAL;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BLL
{
    public class RequestBLL
    {
        readonly RequestDAL requestDAL;
        public RequestBLL()
        {
            requestDAL = new RequestDAL();
        }
        public bool Add(Request request)
        {
            return requestDAL.Add(request);
        }

        public bool IsDuplicated(Expression<Func<Request, bool>> _Expression)
        {
            return requestDAL.GetAllByExpression(_Expression).Count() > 0;
        }
    }
}
