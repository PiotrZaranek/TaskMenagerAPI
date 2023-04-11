using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Aplication.ViewModel;

namespace TaskMenager.Aplication.Interface
{
    public interface IToDoService
    {
        ListToDoForListVm GetAll();
        void Add(NewToDoVm todo);
        void Delete(int todoId);
        DetailsToDoVm Details(int todoId);
        void IsDone(int todoId);
        void Update(UpdateToDoVm todo);
        UpdateToDoVm GetToDoToUpdate(int todoId);
    }
}
