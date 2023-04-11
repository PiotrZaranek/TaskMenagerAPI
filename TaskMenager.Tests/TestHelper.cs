using AutoMapper;
using TaskMenager.Aplication.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskMenager.Tests
{
    internal static class TestHelper
    {
        public static Mapper AddMapper()
        {
            var profile = new MappingProfile();
            var configure = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            return new Mapper(configure);
        }
    }
}
