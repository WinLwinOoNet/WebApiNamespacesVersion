using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Routing;

namespace WebApiNamespacesVersion.Web.Common.Routing
{
    /// <summary>
    ///     This class implements the IHttpRouteConstraint.Match method. Match will return true if the specified
    ///     parameter name equals the AllowedVersion property, which is initialized in the constructor.
    /// </summary>
    /// <remarks>
    ///     Inspired by ASP.NET Web API 2: Building a REST Service from Start to Finish 2nd ed. Edition by Jamie Kurtz, Brian Wortman.
    ///     https://www.amazon.com/ASP-NET-Web-API-Building-Service/dp/1484201108
    /// </remarks>
    public class ApiVersionConstraint : IHttpRouteConstraint
    {
        public ApiVersionConstraint(string allowedVersion)
        {
            AllowedVersion = allowedVersion.ToLowerInvariant();
        }

        public string AllowedVersion { get; private set; }

        public bool Match(HttpRequestMessage request, IHttpRoute route, string parameterName,
            IDictionary<string, object> values, HttpRouteDirection routeDirection)
        {
            object value;
            if (values.TryGetValue(parameterName, out value) && value != null)
            {
                return AllowedVersion.Equals(value.ToString().ToLowerInvariant());
            }
            return false;
        }
    }
}