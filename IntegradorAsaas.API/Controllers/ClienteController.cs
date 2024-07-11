using IntegradorAsaas.Aplicacao.Pessoas;
using IntegradorAsaas.Dominio.Pessoas;
using IntegradorAsaas.Service.Clientes;
using Microsoft.AspNetCore.Mvc;

namespace IntegradorAsaas.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : Controller
    {
        PessoaAplicacao pessoaApp = new PessoaAplicacao();
        ClienteService clienteService = new ClienteService();

        public ClienteController()
        {
            
        }

        [HttpPost("InserirClienteAssas")]
        public async Task<IActionResult> InserirConta(string pessoaId)
        {
            Pessoa pessoa = pessoaApp.Select(pessoaId);

            if (pessoa == null)
            {
                return NotFound("Pessoa não encontrada!");
            }

            await clienteService.CriarCliente(pessoa);

            if (!string.IsNullOrEmpty(pessoa.AsaasId))
            {
                pessoaApp.Save(pessoa);
                return Ok("OK");
            }

            return NotFound("Não foi possivel inserir o cliente.");
        }
    }
}
