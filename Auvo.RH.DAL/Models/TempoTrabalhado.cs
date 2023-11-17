using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

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
        public string Almoco { get; set; }

        [ForeignKey("PK_Colaborador")]
        public virtual Colaborador Colaborador { get; set; }
        
        [Required]
        public int? PK_Colaborador { get; set; }



    }
}
