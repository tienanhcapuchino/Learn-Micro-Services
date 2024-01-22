using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extension
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class APIBaseController : ControllerBase
    {
        protected readonly IHttpContextAccessor _contextAccessor;
        public APIBaseController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
    }
}
