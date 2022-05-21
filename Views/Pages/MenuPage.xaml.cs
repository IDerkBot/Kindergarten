using System.Windows;
using System.Windows.Controls;
using Kindergarten.Models;

namespace Kindergarten.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для MenuPage.xaml
	/// </summary>
	public partial class MenuPage : Page
	{
		public MenuPage() => InitializeComponent();

		private void BtnClubsMove_OnClick(object sender, RoutedEventArgs e) => PageManager.Navigate(new ClubsPage());

		private void BtnChildrenMove_OnClick(object sender, RoutedEventArgs e) => PageManager.Navigate(new ChildrenPage());

		private void BtnParentsMove_OnClick(object sender, RoutedEventArgs e) => PageManager.Navigate(new ParentsPage());

		private void BtnUsersMove_OnClick(object sender, RoutedEventArgs e) => PageManager.Navigate(new UsersPage());

		private void MenuPage_OnLoaded(object sender, RoutedEventArgs e)
		{
			BtnChildrenMove.Visibility = Data.IsParent ? Visibility.Collapsed : Visibility.Visible;
			BtnParentsMove.Visibility = Data.IsParent ? Visibility.Collapsed : Visibility.Visible;
			BtnUsersMove.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
		}
	}
}
