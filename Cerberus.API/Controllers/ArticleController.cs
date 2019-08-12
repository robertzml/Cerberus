using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Cerberus.Core.BL;
using Cerberus.Core.DL;

namespace Cerberus.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        public ActionResult<List<Article>> List(int page)
        {
            ArticleBusiness articleBusiness = new ArticleBusiness();
            return articleBusiness.FindByPage(page);
        }
    }
}