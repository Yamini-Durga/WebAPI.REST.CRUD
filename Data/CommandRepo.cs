using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.REST.CRUD.Models;

namespace WebAPI.REST.CRUD.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly CommandContext _context;

        public CommandRepo(CommandContext context)
        {
            _context = context;
        }
        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }
    }
}
