using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cerberus.API.Controllers
{
    using Cerberus.Core.BL;
    using Cerberus.Core.DL;

    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        #region Action
        public ActionResult<List<Person>> Get()
        {
            PersonBusiness personBusiness = new PersonBusiness();
            return personBusiness.FindAll();
        }

        [HttpGet("{wechatid}")]
        public ActionResult<Person> Get(string wechatid)
        {
            PersonBusiness personBusiness = new PersonBusiness();

            return personBusiness.FindByWechatId(wechatid);
        }

        [HttpPost]
        public ActionResult<Person> Post(Person person)
        {
            PersonBusiness personBusiness = new PersonBusiness();

            person.Id = Guid.NewGuid().ToString();
            var result = personBusiness.Create(person);

            if (result)
                return CreatedAtAction(nameof(Get), new { id = person.Id }, person);
            else
                return BadRequest();
        }
        #endregion //Action
    }
}