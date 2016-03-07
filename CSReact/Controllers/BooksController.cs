using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Script.Serialization;
using CSReact.Models;
using Newtonsoft.Json.Serialization;

namespace CSReact.Controllers
{
    public class BooksController : ApiController
    {
       public HttpResponseMessage Get() {
          IList<BookModels> result = new List<BookModels>();
          result.Add(new BookModels() { Author = "Michael Crichton", Title = "Jurassic Park" });
          result.Add(new BookModels() { Author = "Agatha Christie", Title = "And Then There Were None" });

          var formatter = new JsonMediaTypeFormatter();
          var json = formatter.SerializerSettings;

          json.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
          json.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
          json.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
          json.Formatting = Newtonsoft.Json.Formatting.Indented;
          json.ContractResolver = new CamelCasePropertyNamesContractResolver();
          json.Culture = new CultureInfo("en-GB");

          return Request.CreateResponse(HttpStatusCode.OK, result, formatter);
       }
    }
}
