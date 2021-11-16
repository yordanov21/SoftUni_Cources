namespace Git.Services
{
    using Git.Data;
    using Git.ViewModels.Repositories;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void Create(CreateRepositoryInputModel repository)
        {
            var dbRepository = new Repository
            {
                Name = repository.Name,
                CreatedOn = DateTime.Now,
                IsPublic = repository.RepositoryType == "Public" ? true : false,             
            };

            this.db.Repositories.Add(dbRepository);
            this.db.SaveChanges();
        }

        public IEnumerable<RepositotyViewModel> GetAll()
        {
            var repositories =  this.db.Repositories.Select(x => new RepositotyViewModel
            {
                Name = x.Name,
                Owner = x.Owner.Username,
                CreatedOn = x.CreatedOn,
                CommitsCount = x.Commits.Count,
            }).ToList();

            return repositories;
        }
    }
}
