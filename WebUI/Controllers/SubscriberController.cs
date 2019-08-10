using System;
using System.Collections.Generic;
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
using Simurgh.DAL;
using Simurgh.DAL.Model;
using WebUI.Helpers;
using WebUI.Model;

namespace WebUI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private RuntimeConfig _runtimeConfig;
        private readonly ILogger _log;

        public SubscriberController(ILogger<ContactController> logger,
            IOptions<RuntimeConfig> config)
        {
            _log = logger;
            _runtimeConfig = config.Value;
        }

        [HttpGet]
        [Route("Add")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Add()
        {
            return Ok(true);
        }

        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Add([FromBody] SubscribeRequest request)
        {
            var result = false;

            try
            {
                _log.LogEntrance(nameof(Add), request.ToString());

                var repository = new SubscriberRepository(_log ,false);

                var newSubscriber = new Subscriber(request.FirstName, request.EMail);

                await repository.AddAsync( newSubscriber );

                result = true;

                return Ok(result);
            }
            catch (Exception ex)
            {
                _log.LogError($"my exception : [{ex.Message}]  [{ex.StackTrace}]");

                return Ok(false);
            }
            finally
            {
                _log.LogExit(nameof(Add), result.ToString());
            }
        }

        [HttpGet]
        [Route("List")]
        [ProducesResponseType(typeof(List<Subscriber>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListSubscribers(string passcode)
        {
            var result = new List<Subscriber>();

            try
            {
                if (passcode == "simurghi")
                {
                    _log.LogEntrance(nameof(ListSubscribers), passcode.ToString());

                    var repository = new SubscriberRepository(_log, false);

                    result = repository.GetAll().ToList();

                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _log.LogError($"my exception : [{ex.Message}]  [{ex.StackTrace}]");

                return NotFound(false);
            }
            finally
            {
                _log.LogExit(nameof(Add), result.ToString());
            }
        }


    }
}
