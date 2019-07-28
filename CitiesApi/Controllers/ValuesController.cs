using System.Collections.Generic;
using CitiesApi.Database;
using CitiesApi.Model;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace CitiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public ActionResult<string> Get(string name)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] List<City> cities)
        {
            var client = Connector.Connect();
            IMongoDatabase db = client.GetDatabase("CitiesDatabase");
            var cityCollection = db.GetCollection<City>("Cities");
            cityCollection.InsertMany(cities);
        }

        // PUT api/values/5
        [HttpPut("{name}")]
        public void Put(string name, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{name}")]
        public void Delete(string name)
        {
        }
    }
}
