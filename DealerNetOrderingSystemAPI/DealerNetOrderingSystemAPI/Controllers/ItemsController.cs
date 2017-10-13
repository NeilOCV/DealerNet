using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;

namespace DealerNetOrderingSystemAPI.Controllers
{
    public class ItemsController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            items entity = new items();
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
        public IEnumerable<items> Get()
        {
            items items = new items();
            return items.Get();
        }
        public HttpResponseMessage Post([FromBody]items obj)
        {
            items items = new items();
            string outMessage = string.Empty;
            if (items.Create(obj, out outMessage))
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
        public HttpResponseMessage Put([FromBody]items obj)
        {
            HttpResponseMessage checkIfAlreadyInExistance = Get(obj.id);
            if (checkIfAlreadyInExistance.StatusCode != HttpStatusCode.NotFound)
                return Request.CreateResponse(HttpStatusCode.Conflict, "An entity with id " + obj.id + " already exists.");

            items items = new items();
            string outMessage = string.Empty;
            if (items.Update(obj, out outMessage))
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
            items items = new items();
            string outMessage = string.Empty;
            if (items.Delete(id, out outMessage))
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
