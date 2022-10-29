using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Najot.Console
{
    public class Command
    {
        public string Name { get; set; }

        public Action Action { get; set; }

        public Menu NextMenu { get; set; }

        public Menu Execute()
        {
            Action?.Invoke();
            return NextMenu;
        }
    }
}
