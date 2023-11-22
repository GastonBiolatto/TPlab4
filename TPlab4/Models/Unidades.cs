using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace tpfinal.Models
{
    [Table("Unidades")]
    public class Unidades
    {
        [Key]
        [Column("IDUnidades")]
        public int IDUnidades { get; set; }

        [Display(Name = "Numero")]
        public int Numero
        {
            get; set;
        }

        [Display(Name = "tipo")]
        [StringLength(50)]
        public string Tipo { get; set; }

        [Display(Name = "Fecha revicion")]
        [Column(TypeName = "smalldatetime")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime FechaRevicion { get; set; }


    }
}
