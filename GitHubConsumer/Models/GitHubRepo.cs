namespace GitHubConsumer.Models
{
    public class GitHubRepo
    {
        public int Id { get; set; }
        public string? Node_Id { get; set; }
        public string? Name { get; set; }
        public string? Full_Name { get; set; }
        public bool Private { get; set; }
        public GitHubRepoOwner Owner { get; set; }
        public string? Html_Url { get; set; }
        public string? Description { get; set; }
        public bool Fork { get; set; }
        public string? Url { get; set; }

        /* Various URLs go here */

        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public DateTime Pushed_At { get; set; }
        public string? Git_Url { get; set; }
        public string? Ssh_Url { get; set; }
        public string? Clone_Url { get; set; }
        public string? Svn_Url { get; set; }
        public string? Homepage { get; set; }
        public int Size { get; set; }
        public int Stargazers_Count { get; set; }
        public int Watchers_Count { get; set; }
        public string? Language { get; set; }
        public bool Has_Issues { get; set; }
        public bool Has_Projects { get; set; }
        public bool Has_Downloads { get; set; }
        public bool Has_Wiki { get; set; }
        public bool Has_Pages { get; set; }
        public bool Has_Discussions { get; set; }
        public int Forks_Count { get; set; }
        public string? Mirror_Url { get; set; }
        public bool Archived { get; set; }
        public bool Disabled { get; set; }
        public int Open_Issues_Count { get; set; }
        public GitHubRepoLicense License { get; set; }
        public bool Allow_Forking { get; set; }
        public bool Is_Template { get; set; }
        public bool Web_Commit_Signoff_Required { get; set; }
        public string[]? Topics { get; set; }
        public string? Visibility { get; set; }
        public int Forks { get; set; }
        public int Open_Issues { get; set; }
        public int Watchers { get; set; }
        public string? Default_Branch { get; set; }
        public GitHubRepoPermissions Permissions { get; set; }
    }

    public class GitHubRepoOwner
    {
        public string? Login { get; set; }
        public int Id { get; set; }
        public string? Node_Id { get; set; }
        public string? Avatar_Url { get; set; }
        public string? Gravatar_Id { get; set; }
        public string? Url { get; set; }
        public string? Html_Url { get; set; }
        public string? Followers_Url { get; set; }
        public string? Following_Url { get; set; }
        public string? Gists_Url { get; set; }
        public string? Starred_Url { get; set; }
        public string? Subscriptions_Url { get; set; }
        public string? Organizations_Url { get; set; }
        public string? Repos_Url { get; set; }
        public string? Events_Url { get; set; }
        public string? Received_Events_Url { get; set; }
        public string? Type { get; set; }
        public bool Site_Admin { get; set; }
    }

    public class GitHubRepoLicense
    {
        public string? Key { get; set; }
        public string? Name { get; set; }
        public string? Spdx_Id { get; set; }
        public string? Url { get; set; }
        public string? Node_Id { get; set; }
    }

    public class GitHubRepoPermissions
    {
        public bool Admin { get; set; }
        public bool Maintain { get; set; }
        public bool Push { get; set; }
        public bool Triage { get; set; }
        public bool Pull { get; set; }
    }
}