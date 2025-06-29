using _4_WebAPI.Data;
using _4_WebAPI.DTOs.Usuario;
using _4_WebAPI.Services.Usuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace _4_WebAPI.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;
        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }

        [HttpGet, Route("listar")]
        public async Task<IActionResult> ListarUsuarios()
        {
            var usuarios = await _usuarioInterface.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet, Route("listar/{id}")]
        [Authorize]
        public async Task<IActionResult> ListarUsuarioPorId(int id)
        {
            var usuario = await _usuarioInterface.ListarUsuarioPorId(id);
            return Ok(usuario);
        }

        [HttpPut, Route("editar")]
        public async Task<IActionResult> EditarUsuarioPorId(UsuarioEdicaoDTO usuarioEdicaoDTO)
        {
            var usuario = await _usuarioInterface.EditarUsuario(usuarioEdicaoDTO);
            return Ok(usuario);
        }

        [HttpDelete, Route("deletar/{id}")]
        public async Task<IActionResult> RemoverUsuario(int id)
        {
            var usuario = await _usuarioInterface.RemoverUsuario(id);
            return Ok(usuario);
        }
    }
}
