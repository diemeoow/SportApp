using SportClub.ViewModels;
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
using System.Windows.Shapes;

namespace SportClub.Views
{
	/// <summary>
	/// Логика взаимодействия для LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{
			InitializeComponent();
		}

		private void ForgotPassword_OnClick(object sender, RoutedEventArgs e)
		{
			MessageBox.Show("Инструкция по восстановлению пароля отправлена на вашу почту.", "Восстановление пароля", MessageBoxButton.OK, MessageBoxImage.Information);
		}
		private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
		{
			if (DataContext is LoginViewModel vm)
				vm.Password = ((PasswordBox)sender).Password;
		}
	}
}
