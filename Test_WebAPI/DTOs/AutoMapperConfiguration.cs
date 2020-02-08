using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_WebAPI.Models;

namespace Test_WebAPI.DTOs
{
    public class AutoMapperConfiguration
    {
        public static Mapper Map { get; set; }
        public static void Configure() 
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employees, EmployeeDTO>()
                   .ReverseMap();

                cfg.CreateMap<Positions, PositionsDTO>()
                   .ForMember(x => x.Employees, o => o.Ignore())
                   .ReverseMap();

                cfg.CreateMap<Profile, ProfileDTO>()
                .ForMember(x => x.Employees, o => o.Ignore())
                   .ReverseMap();
            });
        }
    }
}
