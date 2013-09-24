using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CKCompiler.GUI
{
    public static class Command
    {
        public static readonly RoutedUICommand CompileCommand = new RoutedUICommand("Compile", "Compile", typeof(MainWindow));

    }
}
