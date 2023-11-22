using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bomberosfinallab.Models
{
    [Table("Departamento")]
    public class Departamento
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }


        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string Nombre
        {
            get; set;
        }
    }
}
