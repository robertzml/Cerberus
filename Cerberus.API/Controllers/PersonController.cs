using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace Cerberus.API.Controllers
{
    using Cerberus.Core.BL;
    using Cerberus.Core.DL;
    using Cerberus.API.Utility;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("{code}")]
        public string Login(string code)
        {            
            using (HttpClient client = new HttpClient())
            {
                string url = "";
                HttpResponseMessage response = client.GetAsync(url).Result;
                return response.Content.ReadAsStringAsync().Result;
            }            
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        public ActionResult<List<Person>> List()
        {
            PersonBusiness personBusiness = new PersonBusiness();
            return personBusiness.FindAll();
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="wechatid"></param>
        /// <returns></returns>
        [HttpGet("{wechatid}")]
        public ActionResult<Person> Get(string wechatid)
        {
            PersonBusiness personBusiness = new PersonBusiness();

            return personBusiness.FindByWechatId(wechatid);
        }

        [HttpPost]
        public ActionResult<ResponseData> Create(Person person)
        {
            PersonBusiness personBusiness = new PersonBusiness();

            if (string.IsNullOrEmpty(person.WechatId))
            {
                return new ResponseData { ErrorCode = 1, ErrorMessage = "微信ID为空" };
            }

            var exist = personBusiness.FindByWechatId(person.WechatId);
            if (exist != null)
            {
                return new ResponseData { ErrorCode = 2, ErrorMessage = "用户已提交" };
            }

            person.Id = Guid.NewGuid().ToString();
            var result = personBusiness.Create(person);

            if (result)
                return new ResponseData { ErrorCode = 0, ErrorMessage = "提交成功" };
            else
                return BadRequest();
        }
        #endregion //Action
    }
}