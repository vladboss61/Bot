namespace TelegramBot.Models
{
    using System.Collections.Generic;
    using TelegramBot.Models.Commands;

    public class CommandsCollection
    {
        private readonly IBotRepository _botRepository;

        private readonly List<Command> _commands;

        public IReadOnlyList<Command> Commands => _commands.AsReadOnly();

        public CommandsCollection(IBotRepository repository)
        {
            _botRepository = repository;

            _commands = new List<Command>(){
                new HelloCommand(),
                new StartCommand(repository),
                new StopCommand(repository)
            };
        }
    }
}