using NET.Airlines.Entity;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NET.Airlines.API.Controllers
{
    [RoutePrefix("api/location")]
    public class LocationController : ApiController
    {
        [HttpGet]
        [Route("getAllCities")]
        public HttpResponseMessage GetAllCities([FromUri]City entity)
        {
            try
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, new Core.City().GetAllCities(entity));

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

        [HttpGet]
        [Route("getAllCountries")]
        public HttpResponseMessage GetAllCountries([FromUri]Country entity)
        {
            try
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, new Core.Country().GetAllCountries(entity));

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

        [HttpGet]
        [Route("getAllContinents")]
        public HttpResponseMessage GetAllContinents([FromUri]Continent entity)
        {
            try
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, new Core.Continent().GetAllContinents(entity));

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
    }
}