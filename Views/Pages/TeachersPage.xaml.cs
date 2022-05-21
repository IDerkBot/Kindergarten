using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kindergarten.Models;
using Kindergarten.Models.Entity;
using Kindergarten.Views.Pages.Edit;

namespace Kindergarten.Views.Pages
{
	/// <summary>
	/// Логика взаимодействия для TeachersPage.xaml
	/// </summary>
	public partial class TeachersPage : Page
	{
		public TeachersPage()
		{
			InitializeComponent();
		}
		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new TeacherEditPage((sender as Button)?.DataContext as Teacher));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var usersForRemoving = DGrid.SelectedItems.Cast<Teacher>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				KindergartenEntities.GetContext().Teachers.RemoveRange(usersForRemoving);
				KindergartenEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = KindergartenEntities.GetContext().Teachers.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new TeacherEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			DGrid.ItemsSource = KindergartenEntities.GetContext().Teachers.ToList();
		}
	}
}
