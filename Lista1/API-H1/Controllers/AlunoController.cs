using API_H1.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace API_H1.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AlunoController : Controller
    {
        private readonly string _alunoCaminhoArquivo;


        public AlunoController()
        {
            _alunoCaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "alunos.json") ;
        }

        #region Métodos arquivo

        private List<AlunoViewModel> LerAlunosdoArquivo()
        {
            if (!System.IO.File.Exists(_alunoCaminhoArquivo))
            {
                return new List<AlunoViewModel>();
            }

            string json = System.IO.File.ReadAllText(_alunoCaminhoArquivo);
            return JsonConvert.DeserializeObject<List<AlunoViewModel>>(json);
        }

        private void RegistrarAlunosNoArquivo(List<AlunoViewModel> alunos)
        {
            string json = JsonConvert.SerializeObject(alunos);
            System.IO.File.WriteAllText(_alunoCaminhoArquivo, json);
        }
        #endregion

        #region Operações Crud

        [HttpGet]
        public IActionResult Get()
        {
            List<AlunoViewModel> alunos = LerAlunosdoArquivo();
            return Ok(alunos);
        }

        [HttpPost]
        public IActionResult Post([FromBody]AlunoViewModel aluno)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (aluno == null)
            {
                return BadRequest();
            }

            List<AlunoViewModel> alunos = LerAlunosdoArquivo();

            AlunoViewModel novoAluno = new AlunoViewModel()
            {
                Nome = aluno.Nome,
                Email = aluno.Email,
                CPF = aluno.CPF,
                RA = aluno.RA,
                Ativo = true
            };

            alunos.Add(novoAluno);
            RegistrarAlunosNoArquivo(alunos);

            return Ok(alunos);
        }

        [HttpPut]

        public IActionResult Put([FromBody]EditaAlunoViewModel aluno) 
        {
            List<AlunoViewModel> alunos = LerAlunosdoArquivo();

            AlunoViewModel alunoEditado = new AlunoViewModel()
            {
                Nome = aluno.Nome,
                Email = aluno.Email,
                Ativo= aluno.Ativo
            };

            RegistrarAlunosNoArquivo(alunos);

            return NoContent();
        }

        [HttpDelete]

        public IActionResult Delete(AlunoViewModel  aluno)
        {
            List<AlunoViewModel> alunos = LerAlunosdoArquivo();
            if (aluno.Ativo == false)
            {
                return BadRequest("O aluno ja foi desligado");
            }

            alunos.Remove(aluno);
            RegistrarAlunosNoArquivo(alunos);

            return NoContent();
        }

        #endregion
    }
}
