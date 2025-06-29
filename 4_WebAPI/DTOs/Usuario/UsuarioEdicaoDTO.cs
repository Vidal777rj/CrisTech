using System.ComponentModel.DataAnnotations;

namespace _4_WebAPI.DTOs.Usuario
{
    public class UsuarioEdicaoDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o usuário")]
        public string? Usuario { get; set; }

        [Required(ErrorMessage = "Digite o nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Digite o sobrenome")]
        public string? Sobrenome { get; set; }

        [Required(ErrorMessage = "Digite o E-mail")]
        public string? Email { get; set; }
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
    }
}
