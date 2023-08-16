using GitHubConsumer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GitHubConsumer.Controllers
{
    [EnableCors("DevelopmentPolicy")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private IConfiguration Configuration;

        public GitHubController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpGet]
        public IEnumerable<GitHubRepo> GitHub()
        {
            IEnumerable<GitHubRepo> data = new List<GitHubRepo>();

            string owner = "meddlin";
            string URL = "https://api.github.com/users/" + owner + "/repos";
            // string urlParameters = "?api_key=123";

            /*
             * Set up the HttpClient
             */
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")
            );
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("GitHubConsumerApp", "1.0"));
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", Configuration.GetValue<string>("GitHubToken"));

            /*
             * Call the API, and process the response.
             */
            HttpResponseMessage response = client.GetAsync(URL).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // ...but we also get the string for debugging
                var simpleData = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(simpleData);

                // Parse the response -- we want the JSON
                data = response.Content.ReadFromJsonAsync<IEnumerable<GitHubRepo>>().Result;
            }
            else
            {
                // Print the unsuccessful response code.
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return data;
        }

        [HttpGet]
        public void RepoWorkflows()
        {
            string API_BASE = "https://api.github.com";
            string owner = "meddlin";
            string repo = "amortize-client";
            string URL = API_BASE + "/repos/" + owner + "/" + repo + "/actions/workflows";
            /*
             * Set up the HttpClient
             */
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")
            );
            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("GitHubConsumerApp", "1.0"));
            client.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", Configuration.GetValue<string>("GitHubToken"));


            IEnumerable<GitHubActionsWorkflow> data = new List<GitHubActionsWorkflow>();
            /*
             * Call the API, and process the response.
             */
            HttpResponseMessage response = client.GetAsync(URL).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // ...but we also get the string for debugging
                var simpleData = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(simpleData);

                // Parse the response -- we want the JSON
                data = response.Content.ReadFromJsonAsync<IEnumerable<GitHubActionsWorkflow>>().Result;
            }
            else
            {
                // Print the unsuccessful response code.
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }
    }
}
