using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tpfinal.Models
{
    [Table("Departamento")]
    public class Departamento
    {
        [Key]
        [Column("IdDepartamento")]
        public int IdDepartamento { get; set; }


        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string Nombre
        {
            get; set;
        }
    }
}
