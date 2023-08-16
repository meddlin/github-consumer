using GitHubConsumer.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

namespace GitHubConsumer.Utilities
{
    public class GitHubRestClient
    {
        private HttpClient _httpClient;
        private const string API_BASE = "https://api.github.com";

        /// <summary>
        /// Creates a new HttpClient with the required headers for GitHub API calls
        /// </summary>
        /// <param name="authToken"></param>
        private GitHubRestClient(string authToken)
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json")
            );
            _httpClient.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("GitHubConsumerApp", "1.0"));
            _httpClient.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", authToken);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public static IEnumerable<GitHubRepo> GetRepos(string owner, string authToken)
        {
            var ghr = new GitHubRestClient(authToken);

            IEnumerable<GitHubRepo> data = new List<GitHubRepo>();

            // string URL = "https://api.github.com/users/" + owner + "/repos";
            var response = ghr._httpClient.GetAsync($"{API_BASE}/users/{owner}/repos").Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadFromJsonAsync<IEnumerable<GitHubRepo>>().Result;
            } else
            {
                // Print the unsuccessful response code.
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="repo"></param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public static GitHubActionsWorkflowResponse GetRepoWorkflows(string owner, string repo, string authToken)
        {
            var ghr = new GitHubRestClient(authToken);
            GitHubActionsWorkflowResponse data = new GitHubActionsWorkflowResponse();

            var response = ghr._httpClient.GetAsync($"{API_BASE}/repos/{owner}/{repo}/actions/workflows").Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadFromJsonAsync<GitHubActionsWorkflowResponse>().Result;
            }
            else
            {
                // Print the unsuccessful response code.
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }

            return data;
        }
    }
}
