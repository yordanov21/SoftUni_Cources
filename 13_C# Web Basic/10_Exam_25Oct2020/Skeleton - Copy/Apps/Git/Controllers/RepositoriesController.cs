namespace Git.Controllers
{
    using Git.Services;
    using Git.ViewModels.Repositories;
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class RepositoriesController : Controller
    {
        private readonly IRepositoriesService repositoriesService;

        public RepositoriesController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }

        public HttpResponse All()
        {

            var repositories = this.repositoriesService.GetAll();
            return this.View(repositories);
        }


        public HttpResponse Create() 
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateRepositoryInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(input.Name) || input.Name.Length < 3 || input.Name.Length>10)
            {
                return this.Error("Invalid Name. Name should be between 3 and 10 characters");
            }

            this.repositoriesService.Create(input);
            return this.Redirect("/Repositories/All");
        }
    }
}
