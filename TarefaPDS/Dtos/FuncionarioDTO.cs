using System.ComponentModel.DataAnnotations;

namespace TarefaPDS.Dtos
{
    public class FuncionarioDTO
    {
        [Required]
        [MinLength(1)]
        public string Descricao { get; set; }
    }
}
