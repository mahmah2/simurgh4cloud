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
    public class ProjectController : ControllerBase
    {
        private RuntimeConfig _runtimeConfig;
        private readonly ILogger _log;

        public ProjectController(ILogger<ContactController> logger,
            IOptions<RuntimeConfig> config)
        {
            _log = logger;
            _runtimeConfig = config.Value;
        }

        [HttpGet]
        [Route("GetClientProjects")]
        [ProducesResponseType(typeof(List<Project>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClientProjects(string clientId)
        {
            var result = new List<Project>();

            await Task.Run(() =>
                {
                    result = StaticData.Projects
                            .Where(p => p.ClientId.ToString() == clientId)
                            .ToList();

                    //var db = new ProjectRepository(_log, false);
                    //result = db.GetClientProjects(clientId).ToList();
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
        [ProducesResponseType(typeof(Project), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = default(Project);

            await Task.Run(() =>
                {
                    result = StaticData.Projects.FirstOrDefault(c => c.Id == id);

                    //var db = new ProjectRepository(_log, false);
                    //result = db.GetById(id).GetAwaiter().GetResult();
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
                        var db = new ProjectRepository(_log, false);
                        db.Add(new Project() { Name = name });
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
        public async Task<IActionResult> Put([FromBody] Project editedProject)
        {
            var result = false;

            try
            {
                _log.LogEntrance(nameof(Put), editedProject.ToString());

                var repository = new ProjectRepository(_log, false);

                var exisingProject = await repository.GetById(editedProject.Id);

                if (exisingProject == null)
                    await repository.AddAsync(editedProject);
                else
                    await repository.UpdateAsync(editedProject);

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
