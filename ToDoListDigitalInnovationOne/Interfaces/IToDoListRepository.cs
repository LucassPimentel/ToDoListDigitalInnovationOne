using FluentResults;
using ToDoListDigitalInnovationOne.Dtos;
using ToDoListDigitalInnovationOne.Enums;
using ToDoListDigitalInnovationOne.Models;

namespace ToDoListDigitalInnovationOne.Interfaces
{
    public interface IToDoListRepository
    {
        ToDoList CreateToDo(CreateToDoDto createToDoDto);
        Result DeleteToDo(int Id);
        List<ToDoList> GetAllToDo();
        List<ToDoList> GetToDoByDate(DateTime date);
        ToDoList GetToDoById(int id);
        List<ToDoList> GetToDoByStatus(Status status);
        List<ToDoList> GetToDoByTitle(string titulo);
        Result PutToDoList(int Id, PutToDoDto putToDoDto);
    }
}