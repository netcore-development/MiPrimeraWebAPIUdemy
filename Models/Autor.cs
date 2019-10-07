using System.ComponentModel.DataAnnotations;

namespace primerWebAPIVSCode.Models
{
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
    }
}