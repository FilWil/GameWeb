using System.ComponentModel.DataAnnotations;

namespace GameWeb.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required] [EmailAddress] public string Email { get; set; }
    }
}