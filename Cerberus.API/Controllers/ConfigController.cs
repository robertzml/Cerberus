using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cerberus.Core.BL;
using Cerberus.Core.DL;
using Cerberus.Core.Utility;

namespace Cerberus.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        #region Action
        [HttpGet("{wechatid}")]
        public ActionResult<ConfigData> Get(string wechatid)
        {
            ConfigBusiness configBusiness = new ConfigBusiness();
            var data = configBusiness.GetData(wechatid);

            return data;
        }
        #endregion //Action
    }
}