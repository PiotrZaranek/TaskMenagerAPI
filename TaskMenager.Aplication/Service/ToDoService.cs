using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Aplication.Interface;
using TaskMenager.Aplication.ViewModel;
using TaskMenager.Domain.Model;
using TaskMenager.Model.Interface;

namespace TaskMenager.Aplication.Service
{    
    public class ToDoService : IToDoService
    {
        private IToDoRepository _toDoRepository;
        private IMapper _mapper;

        public ToDoService(IToDoRepository toDoRepository, IMapper mapper)
        {
            _toDoRepository = toDoRepository;
            _mapper = mapper;
        }

        public ListToDoForListVm GetAll()
        {
            var test = _toDoRepository.GetAll();
            var type = test.GetType();

            var todos = _toDoRepository.GetAll().ProjectTo<ToDoForListVm>(_mapper.ConfigurationProvider).ToList();

            return CreateVm(todos);
        }

        public void Add(NewToDoVm todoVm)
        {
            var todo = _mapper.Map<ToDo>(todoVm);
            AddEmptyValue(todo);
            _toDoRepository.Add(todo);
        }

        public void Delete(int todoId)
        {
            _toDoRepository.Delete(todoId);
        }

        public DetailsToDoVm Details(int todoId)
        {
            var todoVm = _mapper.Map<DetailsToDoVm>(_toDoRepository.Details(todoId));
            return todoVm;
        }

        public void IsDone(int todoId)
        {
            var todo = _toDoRepository.GetTodo(todoId);
            todo.IsDone = true;
            _toDoRepository.Update(todo);
        }

        public UpdateToDoVm GetToDoToUpdate(int todoId)
        {
            var todoVm = _mapper.Map<UpdateToDoVm>(_toDoRepository.GetTodo(todoId));
            return todoVm;
        }

        public void Update(UpdateToDoVm todoVm)
        {
            var todo = _mapper.Map<ToDo>(todoVm);
            _toDoRepository.Update(todo);
        }

        private ListToDoForListVm CreateVm(List<ToDoForListVm> todos)
        {
            return new ListToDoForListVm()
            {
                ToDos = todos,
                Count = todos.Count
            };
        }
        private void AddEmptyValue(ToDo todo)
        {
            todo.IsDone = false;
            todo.AddedDate = DateTime.Now;
            todo.CompletedDate = null;
        }
    }
}
