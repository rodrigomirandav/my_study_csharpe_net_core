using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    public IEventoService _eventoService { get; }
    public EventosController(IEventoService eventoService){
        _eventoService = eventoService;
    } 
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var eventos = await _eventoService.GetAllEventosAsync(true);
            
            if (eventos == null) return NotFound("Nenhum evento encontrado");

            return Ok(eventos);
        }
        catch (Exception ex)
        {
          return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar recuperar eventos. Erro: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByID(int id)
    {
        try
        {
            var evento = await _eventoService.GetEventosByIdAsync(id, true);
            
            if (evento == null) return NotFound("Evento por id não encontrado.");

            return Ok(evento);
        }
        catch (Exception ex)
        {
          return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar recuperar evento. Erro: {ex.Message}");
        }
    }

    [HttpGet("{tema}/tema")]
    public async Task<IActionResult> GetByTema(string tema)
    {
        try
        {
            var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);
            
            if (eventos == null) return NotFound("Eventos por temas encontrados.");

            return Ok(eventos);
        }
        catch (Exception ex)
        {
          return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar recuperar os eventos. Erro: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Post(Evento model)
    {
        try
        {
            var evento = await _eventoService.AddEventos(model);
            
            if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

            return Ok(evento);
        }
        catch (Exception ex)
        {
          return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar cadastrar o evento. Erro: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Evento model)
    {
        try
        {
            var evento = await _eventoService.UpdateEvento(id, model);
            
            if (evento == null) return BadRequest("Erro ao tentar alterar o evento.");

            return Ok(evento);
        }
        catch (Exception ex)
        {
          return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar alterar o evento. Erro: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            return await _eventoService.DeleteEvento(id) ?
                Ok("Deletado"):
                BadRequest("Evento não deletado.");
        }
        catch (Exception ex)
        {
          return this.StatusCode(StatusCodes.Status500InternalServerError,
            $"Erro ao tentar deletar o evento. Erro: {ex.Message}");
        }
    }
}
