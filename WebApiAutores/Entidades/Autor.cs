using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiAutores.Validaciones;

namespace WebApiAutores.Entidades
{
    public class Autor: IValidatableObject
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        //[PrimeraLetraMayuscula]
        public string Nombre { get; set; }
            
        //[Range(18,26)]
        public int Edad { get; set; }

        //[NotMapped]
        //[CreditCard]
        //public string TarjetaCredito { get; set; }

        //[NotMapped]
        //[Url]
        //public string DireccionUrl { get; set; }

        public List<Libro> Libros { get; set; } 

        //[NotMapped]
        //public int Mayor { get; set; }
        //[NotMapped]
        //public int Menor { get; set; }


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrEmpty(Nombre))
            {
                string primeraLetra = Nombre[0].ToString();

                if (primeraLetra != primeraLetra.ToUpper())
                {
                   yield return new ValidationResult("La primera letra debe ser mayuscula",
                       new string[] {nameof(Nombre)} );
                }
            }

            //if (Menor>Mayor)
            //{
            //    yield return new ValidationResult("El numero no puede ser mas grande que el mayor", 
            //        new string[] {nameof(Menor) });
            //}
        }
    }
}
