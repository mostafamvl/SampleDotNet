using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BLL
{
    public class ResponseBLL
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public List<ResponseBLL> GetAllByExpression(Expression<Func<ResponseBLL, bool>> _Expression)
        {
            ResponseBLL response;
            var responseList = new List<ResponseBLL>();

            response = new ResponseBLL
            {
                Status = 1,
                Message = "Request Is Added",
            };
            responseList.Add(response);

            response = new ResponseBLL
            {
                Status = 2,
                Message = "MobileNumber was added before",
            };
            responseList.Add(response);

            response = new ResponseBLL
            {
                Status = 3,
                Message = "An unexpected error has occurred. Please try again later.",
            };
            responseList.Add(response);

            return responseList;
        }
    }
}
