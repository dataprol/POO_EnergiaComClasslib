using Energia1.domain;
using Energia1.repos;
using Microsoft.AspNetCore.Mvc;
namespace Energia1.webapi
{

    [ApiController]
    [Route("[controller]")]
    public class ClienteController: ControllerBase
    {
        private IClienteRepository repositorio;

        public ClienteController(IClienteRepository _repositorio)
        {
            this.repositorio = _repositorio; 
        }

        [HttpGet()]
        public IActionResult Get()
        {
            // Retorna lista de clientes:
            return Ok( new{
                message="Lista de clientes obtida com sucesso!",
                codeHttp = 201,
                data = new{ 
                            clientes=repositorio.GetAll() 
                            }
                } );
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok( new{
                message="Cliente obtido com sucesso!",
                codeHttp = 201,
                data = new {
                            MesMenorConsumo=repositorio.MenorConsumoCliente(id),
                            MesMaiorConsumo=repositorio.MaiorConsumoCliente(id),
                            cliente=repositorio.GetById(id)
                            }
                } );
        }

        [HttpPost]
        public IActionResult Post([FromBody]Cliente item)
        {
            repositorio.Create(item);
            // Retorna mensagem de confirmação:
            return Ok( new{
                message="Cliente inserido com sucesso!",
                codeHttp = 201,
                Item=item
                } );
        }

        [HttpPut]
        public IActionResult Put([FromBody]Cliente item)
        {
            repositorio.Update(item);
            return Ok( new {
                message = "Cliente atualizado com sucesso!", 
                codeHttp = 201,
                objetoCreated = item
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repositorio.Delete(id);
            return Ok (new {
                message="Cliente removido com sucesso!",
                id = id
            });
        }       
    }
}