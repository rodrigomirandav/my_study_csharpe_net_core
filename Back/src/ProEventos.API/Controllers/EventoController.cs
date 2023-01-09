using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    public  IEnumerable<Evento> _evento = new Evento []{
        new Evento(){
            EventoID = 1,
            Tema = "Angular 11e .Net6",
            Local = "São Paulo",
            Lote = "1º Lote",
            QtdPessoas = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString(),
            ImagemURL = "foto.png"
        },
        new Evento(){
            EventoID = 2,
            Tema = "Angular e suas novidades",
            Local = "Rio de Janeiro",
            Lote = "1º Lote",
            QtdPessoas = 250,
            DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy"),
            ImagemURL = "foto.png"
        }
    };  
    
    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _evento;
    }

    [HttpDelete("{id}")]
    public string Delete(int id){
        return "Deletado!";
    }
}
