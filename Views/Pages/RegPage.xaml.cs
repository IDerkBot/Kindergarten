using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kindergarten.Models;
using Kindergarten.Models.Entity;

namespace Kindergarten.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для RegPage.xaml
	/// </summary>
	public partial class RegPage : Page
	{
		public RegPage()
		{
			InitializeComponent();
		}

		private void Reg_Click(object sender, RoutedEventArgs e)
		{
			if (!KindergartenEntities.GetContext().Users.Any(x => x.Login == Login.Text))
			{
				KindergartenEntities.GetContext().Users.Add(new User() {Login = Login.Text, Password = Password.Password});
				KindergartenEntities.GetContext().SaveChanges();
				PageManager.GoBack();
			}
			else
				MessageBox.Show("Пользователь уже существует");
		}
	}
}
