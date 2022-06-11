using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.REST.CRUD.Models;

namespace WebAPI.REST.CRUD.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command cmd);
        void DeleteCommand(Command cmd);
    }
}
