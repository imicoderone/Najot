using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Najot.Console
{
    public class ConsoleApplication
    {
        private Menu currentMenu;

        public void Setup(Func<Menu> settings)
        {
            currentMenu = settings();
        }

        public void Run()
        {
            if(currentMenu == null)
            {
                throw new Exception("Menu list should be set up");
            }

            while (true)
            {
                currentMenu.Print();
                var input = Convert.ToInt32(System.Console.ReadLine());
                currentMenu = currentMenu.ExecuteCommand(input);
            }
        }
    }
}
