using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Najot.Console
{
    public class Menu
    {
        private readonly List<Command> commands;
        
        public string Title { get; set; }
        public Menu Parent { get; set; }

        public Menu(Menu parent = null)
        {
            commands = new List<Command>();
            var backCommand = new Command();
            
            if(parent != null)
            {
                Parent = parent;
                backCommand.Name = "Back";
                backCommand.NextMenu = parent;
                commands.Add(backCommand);
            }
            else
            {
                backCommand.Name = "Exit";
                
                backCommand.Action = () => Environment.Exit(0);
                
                commands.Add(backCommand);
            }
        }

        public void AddCommand(string name, Menu nextMenu)
        {
            var command = new Command();

            command.Name = name;
            command.NextMenu = nextMenu;

            commands.Add(command);
        }

        public void AddCommand(string name, Action action)
        {
            var command = new Command();

            command.Name = name;
            command.NextMenu = this;
            command.Action = action;
            commands.Add(command);
        }

        public Menu ExecuteCommand(int id)
        {
            if (id < 0)
            {
                throw new Exception("Command Id is wrong");
            }
            else
            {
                var command = commands[id];
                
                command.Execute();
                return command.NextMenu;
            }
        }

        public void Print()
        {
            System.Console.WriteLine(Title);

            for (int i = 1; i < commands.Count; i++)
            {
                System.Console.WriteLine($"{i}. {commands[i].Name}");
            }

            System.Console.WriteLine($"0. {commands[0].Name}");
        }
    }
}
