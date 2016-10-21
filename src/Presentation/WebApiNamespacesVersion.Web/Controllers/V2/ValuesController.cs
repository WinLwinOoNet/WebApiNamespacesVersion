using System.Collections.Generic;
using System.Web.Http;

namespace WebApiNamespacesVersion.Web.Controllers.V2
{
    [RoutePrefix("api/{apiVersion:apiVersionConstraint(v2)}/values")]
    public class ValuesController : ApiController
    {
        // GET api/v2/values
        [Route("")]
        public IEnumerable<string> Get()
        {
            return new string[] { "v2-value1", "v2-value2" };
        }

        // GET api/v2/values/5
        [Route("{id}")]
        public string Get(int id)
        {
            return "v2-value-" + id;
        }
    }
}
