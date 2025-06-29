namespace _4_WebAPI.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public string? Token { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;
        public byte[]? SenhaHash { get; set; }
        public byte[]? SenhaSalt { get; set; }
    }
}