using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kindergarten.Models;
using Kindergarten.Models.Entity;
using Kindergarten.Views.Pages.Edit;

namespace Kindergarten.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для ParentsPage.xaml
	/// </summary>
	public partial class ParentsPage : Page
	{
		public ParentsPage()
		{
			InitializeComponent();
		}
		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new ParentEditPage((sender as Button)?.DataContext as Parent));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var usersForRemoving = DGrid.SelectedItems.Cast<Parent>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				KindergartenEntities.GetContext().Parents.RemoveRange(usersForRemoving);
				KindergartenEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = KindergartenEntities.GetContext().Parents.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new ParentEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = KindergartenEntities.GetContext().Parents.ToList();
		}
	}
}
