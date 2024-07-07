using IntegradorAsaas.Aplicacao.Contas;
using IntegradorAsaas.Aplicacao.Pessoas;
using IntegradorAsaas.Dominio.Contas;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorAsaas.API.Controllers.Contas
{
    [ApiController]
    [Route("[controller]")]
    public class ContaController : Controller
    {
        ContaAplicacao ContaApp = new ContaAplicacao();
        PessoaAplicacao pessoaApp = new PessoaAplicacao();

        // Consulta uma conta por ID
        [HttpGet("ConsultarContaPorId/{id}")]
        public IActionResult ConsultarContaPorId(string id)
        {
            var conta = ContaApp.Select(id);

            if (conta == null)
                return NoContent();

            conta.Pessoa = pessoaApp.Select(conta.PessoaId);

            return Ok(conta);
        }

        // Consulta todas as contas
        [HttpGet("ConsultarTodasContas")]
        public IActionResult ConsultarTodasContas()
        {
            var contas = ContaApp.Select(new List<string>());

            if (contas.Count() == 0)
                return NoContent();

            foreach (var conta in contas)
            {
                conta.Pessoa = pessoaApp.Select(conta.PessoaId);
            }

            return Ok(contas);
        }
        [HttpPost]
        public IActionResult InserirConta(ContaDTO ContaDTO)
        {
            Conta Conta = new Conta(ContaDTO);


            if (ContaApp.Save(Conta))
            {
                return Ok("Conta Salva com Sucesso!");
            }
            else
            {
                return NotFound("Ocorreu Algum erro.");
            }
        }

        [HttpPut]
        public IActionResult AlteraConta(Conta conta)
        {
            if (string.IsNullOrEmpty(conta.Id))
                return BadRequest("Conta não existe.");

            if (!ContaApp.Save(conta))
            {
                return BadRequest("Ocorreu um erro ao alterar a Conta.");
            }

            return Ok(new { message = "Conta alterada com sucesso!" });
        }

        [HttpDelete]
        public IActionResult DeletarConta(string id)
        {
            var Contas = ContaApp.Select(id);

            if (Contas == null)
                return BadRequest("Conta não existe.");

            if (!ContaApp.Delete(Contas))
                return NoContent();

            return Ok("Conta excluida com sucesso!");
        }

    }
}
