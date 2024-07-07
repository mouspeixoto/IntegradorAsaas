using IntegradorAsaas.Aplicacao.Pessoas;
using IntegradorAsaas.Dominio.Pessoas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace IntegradorAsaas.API.Controllers.Pessoas
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : Controller
    {
        PessoaAplicacao PessoaApp = new PessoaAplicacao();

        [HttpGet]
        public IActionResult ConsultarPessoa()
        {
            var pessoas = PessoaApp.Select(new List<string>());

            if (pessoas.Count() == 0)
                return NoContent();

            return Ok(pessoas);
        }

        [HttpPost]
        public IActionResult InserirPessoa(PessoaDTO pessoaDTO)
        {
            Pessoa pessoa = new Pessoa(pessoaDTO);

            if (PessoaApp.Save(pessoa))
            {
                return Ok("Pessoa Salva com Sucesso!");
            }
            else
            {
                return NotFound("Ocorreu Algum erro.");
            }
        }

        [HttpPut]
        public IActionResult AlteraPessoa(Pessoa pessoa)
        {
            if (string.IsNullOrEmpty(pessoa.Id))
                return BadRequest("Pessoa não existe.");

            if (!PessoaApp.Save(pessoa))
            {
                return BadRequest("Ocorreu um erro ao alterar a pessoa.");
            }

            return Ok(new { message = "Pessoa alterada com sucesso!" });
        }

        [HttpDelete]
        public IActionResult DeletarPessoa(string id)
        {
            var pessoas = PessoaApp.Select(id);

            if (pessoas == null)
                return BadRequest("Pessoa não existe.");

            if (!PessoaApp.Delete(pessoas))
                return NoContent();

            return Ok("Pessoa excluida com sucesso!");
        }

    }
}
