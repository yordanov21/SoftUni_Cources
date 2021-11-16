namespace Git.Services
{
    using Git.ViewModels.Commits;
    using System.Collections.Generic;

    public interface ICommitsService
    {
        void Create(CreateCommitInputModel repository);

        IEnumerable<CommitViewModel> GetAll();
    }
}
