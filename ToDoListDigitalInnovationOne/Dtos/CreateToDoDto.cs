using System.ComponentModel.DataAnnotations;
using ToDoListDigitalInnovationOne.Enums;

namespace ToDoListDigitalInnovationOne.Dtos
{
    public class CreateToDoDto
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
