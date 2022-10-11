using ToDoListDigitalInnovationOne.Enums;

namespace ToDoListDigitalInnovationOne.Models
{
    public class ToDoList
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public Status Status { get; set; }

    }
}
