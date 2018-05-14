using System.ComponentModel.DataAnnotations;

namespace GameWeb.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required] [EmailAddress] public string Email { get; set; }
    }
}