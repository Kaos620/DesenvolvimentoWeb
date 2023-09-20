
using Revisão_1.Models.Validations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Revisão_1.Models.Request
{
    public class RegistrarJogoViewModel
    {

        [Required(ErrorMessage = "Digite um Nome")]
        [MinLength(3, ErrorMessage = "O nome deve ter ao menos 3 letras")]
        [MaxLength(255, ErrorMessage = "Limite maximo de letras atingido")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite um CPF")]
        [CPFValidation]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Digite um Numero")]
        [Range(1,60, ErrorMessage = "Deve ser um numero entre 1 a 60")]
        public int PrimeiroNro { get; set; }

        [Required(ErrorMessage = "Digite um Numero")]
        [Range(1, 60, ErrorMessage = "Deve ser um numero entre 1 a 60")]
        public int SegundoNro { get; set; }

        [Required(ErrorMessage = "Digite um Numero")]
        [Range(1, 60, ErrorMessage = "Deve ser um numero entre 1 a 60")]
        public int TerceiroNro { get; set; }

        [Required(ErrorMessage = "Digite um Numero")]
        [Range(1, 60, ErrorMessage = "Deve ser um numero entre 1 a 60")]
        public int QuartoNro { get; set; }

        [Required(ErrorMessage = "Digite um Numero")]
        [Range(1, 60, ErrorMessage = "Deve ser um numero entre 1 a 60")]
        public int QuintoNro { get; set; }

        [Required(ErrorMessage = "Digite um Numero")]
        [Range(1, 60, ErrorMessage = "Deve ser um numero entre 1 a 60")]
        public int SextoNro { get; set; }

        [JsonIgnore]
        public DateTime DataJogo { get; set; }

        [NumerosValidation(ErrorMessage = "Deve ter 6 numeros diferentes")]
        public int[] NumeroDoJogo { get; set; }
    }
}