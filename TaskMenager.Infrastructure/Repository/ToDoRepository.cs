using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Domain.Model;
using TaskMenager.Model.Interface;

namespace TaskMenager.Infrastructure.Repository
{
    public class ToDoRepository : IToDoRepository
    {
        private Context _context;

        public ToDoRepository(Context context) 
        { 
            _context = context;
        }

        public IQueryable<ToDo> GetAll()
        {                      
            return _context.ToDos;
        }

        public void Add(ToDo todo)
        {
            _context.ToDos.Add(todo);
            _context.SaveChanges();
        }

        public void Delete(int todoId)
        {
            var todo = GetTodo(todoId);
            _context.ToDos.Remove(todo);
            _context.SaveChanges();
        }

        public ToDo Details(int todoId)
        {
            return GetTodo(todoId);    
        }

        public void Update(ToDo todo)
        {
            _context.ToDos.Update(todo);
            _context.SaveChanges();
        }

        public ToDo GetTodo(int todoId)
        {
            var todo = _context.ToDos.Find(todoId);

            if (todo == null)
            {
                throw new Exception();
            }
            else
            {
                return todo;
            }            
        }
    }
}
