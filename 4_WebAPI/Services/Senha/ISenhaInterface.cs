using _4_WebAPI.Models;

namespace _4_WebAPI.Services.Senha
{
    public interface ISenhaInterface
    {
        void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt);
        bool VerificaSenhaHash(string senha,  byte[] senhaHash, byte[] senhaSalt);
        string CriarToken(UsuarioModel usuario);
    }
}
