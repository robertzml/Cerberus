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
        [HttpGet("{id}")]
        public ActionResult<Person> Get(string id)
        {
            PersonBusiness personBusiness = new PersonBusiness();

            return personBusiness.FindById(id);
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