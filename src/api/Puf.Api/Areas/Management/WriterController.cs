using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Puf.Contracts.Management;
using Puf.Services.Management.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Puf.Api.Areas.Management
{
    [Route("api/[area]/[controller]")]
    [Area("Management")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        private readonly IWriterService service;

        public WriterController(IWriterService service)
        {
            this.service = service;
        }

        [HttpGet("list/{count}")]
        public IEnumerable<WriterDto> ListWriters(int count)
        {
            return service.GetListOfWriter(count);
        }
    }
}
