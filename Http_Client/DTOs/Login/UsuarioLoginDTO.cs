using System.ComponentModel.DataAnnotations;

namespace Http_Client.DTOs.Login
{
    public class UsuarioLoginDTO
    {
        [Required(ErrorMessage = "Digite o e-mail")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Digite a senha")]
        public string? Senha { get; set; }

    }
}
