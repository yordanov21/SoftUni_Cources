namespace Git.ViewModels.Commits
{
    using System;

    public class CommitViewModel
    {
        public string Id { get; set; }
        public string Repository { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

    }
}
