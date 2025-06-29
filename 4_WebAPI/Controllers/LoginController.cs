using _4_WebAPI.Data;
using _4_WebAPI.DTOs.Login;
using _4_WebAPI.DTOs.Usuario;
using _4_WebAPI.Models;
using _4_WebAPI.Services.Usuario;
using Microsoft.AspNetCore.Mvc;
namespace _4_WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public LoginController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpPost("login/register")]
        public async Task<IActionResult> RegistrarUsuario(UsuarioCriacaoDTO usuarioDTO)
        {
            var usuario = await _usuarioInterface.RegistrarUsuario(usuarioDTO);
            return Ok(usuario);
        }

        [HttpPost,Route("login")]
        public async Task<IActionResult> Login(UsuarioLoginDTO usuarioLoginDTO)
        {
            var usuario = await _usuarioInterface.Login(usuarioLoginDTO);
            return Ok(usuario);
        }
    }
}