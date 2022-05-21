using System.Windows;
using System.Windows.Controls;
using Kindergarten.Models;
using Kindergarten.Models.Entity;

namespace Kindergarten.Views.Pages.Edit
{
	/// <summary>
	/// Логика взаимодействия для ClubEditPage.xaml
	/// </summary>
	public partial class ClubEditPage : Page
	{
		private readonly Group _currentClub;
		public ClubEditPage(Group selectedClub = null)
		{
			InitializeComponent();
			_currentClub = selectedClub ?? new Group();
			DataContext = _currentClub;
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (_currentClub.ID == 0) KindergartenEntities.GetContext().Groups.Add(_currentClub);
			KindergartenEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			PageManager.GoBack();
		}
	}
}
