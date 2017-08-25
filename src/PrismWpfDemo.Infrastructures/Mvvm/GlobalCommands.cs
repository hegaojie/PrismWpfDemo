using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;

namespace PrismWpfDemo.Infrastructures.Mvvm
{
    public static class GlobalCommands
    {
        public static CompositeCommand SaveAllCommand = new CompositeCommand();
    }
}
