using GitHubConsumer.Models;
using GitHubConsumer.Utilities;
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
        public IEnumerable<GitHubRepo> GetRepos()
        {
            string owner = "meddlin";
            List<GitHubRepo> data = GitHubRestClient.GetRepos(owner, Configuration.GetValue<string>("GitHubToken")).ToList();

            return data;
        }

        [HttpGet]
        public GitHubActionsWorkflowResponse RepoWorkflows()
        {
            string owner = "meddlin";
            string repo = "amortize-client";
            GitHubActionsWorkflowResponse data = GitHubRestClient.GetRepoWorkflows(owner, repo, Configuration.GetValue<string>("GitHubToken"));
            return data;
        }
    }
}
