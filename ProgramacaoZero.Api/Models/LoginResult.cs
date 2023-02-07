using System;

namespace ProgramacaoZero.Api.Models
{
    public class LoginResult : BaseResult
    {
        public Guid usuarioGuid { get; set; }
    }
}