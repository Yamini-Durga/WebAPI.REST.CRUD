using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.REST.CRUD.Models;

namespace WebAPI.REST.CRUD.Data
{
    public class CommandRepo : ICommandRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            throw new NotImplementedException();
        }

        public Command GetCommandById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
