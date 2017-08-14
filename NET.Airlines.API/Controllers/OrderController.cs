using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NET.Airlines.API.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        [Route("get")]
        public Order Get(Order entity)
        {
            try
            {
                return new Core.Order().Get(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("getAll")]
        public IEnumerable<Order> GetAll(Order entity)
        {
            try
            {
                return new Core.Order().GetAll(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("insert")]
        public Order Insert(Order entity)
        {
            try
            {
                return new Core.Order().Insert(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("update")]
        public Order Update(Order entity)
        {
            try
            {
                return new Core.Order().Update(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("delete")]
        public Order Delete(Order entity)
        {
            try
            {
                return new Core.Order().Delete(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}