namespace GitHubConsumer.Models
{
    public class GitHubActionsWorkflowResponse
    {
        public int total_count { get; set; }
        public List<GitHubActionsWorkflow> workflows { get; set; }
    }

    public class GitHubActionsWorkflow
    {
        public int Id { get; set; }
        public string? Node_Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? State { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public string? Url { get; set; }
        public string? Html_Url { get; set; }
        public string? Badge_Url { get; set; }
    }
}
