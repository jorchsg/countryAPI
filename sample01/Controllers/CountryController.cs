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
    public class CountryController : ControllerBase
    {
        // GET: api/Country
        [HttpGet]
        public ActionResult Get()
        {
            CountryListViewModel vm = new CountryListViewModel();
            vm.Status = 0;
            vm.Countries = Country.GetAll();
            return Ok(vm);
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            try
            {
                Country c = new Country(id);
                CountryViewModel vm = new CountryViewModel();
                vm.Status = 0;
                vm.Country = c;
                vm.States = c.GetStates(id);
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
        public ActionResult ByContinent(string id_country)
        {
            return Ok("Getting countries from continent " + id_country);
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
