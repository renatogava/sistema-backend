using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgramacaoZero.Api.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class OlaMundoPersonalizadoController : ControllerBase
    {
        [HttpGet]
        [Route("olaMundo")]
        public IActionResult OlaMundo()
        {
            var mensagem = "Olá eu sou uma API";

            return Ok(mensagem);
        }

        [HttpGet]
        [Route("olaMundoPersonalizado")]
        public IActionResult OlaMundoPersonalizado(string nome)
        {
            var mensagem = "Olá " + nome + ", eu sou uma API";

            return Ok(mensagem);
        }

        [HttpGet]
        [Route("somar")]
        public IActionResult Somar(int numero1, int numero2)
        {
            var soma = numero1 + numero2;

            return Ok(soma);
        }

        [HttpGet]
        [Route("media")]
        public IActionResult Media(decimal numero1, decimal numero2)
        {
            var media = (numero1 + numero2) / 2;

            var mensagem = "A soma é " + media;

            return Ok(media);
        }

        [HttpGet]
        [Route("terreno")]
        public IActionResult Terreno(decimal largura, decimal comprimento, decimal valorM2)
        {
            var areaTerreno = largura * comprimento;

            var valorTerreno = areaTerreno * valorM2;

            var mensagem = "A área do terreno é de " + areaTerreno + "m2. O valor do terreno é de R$ " + valorTerreno;

            return Ok(mensagem);
        }

        [HttpGet]
        [Route("troco")]
        public IActionResult Troco(decimal precoUnitario, int quantidade, decimal valorPago)
        {
            var precoTotal = precoUnitario * quantidade;

            var troco = valorPago - precoTotal;

            var mensagem = "O troco do cliente é de R$ " + troco;

            return Ok(mensagem);
        }

        [HttpGet]
        [Route("pagamento")]
        public IActionResult Pagamento(string nomeFuncionario, int valorHora, decimal qtdeHorasTrabalhadas)
        {
            var salario = valorHora * qtdeHorasTrabalhadas;

            var mensagem = "O pagamento para " + nomeFuncionario + " deve ser de R$ " + salario;

            return Ok(mensagem);
        }

        [HttpGet]
        [Route("consumo")]
        public IActionResult Consumo(decimal distancia, decimal litros)
        {
            var consumo = distancia / litros;

            var mensagem = "O consumo médio do veículo é de " + consumo + "km por litro";

            return Ok(mensagem);
        }
    }
}
