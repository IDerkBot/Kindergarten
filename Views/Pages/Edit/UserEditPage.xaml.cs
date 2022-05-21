using System.Windows;
using System.Windows.Controls;
using Kindergarten.Models;
using Kindergarten.Models.Entity;

namespace Kindergarten.Views.Pages.Edit
{
	/// <summary>
	/// Логика взаимодействия для UserEditPage.xaml
	/// </summary>
	public partial class UserEditPage : Page
	{
		private readonly User _currentUser;
		public UserEditPage(User selectedUser = null)
		{
			InitializeComponent();
			_currentUser = selectedUser ?? new User();
			DataContext = _currentUser;
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (_currentUser.ID == 0) KindergartenEntities.GetContext().Users.Add(_currentUser);
			KindergartenEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			PageManager.GoBack();
		}
	}
}
