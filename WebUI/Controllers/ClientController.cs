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
    public class ClientController : ControllerBase
    {
        private RuntimeConfig _runtimeConfig;
        private readonly ILogger _log;

        public ClientController(ILogger<ContactController> logger,
            IOptions<RuntimeConfig> config)
        {
            _log = logger;
            _runtimeConfig = config.Value;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Client>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get()
        {
            var result = new List<Client>();

            await Task.Run(() =>
            {
                var db = new ClientRepository(_log, false);
                result = db.GetAll().ToList();
            }
            );

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("GetById")]
        [ProducesResponseType(typeof(Client), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = default(Client);

            await Task.Run(() =>
                {
                    //result = StaticData.Clients.FirstOrDefault(c => c.Id == id);

                    var db = new ClientRepository(_log, false);
                    result = db.GetById(id).GetAwaiter().GetResult();
                }
            );

            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("CreateByName")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateByName(string name)
        {
            var result = false;

            try
            {
                await Task.Run(() =>
                    {
                        var db = new ClientRepository(_log, false);
                        db.Add(new Client() { ClientName = name });
                    }
                );

                return Ok(true);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message);
                return NotFound(new MessageToClient(ex.Message));
            }
        }

        [HttpGet]
        [Route("Add")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Add()
        {
            return Ok(true);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put([FromBody] Client editedClient)
        {
            var result = false;

            try
            {
                _log.LogEntrance(nameof(Put), editedClient.ToString());

                var repository = new ClientRepository(_log, false);

                var exisingClient = await repository.GetById(editedClient.Id);

                if (exisingClient == null)
                    await repository.AddAsync(editedClient);
                else
                    await repository.UpdateAsync(editedClient);

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

    }
}
