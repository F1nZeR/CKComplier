using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CKCompiler.GUI
{
    public static class MyCommands
    {
        public static RoutedUICommand Compile = new RoutedUICommand("Compile", "Compile", typeof(MyCommands));
        public static RoutedUICommand Generate = new RoutedUICommand("Generate", "Generate", typeof(MyCommands));
    }
}
