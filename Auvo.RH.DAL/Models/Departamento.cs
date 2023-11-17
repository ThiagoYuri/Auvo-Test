using Auvo.RH.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auvo.RH.DAL.Models
{
    [Table("Departamento")]
    public class Departamento
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }

        public virtual List<Colaborador> Colaboradores { get; set; }
    }
}
