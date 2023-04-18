using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TaskMenager.Aplication.Interface;
using TaskMenager.Aplication.ViewModel;

namespace TaskMenager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ToDoController : ControllerBase
    {
        private IToDoService _toDoService;

        public ToDoController(IToDoService toDoService) 
        { 
            _toDoService = toDoService;
        }

        [HttpGet]
        public ListToDoForListVm GetAllToDos()
        {
            return _toDoService.GetAll();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> NewToDo(NewToDoVm todo)
        {
            try
            {
                _toDoService.Add(todo);
            }            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return "Dodano nowe zadanie";
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> Delete(int todoId)
        { 
            try
            {
                _toDoService.Delete(todoId);
            }
            catch (Exception ex)
            { 
                return BadRequest(ex.Message);
            }
            
            return "Usunięto zadanie";
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<DetailsToDoVm> Details(int todoId)
        {
            DetailsToDoVm todo;

            try
            {
                todo = _toDoService.Details(todoId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return todo;
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> IsDone(int todoId)
        { 
            try
            {
                _toDoService.IsDone(todoId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);                    
            }

            return $"Zadanie o id {todoId} zostało oznaczone jako wykonane";
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<UpdateToDoVm> Update(int todoId)
        {
            UpdateToDoVm todo;
            try 
            { 
                todo = _toDoService.GetToDoToUpdate(todoId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return todo;
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<string> Update(UpdateToDoVm todo)
        {
            try
            {
                _toDoService.Update(todo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
            return "Zaktualizowano zadanie!";
        }
    }
}
