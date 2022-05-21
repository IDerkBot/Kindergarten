using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kindergarten.Models;
using Kindergarten.Models.Entity;
using Kindergarten.Views.Pages.Edit;

namespace Kindergarten.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для UsersPage.xaml
	/// </summary>
	public partial class UsersPage : Page
	{
		public UsersPage()
		{
			InitializeComponent();
		}
		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new UserEditPage((sender as Button)?.DataContext as User));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var usersForRemoving = DGrid.SelectedItems.Cast<User>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				KindergartenEntities.GetContext().Users.RemoveRange(usersForRemoving);
				KindergartenEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = KindergartenEntities.GetContext().Users.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new UserEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = KindergartenEntities.GetContext().Users.ToList();
		}

        private void TbSearch_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
