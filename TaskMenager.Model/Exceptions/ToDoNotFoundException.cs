using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenager.Domain.Exceptions
{
    public class ToDoNotFoundException : Exception
    {
        public ToDoNotFoundException() : base("Nie znaleziono zadania w bazie danych.") { }
    }
}
