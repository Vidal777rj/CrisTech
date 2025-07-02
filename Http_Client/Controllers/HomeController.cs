using Http_Client.DTOs.Login;
using Http_Client.DTOs.Usuario;
using Http_Client.Models;
using Http_Client.Service.Sessao;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Http_Client.Controllers
{
    public class HomeController : Controller
    {
        Uri baseUrl = new Uri("https://localhost:7223/api");
        private readonly HttpClient _httpClient;
        private readonly ISessaoInterface _sessaoInterface;
        public HomeController(HttpClient httpClient, ISessaoInterface sessaoInterface)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = baseUrl;
            _sessaoInterface = sessaoInterface;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registrar() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuarioLoginDTO usuarioLoginDTO)
        {
            if (ModelState.IsValid)
            {
                ResponseModel<UsuarioModel> usuario = new ResponseModel<UsuarioModel>();
                var httpContent = new StringContent(JsonConvert.SerializeObject(usuarioLoginDTO), Encoding.UTF8, "application/json");
               _httpClient.BaseAddress = baseUrl;
                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "login/register", httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    usuario = JsonConvert.DeserializeObject<ResponseModel<UsuarioModel>>(data);
                }
                if(usuario.Status == false)
                {
                    TempData["MensagemErro"] = "Credenciais Inválidas";
                    return View(usuarioLoginDTO);
                }
                _sessaoInterface.CriarSessao(usuario.Dados);
                TempData["MensagemSucesso"] = "Usuário logado!";
                return RedirectToAction("ListarUsuarios");
            }
            else
            {
                return View(usuarioLoginDTO);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(UsuarioCriacaoDTO usuarioCriacaoDTO)
        {
            if (ModelState.IsValid)
            {
                ResponseModel<UsuarioModel> usuario = new ResponseModel<UsuarioModel>();
                var httpContent = new StringContent(JsonConvert.SerializeObject(usuarioCriacaoDTO), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress + "/login/register", httpContent);
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    usuario = JsonConvert.DeserializeObject<ResponseModel<UsuarioModel>>(data);    
                }
                if(usuario.Status == false)
                {
                    TempData["MensagemErro"] = "Crendiciais Inválidas";
                    return View(usuarioCriacaoDTO);
                }
                TempData["MensagemSucesso"] = usuario.Mensagem;
                return RedirectToAction("Login");
            }
            else
            {
                return View(usuarioCriacaoDTO);
            }
        }

        [HttpGet]
        public IActionResult ListarUsuarios()
        {
            return View();
        }
    }
}
