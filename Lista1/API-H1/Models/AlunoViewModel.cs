using System.ComponentModel.DataAnnotations;

namespace API_H1.Models
{
    public class AlunoViewModel
    {
        public string Nome { get; set; }

        [Required(ErrorMessage = "O RA é obrigatório")]
        [MinLength(6, ErrorMessage = "O RA deve ter 6 caracteres")]
        [MaxLength(6, ErrorMessage = "O RA deve ter 6 caracteres")]
        public string RA { get; set; }
        
        public string Email { get; set; }
        public string CPF { get; set; }
        public bool Ativo { get; set; }
    }
}
