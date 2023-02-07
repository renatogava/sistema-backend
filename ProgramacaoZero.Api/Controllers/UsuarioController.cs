using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ProgramacaoZero.Api.Models;
using ProgramacaoZero.Api.Services;
using System;

namespace ProgramacaoZero.Api.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IConfiguration _configuration;

        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginRequest request)
        {
            var result = new LoginResult();

            if (request == null || 
                string.IsNullOrEmpty(request.email) || 
                string.IsNullOrEmpty(request.senha))
            {
                result.mensagem = "Email ou senha inválidos";

                return Ok(result);
            }

            var connectionString = _configuration.GetConnectionString("programacao_do_zero_db");

            result = new UsuarioService(connectionString).Login(request.email, request.senha);

            return Ok(result);
        }

        [HttpPost]
        [Route("cadastro")]
        public IActionResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if (request == null ||
                string.IsNullOrEmpty(request.nome) ||
                string.IsNullOrEmpty(request.sobrenome) ||
                string.IsNullOrEmpty(request.telefone) ||
                string.IsNullOrEmpty(request.genero) ||
                string.IsNullOrEmpty(request.email) ||
                string.IsNullOrEmpty(request.senha))
            {
                result.mensagem = "Todos os campos são obrigatórios";

                return Ok(result);
            }

            var connectionString = _configuration.GetConnectionString("programacao_do_zero_db");

            result = new UsuarioService(connectionString).Cadastro(
                request.nome, 
                request.sobrenome, 
                request.email, 
                request.senha, 
                request.telefone, 
                request.genero);

            return Ok(result);
        }

        [HttpPost]
        [Route("esqueceuSenha")]
        public EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
        {
            var result = new EsqueceuSenhaResult();

            if (request == null ||
                string.IsNullOrEmpty(request.email))
            {
                result.mensagem = "Email obrigatório";

                return result;
            }

            var connectionString = _configuration.GetConnectionString("programacao_do_zero_db");

            result = new UsuarioService(connectionString).EsqueceuSenha(request.email);

            return result;
        }

        [HttpGet]
        [Route("obterUsuario")]
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if (usuarioGuid == null)
            {
                result.mensagem = "Usuário Guid vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacao_do_zero_db");

                var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);

                if (usuario == null)
                {
                    result.mensagem = "Usuário não existe";
                }
                else
                {
                    result.sucesso = true;
                    result.nome = usuario.Nome;
                }
            }

            return result;
        }
    }
}
