using System.ComponentModel.DataAnnotations;

namespace Pronia.ViewModel.Auths
{
    public class ForgotPasswordVM
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
