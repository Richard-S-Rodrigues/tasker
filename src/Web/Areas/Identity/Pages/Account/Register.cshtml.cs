using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
 
namespace Tasker.Areas.Web.Identity.Pages.Account;

[AllowAnonymous]
public class RegisterModel : PageModel
{
  private readonly SignInManager<IdentityUser> _signInManager;
  private readonly UserManager<IdentityUser> _userManager;
  private readonly ILogger<RegisterModel> _logger;

  public RegisterModel(
      UserManager<IdentityUser> userManager,
      SignInManager<IdentityUser> signInManager,
      ILogger<RegisterModel> logger)
  {
      _userManager = userManager;
      _signInManager = signInManager;
      _logger = logger;
  }

  [BindProperty]
  public InputModel Input { get; set; }

  public string? ReturnUrl { get; set; }

  public IList<AuthenticationScheme> ExternalLogins { get; set; }

  public class InputModel
  {
      [Required]
      [EmailAddress]
      [Display(Name = "Email")]
      public string Email { get; set; }

      [Required]
      [DataType(DataType.Password)]
      [Display(Name = "Senha")]
      public string Password { get; set; }

      [DataType(DataType.Password)]
      [Display(Name = "Confirmar senha")]
      [Compare("Password", ErrorMessage = "As senhas não estão iguais.")]
      public string ConfirmPassword { get; set; }
  }

  public async Task OnGetAsync(string returnUrl = null)
  {
      ReturnUrl = returnUrl;
  }

  public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
  {
      returnUrl ??= Url.Content("~/boards");
      if (ModelState.IsValid)
      {
          var user = new IdentityUser { UserName = Input.Email, Email = Input.Email };
          var result = await _userManager.CreateAsync(user, Input.Password);
          if (result.Succeeded)
          {
              _logger.LogInformation("User created a new account with password.");

              await _signInManager.SignInAsync(user, isPersistent: false);
              return LocalRedirect(returnUrl);
          }
          foreach (var error in result.Errors)
          {
              ModelState.AddModelError(string.Empty, error.Description);
          }
      }

      return Page();
  }
}