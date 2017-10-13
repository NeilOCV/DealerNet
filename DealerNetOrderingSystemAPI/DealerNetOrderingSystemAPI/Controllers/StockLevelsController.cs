using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;

namespace DealerNetOrderingSystemAPI.Controllers
{
    public class StockLevelsController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            stock_levels entity = new stock_levels();
            entity = entity.Get(id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entity with ID " + id + " not found.");
            }
        }
        public IEnumerable<stock_levels> Get()
        {
            stock_levels stock_levels = new stock_levels();
            return stock_levels.Get();
        }
        public HttpResponseMessage Post([FromBody]stock_levels obj)
        {
            stock_levels stock_levels = new stock_levels();
            string outMessage = string.Empty;
            if (stock_levels.Create(obj, out outMessage))
            {
                obj.id = outMessage;
                var message = Request.CreateResponse(HttpStatusCode.Created, obj);
                message.Headers.Location = new Uri(Request.RequestUri + obj.id);
                return message;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, outMessage);
            }

        }
        public HttpResponseMessage Put([FromBody]stock_levels obj)
        {
            HttpResponseMessage checkIfAlreadyInExistance = Get(obj.id);
            if (checkIfAlreadyInExistance.StatusCode != HttpStatusCode.NotFound)
                return Request.CreateResponse(HttpStatusCode.Conflict, "An entity with id " + obj.id + " already exists.");

            stock_levels stock_levels = new stock_levels();
            string outMessage = string.Empty;
            if (stock_levels.Update(obj, out outMessage))
            {
                var message = Request.CreateResponse(HttpStatusCode.Accepted, obj);
                message.Headers.Location = new Uri(Request.RequestUri + obj.id);
                return message;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotModified, outMessage);
            }
        }
        public HttpResponseMessage Delete(string id)
        {
            stock_levels stock_levels = new stock_levels();
            string outMessage = string.Empty;
            if (stock_levels.Delete(id, out outMessage))
            {
                var message = Request.CreateResponse(HttpStatusCode.OK);
                return message;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, outMessage);
            }
        }
    }
}
