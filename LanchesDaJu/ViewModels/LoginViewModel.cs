using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LanchesDaJu.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o usuário")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Informe a senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }        
        public string ReturnUrl { get; set; }   
    }
}
