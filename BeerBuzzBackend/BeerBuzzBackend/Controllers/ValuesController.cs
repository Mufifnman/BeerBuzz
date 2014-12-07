using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BeerBuzzBackend.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post()
        {
            // call using this test client only
            // http://jsfiddle.net/dy57wocw/12/
            // yes

            var request = HttpContext.Current.Request;

            if (request.Files.Count > 0)
            {

                var docfiles = new List<string>();

                foreach (string file in request.Files)
                {

                    var postedFile = request.Files[file];

                    var filePath = Path.Combine(BuzzInfoStore.Instance.BuzzFileStoreDir, postedFile.FileName);

                    BuzzInfoStore.Instance.BuzzInfos.Add(request.Form["BuzzName"], new BuzzInfo() { Name = request.Form["BuzzName"], FilePath = filePath, Contributor = request.Form["Contributor"] });

                    postedFile.SaveAs(filePath);

                    docfiles.Add(filePath);

                }

                var result = Request.CreateResponse(HttpStatusCode.Created, docfiles);

            }
        }
    }
}
