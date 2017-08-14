using NET.Airlines.Entity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NET.Airlines.API.Controllers
{
    [RoutePrefix("api/ticket")]
    public class TicketController : ApiController
    {
        [Route("get")]
        public Ticket Get(Ticket entity)
        {
            try
            {
                return new Core.Ticket().Get(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("getAllTickets")]
        public HttpResponseMessage GetAllTickets(Ticket entity)
        {
            try
            {
                var response = Request.CreateResponse(HttpStatusCode.OK, new Core.Ticket().GetAllTickets(entity));

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
        public Ticket Insert(Ticket entity)
        {
            try
            {
                return new Core.Ticket().Insert(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("update")]
        public Ticket Update(Ticket entity)
        {
            try
            {
                return new Core.Ticket().Update(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }

        [Route("delete")]
        public Ticket Delete(Ticket entity)
        {
            try
            {
                return new Core.Ticket().Delete(entity);
            }
            catch (Exception e)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message));
            }
        }
    }
}