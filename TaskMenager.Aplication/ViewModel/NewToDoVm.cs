using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Aplication.Mapper;
using TaskMenager.Domain.Model;

namespace TaskMenager.Aplication.ViewModel
{
    public class NewToDoVm : IMapFrom<ToDo>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime RealizationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewToDoVm, ToDo>();
        }
    }
}
