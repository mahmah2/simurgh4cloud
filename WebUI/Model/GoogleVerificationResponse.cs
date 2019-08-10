using System.Collections.Generic;
using Newtonsoft.Json;

namespace WebUI.Model
{
    public class GoogleVerificationResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        public string challenge_ts { get; set; } // timestamp of the challenge load (ISO format yyyy-MM-dd'T'HH:mm:ssZZ)

        public string hostname { get; set; }         // the hostname of the site where the reCAPTCHA was solved

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}
