using AutoMapper;
using ToDoListDigitalInnovationOne.Dtos;
using ToDoListDigitalInnovationOne.Models;

namespace ToDoListDigitalInnovationOne.Profiles
{
    public class ToDoListProfile : Profile
    {
        public ToDoListProfile()
        {
            CreateMap<CreateToDoDto, ToDoList>();

            CreateMap<PutToDoDto, ToDoList>();
        }
    }
}
