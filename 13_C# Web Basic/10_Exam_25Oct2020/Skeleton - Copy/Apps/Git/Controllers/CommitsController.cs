namespace Git.Controllers
{
    using Git.Services;
    using Git.ViewModels.Commits;
    using SUS.HTTP;
    using SUS.MvcFramework;

    class CommitsController : Controller
    {
        private readonly ICommitsService commitsService;

        public CommitsController(ICommitsService commitsService)
        {
            this.commitsService = commitsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var commits = this.commitsService.GetAll();
            return this.View(commits);
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
        public HttpResponse Create(CreateCommitInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(input.Description) || input.Description.Length < 5 )
            {
                return this.Error("Invalid Description. Description should be between most than 5 characters");
            }

            this.commitsService.Create(input);
            return this.Redirect("/Repositories/All");
        }
    }
}
