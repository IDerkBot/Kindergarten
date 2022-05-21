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
	/// Логика взаимодействия для ChildrenPage.xaml
	/// </summary>
	public partial class ChildrenPage : Page
	{
		public ChildrenPage()
		{
			InitializeComponent();
		}
		private void BtnEdit_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new ChildrenEditPage((sender as Button)?.DataContext as Child));

		private void BtnDelete_Click(object sender, RoutedEventArgs e)
		{
			var usersForRemoving = DGrid.SelectedItems.Cast<Child>().ToList();
			if (MessageBox.Show($"Вы точно хотите удалить следующие {usersForRemoving.Count()} элементов?", "Внимание",
				    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
			{
				KindergartenEntities.GetContext().Children.RemoveRange(usersForRemoving);
				KindergartenEntities.GetContext().SaveChanges();
				MessageBox.Show("Данные удалены!");
				DGrid.ItemsSource = KindergartenEntities.GetContext().Children.ToList();
			}
		}

		private void BtnAdd_Click(object sender, RoutedEventArgs e) => PageManager.Navigate(new ChildrenEditPage());

		private void Page_Loaded(object sender, RoutedEventArgs e)
		{
			Update();
		}

        public void Update()
        {
            DGrid.ItemsSource = KindergartenEntities.GetContext().Children.ToList();
		}

        private void BtnSend_OnClick(object sender, RoutedEventArgs e)
        {
            var send = new SendWindows(this, (sender as Button)?.DataContext as Child);
			send.Show();
        }
    }
}
