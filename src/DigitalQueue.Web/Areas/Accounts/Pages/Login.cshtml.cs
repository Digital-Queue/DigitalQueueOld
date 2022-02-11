using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

using DigitalQueue.Web.Areas.Accounts.Services;
using DigitalQueue.Web.Data;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalQueue.Web.Areas.Accounts.Pages;

public class LoginModel : PageModel
{
    private readonly ILogger<LoginModel> _logger;
    private readonly UsersService _usersService;

    public LoginModel(ILogger<LoginModel> logger, UsersService usersService)
    {
        _logger = logger;
        _usersService = usersService;
    }

    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [BindProperty]
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [BindProperty]
    public bool RememberMe { get; set; }

    public IActionResult OnGet()
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToPage("Index", new { area = "Dashboard" });
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var claims = await _usersService.GetUserClaims(Email, Password);
        if (claims is null)
        {
            ModelState.AddModelError("invalid_credentials", "Invalid credentials.");
            return Page();
        }

        /*
         * Allow only administrator role to log-in to dashboard
         */
        if (claims.FirstOrDefault(c => c.Type == ClaimTypes.Role && c.Value != RoleDefaults.Administrator) is not null)
        {
            ModelState.AddModelError("access_denied", "Access denied.");
            return Page();
        }
        
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
            new AuthenticationProperties()
            {
                IsPersistent = RememberMe,
            });

        return RedirectToPage("Index", new { area = "Dashboard" });
    }

}
