using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sample01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : Controller
    {
        // GET: api/State
        [HttpGet]
        public ActionResult Get()
        {
            StateListViewModel vm = new StateListViewModel();
            vm.Status = 0;
            vm.States = State.GetAll();
            return Ok(vm);
        }
        // GET: api/Country/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                State s = new State(id);
                StateViewModel vm = new StateViewModel();
                vm.Status = 0;
                vm.State = s;
                vm.Cities = s.GetCities(id);
                return Ok(vm);
            }
            catch (RecordNotFoundException ex)
            {
                ErrorViewModel vm = new ErrorViewModel();
                vm.Status = 1;
                vm.ErrorMessage = ex.Message;
                return Ok(vm);
            }
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public ActionResult ByContinent(string id_state)
        {
            return Ok("Getting countries from continent " + id_state);
        }

        // POST: api/Country
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Country/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
