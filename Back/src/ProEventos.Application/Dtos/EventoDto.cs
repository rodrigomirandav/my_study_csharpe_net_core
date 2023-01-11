using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.Application.Dtos
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        MinLength(3, ErrorMessage = "{0} deve ter no mínimo 4 caracteres"),        
        MaxLength(50, ErrorMessage = "{0} deve ter no máximo 50 caracteres")]
        public string Tema { get; set; }
        [Display(Name = "quantidade de pessoas")]
        [Range(1,120000, ErrorMessage = "{0}")]
        public int QtdPessoas { get; set; }
        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$")]
        public string ImagemURL { get; set; }
        [Required]
        [Phone(ErrorMessage = "O campo {0} está errado")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "emai-l")]
        [EmailAddress(ErrorMessage = "O campo {0} precisa ser um {0} válido")]
        public string Email { get; set; }   
        public IEnumerable<LoteDto> Lotes{ get; set; }
        public IEnumerable<RedeSocialDto> RedesSociais{ get; set; }
        public IEnumerable<PalestranteDto> Palestrantes { get; set; }
    }
}