using Auvo.RH.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Auvo.RH.Models
{
    [Table("Colaborador")]
    public class Colaborador
    {
        [Key]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }


        [Required]
        public virtual Departamento Departamento { get; set; }
        public virtual List<TempoTrabalhado> TempoTrabalhado { get; set; }




        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Colaborador other = (Colaborador)obj;
            return Codigo == other.Codigo && Nome == other.Nome;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Codigo, Nome);
        }
    }
}
