using _4_WebAPI.Data;
using _4_WebAPI.DTOs.Login;
using _4_WebAPI.DTOs.Usuario;
using _4_WebAPI.Models;

namespace _4_WebAPI.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioCriacaoDTO usuarioCriacaoDTO);
        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();
        Task<ResponseModel<UsuarioModel>> ListarUsuarioPorId(int id);
        Task<ResponseModel<UsuarioModel>> EditarUsuario(UsuarioEdicaoDTO usuarioEdicaoDTO);
        Task<ResponseModel<UsuarioModel>> RemoverUsuario(int id);
        Task<ResponseModel<UsuarioModel>> Login(UsuarioLoginDTO usuarioLoginDTO);
    }
}