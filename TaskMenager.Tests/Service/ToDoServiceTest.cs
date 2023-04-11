using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Model.Interface;
using TaskMenager.Aplication.Service;
using FluentAssertions;
using TaskMenager.Aplication.ViewModel;
using TaskMenager.Domain.Model;
using System.Net.Http.Headers;

namespace TaskMenager.Tests.Service
{
    public class ToDoServiceTest
    {
        [Fact]
        public void GetAll_Should_ReturnListForListVm()
        {
            var repo = new Mock<IToDoRepository>();
            var map = TestHelper.AddMapper();
            var ser = new ToDoService(repo.Object, map);

            var result = ser.GetAll();

            result.Should().NotBeNull();
            result.Should().BeOfType<ListToDoForListVm>();
        }

        [Fact]
        public void Add_Should_InvokeToDoRepositoryAdd()
        {
            var todo = new NewToDoVm();
            var repo = new Mock<IToDoRepository>();
            var map = TestHelper.AddMapper();
            var ser = new ToDoService(repo.Object, map);

            ser.Add(todo);

            repo.Verify(x => x.Add(It.IsAny<ToDo>()), Times.Once);
        }

        [Fact]
        public void Delete_Should_InvokeToDoRepositoryDelete()
        {
            var repo = new Mock<IToDoRepository>();
            var map = TestHelper.AddMapper();
            var ser = new ToDoService(repo.Object, map);

            ser.Delete(It.IsAny<int>());

            repo.Verify(x => x.Delete(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void Details_Should_ReturnDetailsToDoVm()
        {
            var repo = new Mock<IToDoRepository>();
            repo.Setup(x => x.Details(It.IsAny<int>())).Returns(new ToDo());
            var map = TestHelper.AddMapper();
            var ser = new ToDoService(repo.Object, map);

            var result = ser.Details(It.IsAny<int>());

            result.Should().NotBeNull();
            result.Should().BeOfType<DetailsToDoVm>();
        }

        [Fact]
        public void IsDone_Should_InvokeToDoRepositoryIsDone()
        {
            var todo = new ToDo();
            var repo = new Mock<IToDoRepository>();
            repo.Setup(x => x.GetTodo(It.IsAny<int>())).Returns(todo);
            var map = TestHelper.AddMapper();
            var ser = new ToDoService(repo.Object, map);

            ser.IsDone(It.IsAny<int>());

            todo.IsDone.Should().BeTrue();
            repo.Verify(x => x.Update(It.IsAny<ToDo>()), Times.Once);
        }

        [Fact]
        public void GetToDoToUpdate_Should_ReturnUpdateToDoVm()
        {
            var repo = new Mock<IToDoRepository>();
            repo.Setup(x => x.GetTodo(It.IsAny<int>())).Returns(new ToDo());
            var map = TestHelper.AddMapper();
            var ser = new ToDoService(repo.Object, map);

            var result = ser.GetToDoToUpdate(It.IsAny<int>());

            result.Should().NotBeNull();
            result.Should().BeOfType<UpdateToDoVm>();
        }

        [Fact]        
        public void Update_Should_InvokeToDoRepositoryUpdate()
        {
            var repo = new Mock<IToDoRepository>();
            var map = TestHelper.AddMapper();
            var ser = new ToDoService(repo.Object, map);

            ser.Update(It.IsAny<UpdateToDoVm>());

            repo.Verify(x => x.Update(It.IsAny<ToDo>()), Times.Once);            
        }
    }
}
