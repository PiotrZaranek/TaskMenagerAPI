using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TaskMenager.Aplication.Interface;
using TaskMenager.Aplication.ViewModel;

namespace TaskMenager.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private IToDoService _toDoService;

        public ToDoController(IToDoService toDoService) 
        { 
            _toDoService = toDoService;
        }

        [HttpGet]
        public IActionResult GetAllToDos()
        {
            return Ok(_toDoService.GetAll());
        }

        [HttpPost]
        public IActionResult NewToDo(NewToDoVm todo)
        {
            try
            {
                _toDoService.Add(todo);
            }            
            catch
            {
                return BadRequest("Coś poszło nie tak! :(");
            }

            return Ok("Dodano nowe zadanie do listy!");
        }

        [HttpDelete]
        public IActionResult Delete(int todoId)
        { 
            try
            {
                _toDoService.Delete(todoId);
            }
            catch
            { 
                return BadRequest("Nie udało się usunąć zadania!");
            }
            
            return Ok("Usunięto rekord");
        }

        [HttpGet]
        public IActionResult Details(int todoId)
        {
            DetailsToDoVm todo;

            try
            {
                todo = _toDoService.Details(todoId);
            }
            catch
            {
                return BadRequest("Coś poszło nie tak! :(");
            }

            return Ok(todo);
        }

        [HttpPatch]
        public IActionResult IsDone(int todoId)
        { 
            try
            {
                _toDoService.IsDone(todoId);
            }
            catch 
            {
                return BadRequest("Coś poszło nie tak!");                    
            }

            return Ok($"Zadanie o id {todoId} zostało oznaczone jako wykonane");
        }

        [HttpGet]
        public IActionResult Update(int todoId)
        {
            UpdateToDoVm todo;
            try 
            { 
                todo = _toDoService.GetToDoToUpdate(todoId);
            }
            catch
            {
                return BadRequest("Coś poszło nie tak! :(");
            }

            return Ok(todo);
        }

        [HttpPost]
        public IActionResult Update(UpdateToDoVm todo)
        {
            try
            {
                _toDoService.Update(todo);
            }
            catch
            {
                return BadRequest("Coś poszło nie tak! :(");
            }            
            return Ok("Zaktualizowano zadanie!");
        }
    }
}
