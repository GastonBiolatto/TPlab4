using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Bomberosfinallab.Models
{
    [Table("CuerpoActivo")]
    public class CuerpoActivo
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Display(Name = "Nro")]
        public int Nro
        {
            get; set;
        }

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
        public int? DepartamentoRefId { get; set; }
        [ForeignKey("DepartamentoRefId")]
        public virtual Departamento? Departamento { get; set; }

        [Display(Name = "Imagen")]

        [StringLength(50)]
        public string? ImagemBomber { get; set; }

        [NotMapped]
        [Display(Name ="subir imagen ")]
        public IFormFile ImageFile { get; set; }

        
    }
}

