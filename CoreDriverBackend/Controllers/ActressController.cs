using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDriverBackend.DataService;
using CoreDriverBackend.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreDriverBackend.Controllers
{
    [Route("api/Actress")]
    public class ActressController : Controller
    {
        // GET: api/Actress
        [HttpGet]
        public string Get()
        {
            var result = string.Empty;
            
            IActressDataService dataService = new CoreActressModel();
            result = dataService.GetAllData();
            
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string name)
        {
            var result = string.Empty;
            
            IActressDataService dataService = new CoreActressModel();
            result = dataService.GetDataByNameCn(name);
            
            return result;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var result = string.Empty;
            
            IActressDataService dataService = new CoreActressModel();
            result = dataService.AddNewData(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
