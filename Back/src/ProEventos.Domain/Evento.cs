using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProEventos.Domain;
[Table("TBEvento")]
public class Evento{
    public int Id { get; set; }
    public string Local { get; set; }
    public DateTime? DataEvento { get; set; }
    [Required]
    [MaxLength(50)]
    public string Tema { get; set; }
    public int QtdPessoas { get; set; }
    public string ImagemURL { get; set; }
    public string Telefone { get; set; }
    
    public string Email { get; set; }
    public IEnumerable<Lote> Lotes{ get; set; }
    public IEnumerable<RedeSocial> RedesSociais{ get; set; }
    public IEnumerable<PalestranteEvento> PalestrantesEventos { get; set; }

}