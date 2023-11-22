using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tpfinal.Models
{
    [Table("Asistencia")]
    public class Asistencia
    {
        [Key]
        [Column("IDAsistencia")]
        public int IIDAsistencia { get; set; }


        [Display(Name = "CantidadAsistencia")]  [StringLength(50)]
        public int ContAsistencia
        {
            get; set;
        }
        [Display(Name = "IDCuerpoActivo")]
        public int IDCuerpoActivo { get; set; }
        [ForeignKey("IDCuerpoActivo")]
        public virtual CuerpoActivo? CuerpoActivo { get; set; }
        
    }
}
