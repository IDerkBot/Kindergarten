using System.Windows;
using System.Windows.Controls;
using Kindergarten.Models;
using Kindergarten.Models.Entity;

namespace Kindergarten.Views.Pages.Edit
{
	/// <summary>
	/// Логика взаимодействия для TeacherEditPage.xaml
	/// </summary>
	public partial class TeacherEditPage : Page
	{
		private readonly Teacher _currentTeacher;
		public TeacherEditPage(Teacher selectedTeacher = null)
		{
			InitializeComponent();
			_currentTeacher = selectedTeacher ?? new Teacher();
			DataContext = _currentTeacher;
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (_currentTeacher.ID == 0) KindergartenEntities.GetContext().Teachers.Add(_currentTeacher);
			KindergartenEntities.GetContext().SaveChanges();
			MessageBox.Show("Данные сохранены!");
			PageManager.GoBack();
		}
	}
}
