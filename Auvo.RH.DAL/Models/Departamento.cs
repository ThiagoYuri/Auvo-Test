using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auvo.RH.DAL.Models
{
    [Table("Departamento")]
    public class Departamento
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}
