using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kindergarten.Models;
using Kindergarten.Models.Entity;
using Kindergarten.Views.Pages.Edit;
using Kindergarten.Views.Windows;

namespace Kindergarten.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для ClubsPage.xaml
	/// </summary>
	public partial class ClubsPage : Page
	{
		public ClubsPage()
		{
			InitializeComponent();
		}
		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new ClubEditPage((sender as Button)?.DataContext as Group));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var usersForRemoving = DGrid.SelectedItems.Cast<Group>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				KindergartenEntities.GetContext().Groups.RemoveRange(usersForRemoving);
				KindergartenEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = KindergartenEntities.GetContext().Groups.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new ClubEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = KindergartenEntities.GetContext().Groups.ToList();
			BtnReport.Visibility = Data.IsAdmin ? Visibility.Visible : Visibility.Collapsed;
		}

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            new ReportWindow().Show();
        }
    }
}
