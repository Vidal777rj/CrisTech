using System.ComponentModel.DataAnnotations;

namespace _4_WebAPI.DTOs.Usuario
{
    public class UsuarioCriacaoDTO
    {
        [Required(ErrorMessage = "Digite o usuário")]
        public string? Usuario { get; set; }

        [Required(ErrorMessage = "Digite o nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Digite o sobrenome")]
        public string? Sobrenome { get; set; }

        [Required(ErrorMessage = "Digite o E-mail")]
        public string? Email { get; set; }


        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;


        [Required(ErrorMessage = "Digite a senha")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "Digite a confirmação de senha"), Compare("Senha", ErrorMessage = "Senha não são iguais")]
        public string? ConfirmaSenha { get; set; }
    }
}