using DAL;
using DAL.Data;
using DAL.Entities;
using RestAPI.PasteAPI;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestAPI.Controllers
{
    public class PasteController : ApiController
    {
        private DataSeed _ds { get; set; }

        public PasteController() => _ds = new DataSeed();

        /// <summary>
        /// Get paste endpoint
        /// </summary>
        /// <param name="Identifier">Should be paste identifier</param>
        /// <returns>Returns paste from DB or from paste api</returns>
        [HttpGet]
        public IHttpActionResult GetPaste(string Identifier)
        {
            var paste = _ds.GetPaste(Identifier);

            if (paste != null)
            {
                _ds.ChangePasteAccessDate(paste.PasteId);
                var response = Request.CreateResponse(HttpStatusCode.OK, paste);
                response.Headers.Add("AccessDate", paste.AccessDate.Date.ToString("dd.MM.yyyy HH:mm:ss"));
                return base.ResponseMessage(response);
            }
            else
            {
                //Make request to api
                var response = PasteApiClient.GetRawPaste(Identifier);

                if (response.IsSuccessful)
                {
                    Paste pasteToAdd = new Paste
                    { Identifier = Identifier,
                        CreateDate = DateTime.Today,
                        Content = response.Content,
                        AccessDate = DateTime.Today
                    };

                    //Add the paste to DB
                    _ds.AddPaste(pasteToAdd);

                    var result = Request.CreateResponse(HttpStatusCode.OK, pasteToAdd);
                    result.Headers.Add("AccessDate", pasteToAdd.AccessDate.Date.ToString("dd.MM.yyyy"));
                    return base.ResponseMessage(result);
                }
            }
            
            return NotFound();
        }


        /// <summary>
        /// Delete paste endpoint
        /// </summary>
        /// <param name="Identifier"></param>
        /// <returns>Returns response code with result message</returns>
        [HttpDelete]
        public IHttpActionResult DeletePaste([FromUri] string Identifier)
        {
            if (_ds.DeletePaste(Identifier))
            {
                return Ok("Paste was deleted successfully");
            }
            else
            {
                return BadRequest("Something went wrong while tried to delete the paste");
            }

        }
    }
}
