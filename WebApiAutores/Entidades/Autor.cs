using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAutores.Entidades
{
    public class Autor
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(5,ErrorMessage ="El campo {0} no puede tener mas de {1} caracteres")]
        public string Nombre { get; set; }
            
        [Range(18,26)]
        public int Edad { get; set; }

        [NotMapped]
        [CreditCard]
        public string TarjetaCredito { get; set; }

        [NotMapped]
        [Url]
        public string DireccionUrl { get; set; }

        public List<Libro> Libros { get; set; } 
    }
}
