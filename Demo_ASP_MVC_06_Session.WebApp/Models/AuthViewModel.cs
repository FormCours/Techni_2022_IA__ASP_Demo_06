using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Demo_ASP_MVC_06_Session.WebApp.Models
{
    public class AuthRegisterViewModel
    {
        [DisplayName("E-Mail")]
        [Required(ErrorMessage = "L'e-mail est requis !")]
        [EmailAddress(ErrorMessage = "E-mail invalide ! 🦄")]
        public string Email { get; set; }

        [DisplayName("Pseudo")]
        [Required(ErrorMessage = "Le pseudo est requis !")]
        // [StringLength(50, MinimumLength = 2)]
        [MinLength(2, ErrorMessage = "Le pseudo doit contenir minimum 2 caracteres")]
        [MaxLength(50, ErrorMessage = "Le pseudo doit contenir maximum 50 caracteres")]
        [RegularExpression("^[A-Za-z][A-Za-z0-9]*$", ErrorMessage = "Pas de symbole :o")]
        public string Pseudo { get; set; }

        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le mot de passe est requis !")]
        [MinLength(8, ErrorMessage = "Le mot de passe doit contenir minimum 8 caracteres")]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\\W]).*$", ErrorMessage = "Poisson! 🐠🐟🐡")]
        public string Password { get; set; }

        [DisplayName("Confirmation du mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "La validation du mot de passe est requise !")]
        [Compare(nameof(Password), ErrorMessage = "La confirmation n'est pas valide !")]
        public string ConfirmPassword { get; set; }
    }

    public class AuthLoginViewModel
    {
        [DisplayName("Pseudo / E-mail")]
        [Required(ErrorMessage = "L'identifiant est requis !")]
        public string Idenfifiant { get; set; }

        [DisplayName("Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le mot de passe est requis !")]
        public string Password { get; set; }
    }
}
