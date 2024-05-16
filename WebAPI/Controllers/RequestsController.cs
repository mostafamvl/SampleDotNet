using BLL;
using DAL.DAL;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Task_4._72.Controllers
{
    public class RequestsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult HandleRequest([FromBody] Request request)
        {
            var requestBLL = new RequestBLL();
            var responseBLL = new ResponseBLL();

            if (requestBLL.IsDuplicated(x => x.MobileNumber == request.MobileNumber))
            {
                return Content(HttpStatusCode.Conflict, responseBLL.GetAllByExpression(x => x.Status == 2));
            }
            else
            {
                if (requestBLL.Add(request))
                {
                    return Content(HttpStatusCode.OK, responseBLL.GetAllByExpression(x => x.Status == 1));
                }
                else
                {
                    return Content(HttpStatusCode.BadRequest, responseBLL.GetAllByExpression(x => x.Status == 3));
                }
            }
        }
    }
}
