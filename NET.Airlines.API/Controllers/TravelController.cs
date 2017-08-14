using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NET.Airlines.API.Controllers
{
    [RoutePrefix("api/travel")]
    public class TravelController : ApiController
    {
        [Route("get")]
        public Travel Get(Travel entity)
        {
            try
            {
                return new Core.Travel().Get(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [HttpPost]
        [Route("getAllTravels")]
        public IEnumerable<Data.DTO.Travel> GetAllTravels(Travel entity)
        {
            try
            {
                return new Core.Travel().GetAllTravels(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("getAllSources")]
        public HttpResponseMessage GetAllSources()
        {
            try
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, new Core.Travel().GetAllSources());

                response.Headers.Add("Access-Control-Allow-Origin", "*");
                response.Headers.Add("Access-Control-Allow-Headers", "Authorization,Content-Type,Accept,Origin,User-Agent,DNT,Cache-Control,X-Mx-ReqToken,Keep-Alive,X-Requested-With,If-Modified-Since");
                response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,OPTIONS");
                response.Headers.Add("ContentType", "application/x-www-form-urlencode; charset=UTF-8");

                return response;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("getAllDestinies")]
        public HttpResponseMessage GetAllDestinies()
        {
            try
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, new Core.Travel().GetAllDestinies());

                response.Headers.Add("Access-Control-Allow-Origin", "*");
                response.Headers.Add("Access-Control-Allow-Headers", "Authorization,Content-Type,Accept,Origin,User-Agent,DNT,Cache-Control,X-Mx-ReqToken,Keep-Alive,X-Requested-With,If-Modified-Since");
                response.Headers.Add("Access-Control-Allow-Methods", "POST,GET,OPTIONS");
                response.Headers.Add("ContentType", "application/x-www-form-urlencode; charset=UTF-8");

                return response;
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("insert")]
        public Travel Insert(Travel entity)
        {
            try
            {
                return new Core.Travel().Insert(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("update")]
        public Travel Update(Travel entity)
        {
            try
            {
                return new Core.Travel().Update(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("delete")]
        public Travel Delete(Travel entity)
        {
            try
            {
                return new Core.Travel().Delete(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}