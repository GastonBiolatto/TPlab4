using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tpfinal.Models
{
    [Table("Equipamiento")]
    public class Equipamiento
    {
        [Key]
        [Column("IDEquipamiento")]
        public int IDEquipamiento { get; set; }

        [Display(Name = "Nombre")]
        [StringLength(50)]
        public string Nombre
        {
            get; set;
        }

        [Display(Name = "Cantidad")]
        public int Cantidad
        {
            get; set;
        }

        [Display(Name = "Ubicacion")]
        [StringLength (50)]
        public string Ubicacion { get; set; }

        [Display(Name = "Fecha revicion")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime FechaRevicion { get; set; }


        [Display(Name = "Departamento")]
        public int IdDepartamento { get; set; }
        [ForeignKey("IdDepartamento")]
        public virtual Departamento? Departamento { get; set; }
    }
}
