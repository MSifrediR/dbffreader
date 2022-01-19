using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BassiAPI.Controllers
{
    public class DataController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public string Get(int id)
        {
            return BassiDBFReader.DBFReader.GetDataFromFile((BassiDBFReader.Tables)id);
        }
    }
}
