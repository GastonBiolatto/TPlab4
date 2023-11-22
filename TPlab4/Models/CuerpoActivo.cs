using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tpfinal.Models
{
    [Table("CuerpoActivo")]
    public class CuerpoActivo
    {
        [Key]
        [Column("IDCuerpoActivo")]
        public int IDCuerpoActivo { get; set; }


        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string Nombre
        {
            get; set;
        }

        [Display(Name = "Apellido")]
        [StringLength(50)]
        public string Apellido
        {
            get; set;
        }
        [Display(Name = "DNI")]
        public int DNI { get; set; }

        [Display(Name = "Direccion")]
        [StringLength(50)]
        public string Direccion { get; set; }

        [Display(Name = "Departamento")]
        public int? IdDepartamento { get; set; }
        [ForeignKey("DepartamentoRefId")]
        public virtual Departamento? Departamento { get; set; }
    }
}

