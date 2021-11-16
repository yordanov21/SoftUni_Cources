namespace Git.Services
{
    using Git.ViewModels.Repositories;
    using System.Collections.Generic;

    public interface IRepositoriesService
    {
        void Create(CreateRepositoryInputModel repository);

        IEnumerable<RepositotyViewModel> GetAll();
    }
}
