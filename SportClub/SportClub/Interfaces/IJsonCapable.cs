using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SportClub.Interfaces
{
    public interface IJsonCapable
    {
        ICommand ExportCommand { get; }
        ICommand ImportCommand { get; }
    }
}
