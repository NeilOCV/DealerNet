using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;

namespace DealerNetOrderingSystemAPI.Controllers
{
    public class CategoriesController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            categories entity = new categories();
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
        public IEnumerable<categories> Get()
        {
            categories categories = new categories();
            return categories.Get();
        }
        public HttpResponseMessage Post([FromBody]categories obj)
        {
            categories categories = new categories();
            string outMessage = string.Empty;
            if (categories.Create(obj, out outMessage))
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
        public HttpResponseMessage Put([FromBody]categories obj)
        {
            HttpResponseMessage checkIfAlreadyInExistance = Get(obj.id);
            if (checkIfAlreadyInExistance.StatusCode != HttpStatusCode.NotFound)
                return Request.CreateResponse(HttpStatusCode.Conflict, "An entity with id " + obj.id + " already exists.");

            categories categories = new categories();
            string outMessage = string.Empty;
            if (categories.Update(obj, out outMessage))
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
            categories categories = new categories();
            string outMessage = string.Empty;
            if (categories.Delete(id, out outMessage))
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
