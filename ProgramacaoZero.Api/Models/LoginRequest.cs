﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramacaoZero.Api.Models
{
    public class LoginRequest
    {
        public string email { get; set; }

        public string senha { get; set; }
    }
}
