using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NET.Airlines.API.Controllers
{
    [RoutePrefix("api/flight")]
    public class FlightController : ApiController
    {
        [Route("get")]
        public Flight Get(Flight entity)
        {
            try
            {
                return new Core.Flight().Get(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("getAll")]
        public IEnumerable<Flight> GetAll(Flight entity)
        {
            try
            {
                return new Core.Flight().GetAll(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("insert")]
        public Flight Insert(Flight entity)
        {
            try
            {
                return new Core.Flight().Insert(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("update")]
        public Flight Update(Flight entity)
        {
            try
            {
                return new Core.Flight().Update(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("delete")]
        public Flight Delete(Flight entity)
        {
            try
            {
                return new Core.Flight().Delete(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}