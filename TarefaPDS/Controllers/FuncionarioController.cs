using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarefaPDS.Dtos;
using TarefaPDS.Models;

namespace TarefaPDS.Controllers
{
    [Route("funcionario")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        List<Funcionario> listaFuncionarios = new List<Funcionario>();

        public FuncionarioController()
        {
            var funcionario1 = new Funcionario()
            {
                Nome = "Adão"
            };

            var funcionario2 = new Funcionario()
            {
                Nome = "Eva"
            };

            listaFuncionarios.Add(funcionario1);
            listaFuncionarios.Add(funcionario2);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(listaFuncionarios);
        }

        [HttpGet("{Nome}")]

        public IActionResult GetById(string Nome)
        {

            var funcionario = listaFuncionarios.Where(Funcionario => Funcionario.Nome == Nome).FirstOrDefault();

            if (Nome == null)
            {
                return NotFound();
            }

            return Ok(Nome);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Funcionario item)
        {
            var funcionario = new Funcionario();

            funcionario.Nome = item.Nome;
            funcionario.CPF = item.CPF;
            funcionario.Funcao = item.Funcao;

            listaFuncionarios.Add(funcionario);

            return StatusCode(StatusCodes.Status201Created, funcionario);
        }

        [HttpPut("{Nome}")]

        public IActionResult Put(int Nome, [FromBody] FuncionarioDTO item)
        {
            var funcionario = listaFuncionarios.Where(item => item.Nome == Nome).FirstOrDefault();

            if (funcionario == null)
            {
                return NotFound();
            }

            funcionario.Descricao = item.Descricao;

            return Ok(listaFuncionarios);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var funcionario = listaFuncionarios.Where(item => item.Id == id).FirstOrDefault();

            if (funcionario == null)
            {
                return NotFound();
            }

            listaFuncionarios.Remove(funcionario);

            return Ok(funcionario);
        }
    }
}
