using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NET.Airlines.API.Controllers
{
    [RoutePrefix("api/airline")]
    public class AirlineController : ApiController
    {
        [Route("get")]
        public Airline Get(Airline entity)
        {
            try
            {
                return new Core.Airline().Get(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("getAll")]
        public IEnumerable<Airline> GetAll(Airline entity)
        {
            try
            {
                return new Core.Airline().GetAll(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("insert")]
        public Airline Insert(Airline entity)
        {
            try
            {
                return new Core.Airline().Insert(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("update")]
        public Airline Update(Airline entity)
        {
            try
            {
                return new Core.Airline().Update(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("delete")]
        public Airline Delete(Airline entity)
        {
            try
            {
                return new Core.Airline().Delete(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}