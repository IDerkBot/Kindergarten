using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kindergarten.Models;
using Kindergarten.Models.Entity;

namespace Kindergarten.Views.Pages.Edit
{
	/// <summary>
	/// Логика взаимодействия для ChildrenEditPage.xaml
	/// </summary>
	public partial class ChildrenEditPage : Page
	{
		private readonly Child _currentChild;
		public ChildrenEditPage(Child selectedChild = null)
		{
			InitializeComponent();
			CbParents.ItemsSource = KindergartenEntities.GetContext().Parents.ToList();
			_currentChild = selectedChild ?? new Child();
			DataContext = _currentChild;
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (_currentChild.ID == 0) KindergartenEntities.GetContext().Children.Add(_currentChild);
			KindergartenEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			PageManager.GoBack();
		}
	}
}
