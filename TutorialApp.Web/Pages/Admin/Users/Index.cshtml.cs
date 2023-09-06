using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TutorialApp.Core.DTOs;
using TutorialApp.Core.Services.Interfaces;

namespace TutorialApp.Web.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        IUserService _userService;
        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public UsersForAdminViewModel usForAdminViewModel { get; set; }
        public void OnGet(int pageId = 1, string filterEmail = "", string filterUsername = "")
        {
            usForAdminViewModel = _userService.GetUsers(pageId, filterEmail, filterUsername);
        }
    }
}
