using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.REST.CRUD.Dtos;
using WebAPI.REST.CRUD.Models;

namespace WebAPI.REST.CRUD.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandDto>();
        }
    }
}
