using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Revisão_1.Models.Request;
using Revisão_1.Models.Validations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace Revisão_1.Controllers
{
    [ApiController]
    [Route("Controller")]
    public class MegaSenaController : ControllerBase
    {
        private readonly string _megaSenaCaminhoDoArquivo;

        public MegaSenaController()
        {
            _megaSenaCaminhoDoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "MegaSena.Json");
        }

        private List<RegistrarJogoViewModel> LerJogosDoArquivo()
        { 
            if(!System.IO.File.Exists(_megaSenaCaminhoDoArquivo))
            {
                return new List<RegistrarJogoViewModel>();
            }

            string json = System.IO.File.ReadAllText(_megaSenaCaminhoDoArquivo);
            return JsonConvert.DeserializeObject<List<RegistrarJogoViewModel>>(json);
        }

        private void EscreverNoArquivo (List<RegistrarJogoViewModel> jogos) 
        {
            string json = JsonConvert.SerializeObject(jogos);
            System.IO.File.WriteAllText(_megaSenaCaminhoDoArquivo, json);
        }

        [HttpPost]
        public IActionResult Post(RegistrarJogoViewModel registrarJogoViewModel)
        {

            if (registrarJogoViewModel == null)
            {
                return BadRequest();
            }

            var jogosRealizados = LerJogosDoArquivo();

            registrarJogoViewModel.DataJogo = DateTime.Now;

            jogosRealizados.Add(registrarJogoViewModel);
            
            EscreverNoArquivo(jogosRealizados);
            
            return Ok("Seu cadastro na Mega Sena foi registrado com Sucesso");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(LerJogosDoArquivo());
        }
        
    }
}
