using IntegradorAsaas.Aplicacao.Pessoas;
using IntegradorAsaas.Dominio.Contas;
using IntegradorAsaas.Dominio.Pessoas;
using IntegradorAsaas.Service.Clientes;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorAsaas.API.Controllers.Cobrancas
{
    [ApiController]
    [Route("[controller]")]
    public class CobrancaController : Controller
    {
        ClienteService clienteService = new ClienteService();
        PessoaAplicacao pessoaApp = new PessoaAplicacao();

        public CobrancaController()
        {
            
        }

        [HttpPost("InserirClienteCobranca")]
        public IActionResult InserirConta(string pessoaId)
        {
            Pessoa pessoa = pessoaApp.Select(pessoaId);

            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada!");
            }

            clienteService.CriarCliente(pessoa);

            return Ok("OK");
        }
    }
}
