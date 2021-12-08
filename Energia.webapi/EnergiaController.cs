using Energia1.domain;
using Energia1.repos;
using Microsoft.AspNetCore.Mvc;
namespace Energia1.webapi
{
    [ApiController]
    [Route("[controller]")]
    public class EnergiaController: ControllerBase
    {
        private IEnergiaRepos repositorio;

        public EnergiaController(IEnergiaRepos _repositorio)
        {
            this.repositorio = _repositorio; 
        }

        [HttpGet()]
        public IActionResult Get()
        {
            // Retorna lista e os meses de menor e maior consumo:
            return Ok( new{
                message="Lista obtida com sucesso!",
                codeHttp = 201,
                data = repositorio.GetAll(),
                MesMenorConsumo=repositorio.MenorConsumo(),
                MesMaiorConsumo=repositorio.MaiorConsumo()
                } );
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok( new{
                message="Dado obtido com sucesso!",
                codeHttp = 201,
                data = repositorio.GetById(id)});
        }

        [HttpPost]
        public IActionResult Post([FromBody]Energia item)
        {
            repositorio.Create(item);
            // Retorna mensagem de confirmação e os meses de menor e maior consumo:
            return Ok( new{
                message="Item inserido com sucesso!",
                codeHttp = 201,
                Item=item,
                MesMenorConsumo=repositorio.MenorConsumo(),
                MesMaiorConsumo=repositorio.MaiorConsumo()
                } );
        }

        [HttpPut]
        public IActionResult Put([FromBody]Energia item)
        {
            repositorio.Update(item);
            return Ok( new {
                message = "Item atualizado com sucesso!", 
                codeHttp = 201,
                objetoCreated = item
            });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repositorio.Delete(id);
            return Ok (new {
                message="Item removido com sucesso!",
                id = id
            });
        }
    }
}