using course.web.mvc.Models.Usuario;
using course.web.mvc.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



namespace course.web.mvc.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        
        
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(RegistrarUsuarioViewModelInput registrarUsuarioViewModelInput)
        {
            try
            {
                var usuario = await _usuarioService.Registrar(registrarUsuarioViewModelInput);
                ModelState.AddModelError("", $"Os dados foram cadastrados com sucesso para o login {usuario.Login}");
            }

            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);

            }


            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }


            /*
                   var clientHandler = new HttpClientHandler();
                   clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }; //ignora erros de politica usado somente para desenvolvimento e testes

                   var httpClient = new HttpClient();
                   httpClient.BaseAddress = new Uri("https://localhost:5001/");

                   var registrarUsuarioViewModelInputJson = JsonConvert.SerializeObject(registrarUsuarioViewModelInput); //converte pra json

                   var httpContent = new StringContent(registrarUsuarioViewModelInputJson, Encoding.UTF8,"application/json");

                   var httpPost = httpClient.PostAsync("/api/v1/usuario/registrar", httpContent).GetAwaiter().GetResult();

                   if(httpPost.StatusCode == System.Net.HttpStatusCode.Created)
                   {

                       ModelState.AddModelError("", "Os dados foram cadastrados com sucesso");
                   }
                   else
                   {
                       ModelState.AddModelError("", "Erro ao cadastrar");
                   }

                   */


        }

        public IActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logar(LoginViewModelInput loginViewModelInput)
        {


            try
            {
                var usuario = await _usuarioService.Logar(loginViewModelInput);

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, usuario.Usuario.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Usuario.Login),
                    new Claim(ClaimTypes.Email, usuario.Usuario.Email),
                    new Claim("token", usuario.Token),
                };

                var claimsIdentify = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = new DateTimeOffset(DateTime.UtcNow.AddDays(1))
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal());

                ModelState.AddModelError("", $"O usuario está autenticado {usuario.Token}");
            }

            catch (ApiException ex)
            {
                ModelState.AddModelError("", ex.Message);

            }


            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);

            }
            return View();
        }


        public IActionResult EfetuarLogoff()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction($"{nameof(Logar)}");
        }


    }
}
