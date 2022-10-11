using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using ToDoListDigitalInnovationOne.Dtos;
using ToDoListDigitalInnovationOne.Enums;
using ToDoListDigitalInnovationOne.Interfaces;
using ToDoListDigitalInnovationOne.Models;

namespace ToDoListDigitalInnovationOne.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;
        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpPost]
        public IActionResult AddToDo(CreateToDoDto toDoListDto)
        {
            var result = _toDoListRepository.CreateToDo(toDoListDto);
            return CreatedAtAction(nameof(GetToDoById), new { Id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public IActionResult PutToDo(int id, PutToDoDto putToDoDto)
        {
            var result = _toDoListRepository.PutToDoList(Id, putToDoDto);
            return result.IsSuccess ? (NoContent()) : (NotFound(result.Errors[0].Message));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteToDo(int id)
        {
            var result = _toDoListRepository.DeleteToDo(id);
            return result.IsSuccess ? (Ok()) : (NotFound(result.Errors[0].Message));
        }

        [Route("ObterTodos")]
        [HttpGet]
        public IActionResult GetAllToDo()
        {
            var result = _toDoListRepository.GetAllToDo();
            return result.Count > 0 ? (Ok(result)) : (NotFound("Ainda não há tarefas cadastradas."));
        }

        [HttpGet("{id}")]
        public IActionResult GetToDoById(int id)
        {
            var result = _toDoListRepository.GetToDoById(id);
            return result != null ? (Ok(result)) : (NotFound("Não encontrado."));
        }
        [HttpGet("BuscarPorTitulo")]
        public IActionResult GetToDoByTitle(string title)
        {
            var result = _toDoListRepository.GetToDoByTitle(title);
            return result.Count > 0 ? (Ok(result)) : (NotFound("Não encontrado."));
        }

        [HttpGet("BuscarPorData")]
        public IActionResult GetToDoByDate(DateTime date)
        {
            var result = _toDoListRepository.GetToDoByDate(date);
            return result.Count > 0 ? (Ok(result)) : (NotFound("Não encontrado"));
        }

        [HttpGet("ObterPorStatus")]
        public IActionResult GetToDoByStatus(Status status)
        {
            // implementar a lógica para buscar por status..
        }
    }

}
