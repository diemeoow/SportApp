using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using SportClub.ViewModels;

namespace SportClub.Views
{
    /// <summary>
    /// Логика взаимодействия для GenericTableView.xaml
    /// </summary>
    public partial class GenericTableView : UserControl
    {
        public GenericTableView()
        {
			DataContext = App.AppHost.Services.GetService(typeof(MainViewModel));
			InitializeComponent();
        }
    }
}
