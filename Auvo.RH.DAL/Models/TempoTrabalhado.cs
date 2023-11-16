using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auvo.RH.Models
{
    [Table("TempoTrabalhado")]
    public class TempoTrabalhado
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Required]
        /// <summary>
        /// Valor por hora trabalhada
        /// </summary>
        public float ValorHora { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public DateTime Entrada { get; set; }
        [Required]
        public DateTime Saida { get; set; }
        [Required]
        public DateTime AlmocoInic
        {
            get { return AlmocoInic; }
            set
            {
                if (DateTime.TryParse(AdicionarHorasDaString(value.ToString(), 0), out DateTime horasDateTime))
                    Data = Data.AddHours(horasDateTime.Hour).AddMinutes(horasDateTime.Minute);
                else
                {
                    Console.WriteLine("Formato de hora inválido.");
                }
            }
        }

        [Required]
        public DateTime AlmocoFim { get; private set; }

        [Required]
        public virtual Colaborador Colaborador { get; set; }


        private string AdicionarHorasDaString(string horasString, int index)
        {
            // Divida a string em duas partes usando o caractere '-' como delimitador
            string[] partes = horasString.Split('-');

            // Certifique-se de que há duas partes na string
            if (partes.Length == 2)
            {
                // Obtém as horas de início e de término a partir das partes
                return partes[index].Trim();
            }
            else
            {
                throw new Exception("Formato de horas inválido.");
            }
        }

        private void AdicionarHorasAoDateTime(string hora)
        {
            if (DateTime.TryParse(hora, out DateTime horasDateTime))
            {
                // Adiciona as horas da string à propriedade Data
                Data = Data.AddHours(horasDateTime.Hour).AddMinutes(horasDateTime.Minute);
            }
            else
            {
                Console.WriteLine("Formato de hora inválido.");
            }
        }




    }
}
