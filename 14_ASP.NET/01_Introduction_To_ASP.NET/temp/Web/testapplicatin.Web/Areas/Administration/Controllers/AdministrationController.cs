namespace testapplicatin.Web.Areas.Administration.Controllers
{
    using testapplicatin.Common;
    using testapplicatin.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.AdministratorRoleName)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
