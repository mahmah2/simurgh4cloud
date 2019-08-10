using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebUI.Helpers
{
    public class GoogleHelper
    {
        public static Task<HttpResponseMessage> CallGoogleSiteVerifyAsync(string response)
        {
            var siteSecret = "6Ld2CqoUAAAAAHDTS3mzzwzJMP6wTY80NbCQM6GA";
            var baseUri = "https://www.google.com/recaptcha/api/siteverify";
            var client = new HttpClient();

            var uri = QueryHelpers.AddQueryString(baseUri, new Dictionary<string, string>() {
                    {"secret", siteSecret},
                    {"response", response},
                });

            return client.GetAsync(uri); ;
        }
    }
}
