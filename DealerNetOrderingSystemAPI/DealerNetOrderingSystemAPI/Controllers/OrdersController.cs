using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;

namespace DealerNetOrderingSystemAPI.Controllers
{
    public class OrdersController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            orders entity = new orders();
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
        public IEnumerable<orders> Get()
        {
            orders orders = new orders();
            return orders.Get();
        }
        public HttpResponseMessage Post([FromBody]orders obj)
        {
            orders orders = new orders();
            string outMessage = string.Empty;
            if(orders.Create(obj, out outMessage))
            {
                obj.id = outMessage;
                var message = Request.CreateResponse(HttpStatusCode.Created, obj);
                message.Headers.Location = new Uri(Request.RequestUri + obj.id);
                return message;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,outMessage);
            }
            
        }
        public HttpResponseMessage Put([FromBody]orders obj)
        {
            HttpResponseMessage checkIfAlreadyInExistance = Get(obj.id);
            if (checkIfAlreadyInExistance.StatusCode != HttpStatusCode.NotFound)
                return Request.CreateResponse(HttpStatusCode.Conflict, "An entity with id " + obj.id + " already exists.");

            orders orders = new orders();
            string outMessage = string.Empty;
            if(orders.Update(obj, out outMessage))
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
            orders orders = new orders();
            string outMessage = string.Empty;
            if (orders.Delete(id, out outMessage))
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
