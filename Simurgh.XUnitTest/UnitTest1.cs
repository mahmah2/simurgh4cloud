using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Threading;
using WebUI.Controllers;
using WebUI.Helpers;
using WebUI.Model;
using Xunit;
using Xunit.Abstractions;

namespace Simurgh.XUnitTest
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// This routine is a play ground to observe interaction with google api regarding reCaptcha
        /// </summary>
        [Fact]
        public void Test1()
        {
            var captchaEncrypted = @"03AOLTBLQqSv7BqJvZBSSd6ieO1FGaq7pnyn7JY_yXDoKpKwcJXDq8buuP6jBL5B5UjhVP7votjIVX2_Ok08PgrxMK0MDmlLRwScCdH_DxP7Bx6_fIpyJ-fAU2jD96-wnGMVpHNwu3tGM1UajJcSQw580NFV9yndSLCp3G4clrHmlaYaOUqgwOh2CCeKiGy8-Pw_NAYZI58Ii6QI3OqF-vwxV1fdsUrh88oXcVitc2Ad8N0fLqY68HvBmVYjzkW1Zvx77nm4Q6cEC8Twf4TYVcB_IBnLfbiz59klCfBB0b8aChW0zXn0uAzVn5XZJpVxM2BgUrtyaAaMJbh9Vvxi-gCJN76TtLFM8aTI7lGhtGulw99sh30N4lDGY064S7jJ9iOx8Cm1QoO6IS";

            var googleResponseTask = GoogleHelper.CallGoogleSiteVerifyAsync(captchaEncrypted);
            while (!googleResponseTask.IsCompleted)
                Thread.Sleep(200);

            if (googleResponseTask.Result.IsSuccessStatusCode)
            {
                var readAsStrTask = googleResponseTask.Result.Content.ReadAsStringAsync();

                while (!readAsStrTask.IsCompleted)
                    Thread.Sleep(200);


                output.WriteLine($"raw result = {readAsStrTask.Result}");


                var googleResponse =
                    JsonConvert.DeserializeObject<GoogleVerificationResponse>(readAsStrTask.Result,
                    new JsonSerializerSettings()
                    {
                        Error = (s, e) => { e.ErrorContext.Handled = true; },
                        //Error = HandleErrors,
                    });

                output.WriteLine($"google success = {googleResponse.Success}");
                output.WriteLine($"google host = {googleResponse.hostname}");
                var errors = googleResponse.ErrorCodes == null ? "" : string.Join(',', googleResponse.ErrorCodes);
                output.WriteLine($"google errors = {errors} ");

                if (googleResponse.Success)
                {
                    output.WriteLine($"Successful recaptcha!");
                }
            }

            Assert.Equal(1, 1);
        }

        private void HandleErrors(object sender, ErrorEventArgs e)
        {
            var currentError = e.ErrorContext.Error.Message;
            output.WriteLine($"Error");
            output.WriteLine($"error in json = {currentError}");

            e.ErrorContext.Handled = true;
        }
    }
}
