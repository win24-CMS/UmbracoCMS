using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Umbraco.Cms.Web.Website.Controllers;
using UmbracoCMS.Services;
using UmbracoCMS.ViewModels;

namespace UmbracoCMS.Controllers;

public class FormController(IUmbracoContextAccessor umbracoContextAccessor, IUmbracoDatabaseFactory databaseFactory, ServiceContext services, AppCaches appCaches, IProfilingLogger profilingLogger, IPublishedUrlProvider publishedUrlProvider, FormSubmissionsService formSubmissions) : SurfaceController(umbracoContextAccessor, databaseFactory, services, appCaches, profilingLogger, publishedUrlProvider)
{
    private readonly FormSubmissionsService _formSubmissions = formSubmissions;

    public IActionResult HandleCallbackForm(CallbackFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }

        var result = _formSubmissions.SaveCallbackRequest(model);
        if (!result)
        {
            TempData["FormError"] = "Something went wrong, please try again later.";

            return RedirectToCurrentUmbracoPage();
        }

        TempData["FormSuccess"] = "Thank you! Your request was successfull. We will get back to you.";

        return RedirectToCurrentUmbracoPage();
    }

    public IActionResult HandleQuestionForm(QuestionFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }

        var result = _formSubmissions.SaveQuestionRequest(model);
        if (!result)
        {
            TempData["QuestionFormError"] = "Something went wrong, please try again later.";

            return RedirectToCurrentUmbracoPage();
        }

        TempData["QuestionFormSuccess"] = "Thank you! Your request was successfull. We will get back to you.";

        return RedirectToCurrentUmbracoPage();
    }

    public IActionResult HandleHelpForm(HelpFormViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return CurrentUmbracoPage();
        }

        var result = _formSubmissions.SaveHelpRequest(model);
        if (!result)
        {
            TempData["HelpFormError"] = "Something went wrong, please try again later.";

            return RedirectToCurrentUmbracoPage();
        }

        TempData["HelpFormSuccess"] = "Thank you! Your request was successfull. We will get back to you.";

        return RedirectToCurrentUmbracoPage();
    }
}
