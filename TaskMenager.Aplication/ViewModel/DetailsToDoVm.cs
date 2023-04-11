﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskMenager.Aplication.Mapper;
using TaskMenager.Domain.Model;

namespace TaskMenager.Aplication.ViewModel
{
    public class DetailsToDoVm : IMapFrom<ToDo>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime CompletedDate { get; set; }
        public DateTime RealizationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ToDo, DetailsToDoVm>();
        }
    }
}
