
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Simurgh.Business;
using Simurgh.DAL;
using Simurgh.DAL.Model;
using Simurgh.Util;
using WebUI.Helpers;
using WebUI.Model;

namespace WebUI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FileSystemController : ControllerBase
    {
        private RuntimeConfig _runtimeConfig;
        private string _rootPath;
        private readonly ILogger _log;

        public FileSystemController(ILogger<ContactController> logger,
            IOptions<RuntimeConfig> config,
            IHostingEnvironment env)
        {
            _log = logger;
            _runtimeConfig = config.Value;
            _rootPath = env.WebRootPath;
        }

        [HttpGet]
        [Route("ProjectFiles")]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProjectsFiles(string id)
        {
            string[] result = new string[0];

            try
            {
                await Task.Run(() =>
                    {
                        var browseFolder = Path.Combine(_rootPath, Constants.ProjectsFolderName, id);

                        result = Directory.GetFiles(browseFolder, "*.*",
                                                    SearchOption.TopDirectoryOnly)
                                        .Select(fp => Path.Combine(Constants.ClientsFolderName, id, Path.GetFileName(fp))
                                                .Replace("\\", "/"))
                                        .ToArray();
                    }
                );

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("ClientFiles")]
        [ProducesResponseType(typeof(string[]), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetClientFiles(string id)
        {
            string[] result = new string[0];

            try
            {
                await Task.Run(() =>
                    {
                        var browseFolder = Path.Combine(_rootPath, Constants.ClientsFolderName, id);

                        result = Directory.GetFiles(browseFolder, "*.*",
                                                    SearchOption.TopDirectoryOnly)
                                        .Select(fp => Path.Combine(Constants.ClientsFolderName, id, Path.GetFileName(fp))
                                                    .Replace("\\", "/"))
                                        .ToArray();
                    }
                );

                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }



        [HttpPost, DisableRequestSizeLimit]
        [Route("PostClientFile")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostClientFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                var id = Request.Form["id"];
                var name = file.FileName;
                var serverFilePath = string.Empty;

                await Task.Run(() =>
                {
                    //var stream = file.OpenReadStream();

                    serverFilePath = Path.Combine(_rootPath, Constants.ClientsFolderName, id, name);

                    serverFilePath.MakeSureFolderExists();

                    using (Stream stream = file.OpenReadStream())
                    {
                        using (var binaryReader = new BinaryReader(stream))
                        {
                            var fileContent = binaryReader.ReadBytes((int)file.Length);

                            System.IO.File.WriteAllBytes(serverFilePath, fileContent);
                        }
                    }

                });

                return Ok(new MessageToClient($"{id} - {name} saved to {serverFilePath} successfully.")); 
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }

    public class FURequest
    {
        public IFormFile file { get; set; }
    }
}
