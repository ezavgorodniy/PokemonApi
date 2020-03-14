using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Pokemon.FunctionalTests.Base
{
    public abstract class BaseIntegrationTests
    {
        protected readonly HttpClient Client = new HttpClient();
        protected readonly string ApiUrl;

        protected BaseIntegrationTests()
        {
            ReadLaunchSettings();
            ApiUrl = Environment.GetEnvironmentVariable("ApiUrl");
        }

        private static void ReadLaunchSettings()
        {
            if (!File.Exists("Properties\\launchSettings.json"))
            {
                return;
            }

            // https://stackoverflow.com/questions/43927955/should-getenvironmentvariable-work-in-xunit-test
            using var file = File.OpenText("Properties\\launchSettings.json");
            var reader = new JsonTextReader(file);
            var jObject = JObject.Load(reader);

            var variables = jObject
                .GetValue("profiles")
                //select a proper profile here
                .SelectMany(profiles => profiles.Children())
                .SelectMany(profile => profile.Children<JProperty>())
                .Where(prop => prop.Name == "environmentVariables")
                .SelectMany(prop => prop.Value.Children<JProperty>())
                .ToList();

            foreach (var variable in variables.Where(variable => Environment.GetEnvironmentVariable(variable.Name) == null))
            {
                Environment.SetEnvironmentVariable(variable.Name, variable.Value.ToString());
            }
        }
    }
}
