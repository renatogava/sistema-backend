using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgramacaoZero.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramacaoZero.Api.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class Aula11Controller : ControllerBase
    {
        [HttpGet]
        [Route("obterCarro")]
        public IActionResult ObterCarro()
        {
            var meuCarro = new Carro();

            meuCarro.Cor = "Preto";
            meuCarro.Marca = "Honda";
            meuCarro.Modelo = "Fit";
            meuCarro.Placa = "CXE-2377";

            meuCarro.Acelerar();

            meuCarro.Frear();

            return Ok(meuCarro);
        }

        [HttpGet]
        [Route("obterMoto")]
        public IActionResult ObterMoto()
        {
            var minhaMoto = new Moto();

            minhaMoto.Cor = "Azul";
            minhaMoto.Marca = "Honda";
            minhaMoto.Modelo = "Fit";
            minhaMoto.Placa = "CXE-2377";

            minhaMoto.Acelerar();

            minhaMoto.Frear();

            return Ok(minhaMoto);
        }
    }
}
