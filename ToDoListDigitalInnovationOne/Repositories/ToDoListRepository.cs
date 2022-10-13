using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ToDoListDigitalInnovationOne.Context;
using ToDoListDigitalInnovationOne.Dtos;
using ToDoListDigitalInnovationOne.Enums;
using ToDoListDigitalInnovationOne.Interfaces;
using ToDoListDigitalInnovationOne.Models;

namespace ToDoListDigitalInnovationOne.Repositories
{
    public class ToDoListRepository : IToDoListRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public ToDoListRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public ToDoList CreateToDo(CreateToDoDto createToDoDto)
        {
            try
            {
                var toDo = _mapper.Map<ToDoList>(createToDoDto);
                _appDbContext.Add(toDo);
                _appDbContext.SaveChanges();
                return toDo;
            }
            catch (Exception)
            {
                throw new Exception();
            }

        }

        public Result DeleteToDo(int Id)
        {
            var toDo = GetToDoById(Id);
            if (toDo == null)
            {
                return Result.Fail("Não encontrado.");
            }
            _appDbContext.ToDoList.Remove(toDo);
            _appDbContext.SaveChanges();
            return Result.Ok();
        }

        public List<ToDoList> GetAllToDo()
        {
            return _appDbContext.ToDoList.ToList();
        }

        public List<ToDoList> GetToDoByDate(DateTime date)
        {
            var toDos = _appDbContext.ToDoList
                .Where(d => d.Data.Date == date.Date);
            return toDos.ToList();
        }

        public ToDoList? GetToDoById(int Id)
        {
            return _appDbContext.ToDoList.Find(Id);
        }

        public List<ToDoList> GetToDoByStatus(Status status)
        {
            var toDosByStatus = _appDbContext.ToDoList.Where(t => t.Status == status);
            return toDosByStatus.ToList();
        }

        public List<ToDoList> GetToDoByTitle(string titulo)
        {
            var toDo = _appDbContext.ToDoList
                .Where(t => t.Titulo.ToUpper() == titulo.ToUpper() || t.Titulo.StartsWith(titulo));

            return toDo.ToList();
        }

        public Result PutToDoList(int Id, PutToDoDto putToDoDto)
        {
            var toDo = GetToDoById(Id);
            if (toDo == null)
            {
                return Result.Fail("Não encontrado.");
            }
            var updatedToDo = _mapper.Map(putToDoDto, toDo);
            _appDbContext.SaveChanges();
            return Result.Ok();
        }

    }
}
