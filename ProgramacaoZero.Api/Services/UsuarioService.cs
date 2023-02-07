using Microsoft.Extensions.Configuration;
using ProgramacaoZero.Api.Common;
using ProgramacaoZero.Api.Entities;
using ProgramacaoZero.Api.Models;
using ProgramacaoZero.Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramacaoZero.Api.Services
{
    public class UsuarioService
    {
        private string _connectionString;

        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioExistente = new UsuarioRepository(_connectionString).ObterPorEmail(email);

            if (usuarioExistente != null)
            {
                if (usuarioExistente.Senha == senha)
                {
                    //faz login
                    result.sucesso = true;
                    result.usuarioGuid = usuarioExistente.UsuarioGuid;
                }
                else
                {
                    result.sucesso = false;
                    result.mensagem = "Usuário ou senha inválidos";
                }
            }
            else
            {
                result.sucesso = false;
                result.mensagem = "Usuário ou senha inválidos";
            }

            return result;
        }

        public CadastroResult Cadastro(string nome, string sobrenome, string email, string senha, string telefone, string genero)
        {
            var result = new CadastroResult();

            var repositorio = new UsuarioRepository(_connectionString);

            var usuario = repositorio.ObterPorEmail(email);
            
            if (usuario != null)
            {
                result.sucesso = false;
                result.mensagem = "Usuário já existe";
            }
            else
            {
                usuario = new Usuario();

                usuario.Email = email;
                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Telefone = telefone;
                usuario.Senha = senha;
                usuario.Genero = genero;
                usuario.UsuarioGuid = Guid.NewGuid();

                var affectedRows = repositorio.Inserir(usuario);

                if (affectedRows > 0)
                {
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    result.sucesso = false;
                    result.mensagem = "Não foi possível inserir o usuário";
                }
            }

            return result;
        }

        public EsqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new EsqueceuSenhaResult();

            var usuario = new UsuarioRepository(_connectionString).ObterPorEmail(email);

            if (usuario == null)
            {
                result.mensagem = "Usuário não existe";
            }
            else
            {
                var assunto = "Programação do Zero - Recuperação de Senha";

                var corpo = "Sua senha de acesso é: " + usuario.Senha;

                var emailSender = new EmailSender();
                    
                emailSender.Enviar(assunto, corpo, usuario.Email);

                result.sucesso = true;
            }

            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }
    }
}
