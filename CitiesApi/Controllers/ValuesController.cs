using System.Collections.Generic;
using System.Threading.Tasks;
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
        public Task<List<City>> Get()
        {
            var client = Connector.Connect();
            IMongoDatabase db = client.GetDatabase("CitiesDatabase");
            var cityCollection = db.GetCollection<City>("Cities");
            var res = cityCollection.Find(_ => true).ToListAsync();
            return res;
        }

        // GET api/values/name
        [HttpGet("{name}")]
        public ActionResult<City> Get(string name)
        {
            var client = Connector.Connect();
            IMongoDatabase db = client.GetDatabase("CitiesDatabase");
            var cityCollection = db.GetCollection<City>("Cities");
            var res = cityCollection.Find(c => c.Name.Equals(name)).First();
            return res;
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
