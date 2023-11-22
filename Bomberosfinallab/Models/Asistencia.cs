using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bomberosfinallab.Models
{
    [Table("Asistencia")]
    public class Asistencia
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }


        [Display(Name = "CantidadAsistencia")]  
        public int ContAsistencia
        {
            get; set;
        }

        [Display(Name = "Nro")]
        public int? CuerpoActivoRefId { get; set; }
        [ForeignKey("CuerpoActivoRefId")]
        public virtual CuerpoActivo? CuerpoActivo { get; set; }

    }
}
