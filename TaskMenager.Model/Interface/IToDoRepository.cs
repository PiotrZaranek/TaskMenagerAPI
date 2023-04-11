using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Domain.Model;

namespace TaskMenager.Model.Interface
{
    public interface IToDoRepository
    {
        IQueryable<ToDo> GetAll();
        void Add(ToDo todo);
        void Delete(int todoId);
        ToDo Details(int todoId);
        void Update(ToDo todo);
        ToDo GetTodo(int todoId);
    }
}
