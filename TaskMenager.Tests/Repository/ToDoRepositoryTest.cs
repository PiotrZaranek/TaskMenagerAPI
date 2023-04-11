using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Infrastructure;
using TaskMenager.Infrastructure.Repository;
using TaskMenager.Domain.Model;
using Moq;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using TaskMenager.Model.Interface;
using Microsoft.EntityFrameworkCore.Internal;

namespace TaskMenager.Tests.Repository
{
    public class ToDoRepositoryTest
    {
        [Fact]
        public void GetAll_Should_ReturnIQueryableToDo()
        {
            var con = new Mock<Context>();
            var repo = new ToDoRepository(con.Object);

            var result = repo.GetAll();

            result.Should().BeOfType<InternalDbSet<ToDo>>();
        }

        
    }
}
