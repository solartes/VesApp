using System.ComponentModel.DataAnnotations;
namespace VesApp.Domain
{
    public class Project
    {
        [Key]
        public int IdProject { get; set; }
        public string UrlVideo { get; set; }
        public string UrlImagen { get; set; }
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Text { get; set; }
        public string Titulo { get; set; }
    }
}
