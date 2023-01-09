using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    private readonly DataContext _context;
    public EventoController(DataContext context){
        _context = context;
    } 
    
    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos;
    }

    [HttpGet("{id}")]
    public Evento GetByID(int id)
    {
        return _context.Eventos.FirstOrDefault(e => e.EventoID == id);
    }
}
