using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using CoreDriverBackend.DataService;
using CoreDriverBackend.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreDriverBackend.Controllers
{
    [Route("api/Video")]
    public class VideoController : Controller
    {
        // GET: api/values
        [HttpGet]
        public string Get()
        {
            var result = string.Empty;
            
            IVideoDataService dataService = new CoreVideoModel();
            result = dataService.GetAllData();

            //result = System.Net.WebUtility.UrlDecode(result);
            
            return result;
        }

        // GET api/Video/5
        [HttpGet("{id}")]
        public string Get(string serial)
        {
            var result = string.Empty;
            
            IVideoDataService dataService = new CoreVideoModel();
            result = dataService.GetDataByWholeSerial(serial);
            
            return result;
        }

        // POST api/Video
        [HttpPost]
        public string Post([FromBody] object value)
        {
            if (value == null)
            {
                return "503";
            }

            var result = string.Empty;
            var videoString = value.ToString();
            //var dataObj = new JsonResult(value.ToString());
            try
            {
                var coreVideo = JsonConvert.DeserializeObject<CoreVideo>(videoString);
                IVideoDataService dataService = new CoreVideoModel();
                result = dataService.AddNewData(coreVideo);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

            
            return result;
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
