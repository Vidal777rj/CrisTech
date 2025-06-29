using _4_WebAPI.Data;
using _4_WebAPI.DTOs.Login;
using _4_WebAPI.DTOs.Usuario;
using _4_WebAPI.Models;
using _4_WebAPI.Services.Senha;
using Microsoft.EntityFrameworkCore;

namespace _4_WebAPI.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly AppDbContext _context;
        private readonly ISenhaInterface _senhaInterface;
        public UsuarioService(AppDbContext context, ISenhaInterface senhaInterface)
        {
            _context = context;
            _senhaInterface = senhaInterface;
        }

        public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioCriacaoDTO usuarioCriacaoDTO)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();
            try
            {
                if (!VerificaSeExisteEmailUsuarioRepetidos(usuarioCriacaoDTO))
                {
                    response.Mensagem = "Email ou Usuário já cadastrado!";
                    response.Status = false;
                    return response;
                }
                _senhaInterface.CriarSenhaHash(usuarioCriacaoDTO.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                UsuarioModel usuario = new UsuarioModel()
                {
                    Usuario = usuarioCriacaoDTO.Usuario,
                    Email = usuarioCriacaoDTO.Email,
                    Nome = usuarioCriacaoDTO.Nome,
                    Sobrenome = usuarioCriacaoDTO.Sobrenome,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt,
                };
                _context.Add(usuario);
                await _context.SaveChangesAsync();

                response.Mensagem = "Usuário cadastrado com sucesso!";
                response.Dados = usuario;
                return response;
            }
            catch (Exception ex) 
            { 
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        private bool VerificaSeExisteEmailUsuarioRepetidos(UsuarioCriacaoDTO usuarioCriacaoDTO)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == usuarioCriacaoDTO.Email 
                                                             || u.Usuario == usuarioCriacaoDTO.Usuario);
            {
                if(usuario != null)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            ResponseModel<List<UsuarioModel>> response = new ResponseModel<List<UsuarioModel>>();

            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();
                response.Dados = usuarios;
                response.Mensagem = "Usuários localizados";
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> ListarUsuarioPorId(int id)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);   
                if(usuario == null)
                {
                    response.Mensagem = "Usuário não localizado";
                    return response;
                }

                response.Dados = usuario;
                response.Mensagem = $"Usuário encontrado";
                response.Status = true;
                return response;
            }catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> EditarUsuario(UsuarioEdicaoDTO usuarioEdicaoDTO)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();
            try
            {
                var usuarioBanco = await _context.Usuarios.FindAsync(usuarioEdicaoDTO.Id);
                if(usuarioBanco == null)
                {
                    response.Mensagem = "Usuário não encontrado";
                    return response;
                }
                usuarioBanco.Nome = usuarioEdicaoDTO.Nome;
                usuarioBanco.Sobrenome = usuarioEdicaoDTO.Sobrenome;
                usuarioBanco.Email = usuarioEdicaoDTO.Email;
                usuarioBanco.Usuario = usuarioEdicaoDTO.Usuario;
                usuarioBanco.DataAlteracao = DateTime.Now;
                _context.Update(usuarioBanco);
                await _context.SaveChangesAsync();
                response.Mensagem = "Usuário atualizado com sucesso!";
                response.Dados = usuarioBanco;
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<UsuarioModel>> RemoverUsuario(int id)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if(usuario == null)
                {
                    response.Mensagem = "Usuário não encontrado";
                    return response;
                }
                response.Dados = usuario;
                response.Mensagem = "Usuário deletado com sucesso!";
                _context.Remove(usuario);
                await _context.SaveChangesAsync();
                return response;

            }catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }

        }

        public async Task<ResponseModel<UsuarioModel>> Login(UsuarioLoginDTO usuarioLoginDTO)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();
            try
            {
                var usuario = await _context.Usuarios.FirstOrDefaultAsync(userBanco => userBanco.Email == usuarioLoginDTO.Email);
                if(usuario == null)
                {
                    response.Mensagem = "Usuário não encontrado";
                    response.Status = false;
                    return response;
                }
                if(!_senhaInterface.VerificaSenhaHash(usuarioLoginDTO.Senha, usuario.SenhaHash, usuario.SenhaSalt))
                {
                    response.Mensagem = "Credenciais inválidas!";
                    response.Status = false;
                    return response;
                }
                var token = _senhaInterface.CriarToken(usuario);
                usuario.Token = token;
                _context.Update(usuario);
                await _context.SaveChangesAsync();

                response.Dados = usuario;
                response.Mensagem = "Usuário logado com sucesso";
                return response;

            }catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}