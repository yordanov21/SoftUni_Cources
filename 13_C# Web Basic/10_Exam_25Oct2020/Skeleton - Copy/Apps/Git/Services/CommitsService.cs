namespace Git.Services
{
    using Git.Data;
    using Git.ViewModels.Commits;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(CreateCommitInputModel commit)
        {
            var dbCommit = new Commit
            {
               Description = commit.Description,
               CreatedOn = DateTime.Now,
  
            };

            this.db.Commits.Add(dbCommit);
            this.db.SaveChanges();
        }

        public IEnumerable<CommitViewModel> GetAll()
        {
            var commits = this.db.Commits.Select(x => new CommitViewModel
            {
                Repository = x.Repository.Name,
                Description = x.Description,
                CreatedOn = x.CreatedOn

            }).ToList();

            return commits;
        }
    }
}
