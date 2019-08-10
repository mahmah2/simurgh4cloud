using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Simurgh.Business;
using WebUI.Helpers;
using WebUI.Model;

namespace WebUI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private RuntimeConfig _runtimeConfig;
        private readonly ILogger<ContactController> _log;

        public ContactController(ILogger<ContactController> logger,
            IOptions<RuntimeConfig> config)
        {
            _log = logger;
            _runtimeConfig = config.Value;
        }

        [HttpGet]
        [Route("SendMail")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SendEmail()
        {
            return Ok(true);
        }

        [HttpPost]
        [Route("SendMail")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> SendEmail([FromBody] ContactRequest request)
        {
            var result = false;

            try
            {
                _log.LogEntrance(nameof(SendEmail), request.ToString() );


                var checkGoogle = await GoogleHelper.CallGoogleSiteVerifyAsync(request.CaptchaRequest);
                if (checkGoogle.IsSuccessStatusCode)
                {
                    var responseStr = await checkGoogle.Content.ReadAsStringAsync();

                    _log.LogInformation($"response from google : {responseStr}");

                    var googleResponse = JsonConvert.DeserializeObject<GoogleVerificationResponse>(responseStr,
                        new JsonSerializerSettings() { Error = (s,e)=> { e.ErrorContext.Handled = true; } });

                    if (googleResponse.Success)
                    {
                        var sender = (IMailSender)new SmtpSender();
                        sender.Authenticate(_runtimeConfig.SmtpServer, _runtimeConfig.SmtpUserName, _runtimeConfig.SmtpPassword);
                        sender.SendPlain(_runtimeConfig.SmtpUserName,
                                        _runtimeConfig.ContactUsEmails,
                                        request.Subject,
                                        $"From : {request.EMail}\nRequest : {request.Body}"
                            );

                        _log.LogInformation($"message sent successfull : {request.ToString()}");
                        result = true;
                    }
                    else
                    {
                        var errors = googleResponse.ErrorCodes == null || googleResponse.ErrorCodes.Count<1 ?
                            "error from google is unclear" : string.Join(",", googleResponse.ErrorCodes);

                        return NotFound(errors);
                    }
                }
                else
                {
                    return NotFound("Error in communication with google.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound($"my exception : [{ex.Message}]  [{ex.StackTrace}]");
            }
            finally
            {
                _log.LogExit(nameof(SendEmail),  result.ToString() );
            }
        }

    }
}
