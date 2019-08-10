using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Simurgh.Business;
using WebUI.Model;

namespace WebUI.Controllers
{
/*    public class DecodeRequest
    {
        public string Message;
    }

    [Route("api/[controller]")]
    [ApiController]
    public class GoogleController : ControllerBase
    {
        private RuntimeConfig _runtimeConfig;
        public GoogleController(IOptions<RuntimeConfig> config)
        {
            _runtimeConfig = config.Value;
        }

        private Task<HttpResponseMessage> CallGoogleSiteVerifyAsync(string response)
        {
            var siteSecret = "6Ld2CqoUAAAAAHDTS3mzzwzJMP6wTY80NbCQM6GA";
            var baseUri = "https://www.google.com/recaptcha/api/siteverify";
            var client = new HttpClient();

            var uri = QueryHelpers.AddQueryString(baseUri, new Dictionary<string, string>() {
                    {"secret", siteSecret},
                    {"response", response},
                });

            return client.GetAsync(uri); ;
        }


        [HttpPost]
        [Route("decode")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Decode(DecodeRequest encodedMsg)
        {
            try
            {
                var responseTask = await CallGoogleSiteVerifyAsync(encodedMsg.Message);

                if (responseTask.IsSuccessStatusCode)
                {
                    var response = await responseTask.Content.ReadAsStringAsync();
                    return Ok(response);
                }
                else
                {
                    return NotFound($"Error in communication with Google : {responseTask.ReasonPhrase}");
                }

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


    }
*/

}
