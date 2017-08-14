using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NET.Airlines.API.Controllers
{
    [RoutePrefix("api/way")]
    public class WayController : ApiController
    {
        [Route("get")]
        public Way Get(Way entity)
        {
            try
            {
                return new Core.Way().Get(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("getAll")]
        public IEnumerable<Way> GetAll(Way entity)
        {
            try
            {
                return new Core.Way().GetAll(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("insert")]
        public Way Insert(Way entity)
        {
            try
            {
                return new Core.Way().Insert(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("update")]
        public Way Update(Way entity)
        {
            try
            {
                return new Core.Way().Update(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("delete")]
        public Way Delete(Way entity)
        {
            try
            {
                return new Core.Way().Delete(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}