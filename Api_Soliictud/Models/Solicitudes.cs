using System.ComponentModel.DataAnnotations;

namespace Api_Soliictud.Models
{
    public class Solicitudes
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Descripcion es obligatorio.")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo Monto es obligatorio.")]

        public Decimal Monto { get; set; }
        [Required(ErrorMessage = "El campo Fecha es obligatorio.")]

        public string FechaEsperada { get; set; }
        public string Estado { get; set; }
        //public int Id_Estado { get; set; }
        public string Solicitante { get; set; }
        public string Acciones { get; set; }
        public string Comentario { get; set; }
    }
}
