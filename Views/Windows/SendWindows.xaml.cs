using System.Linq;
using System.Windows;
using Kindergarten.Models.Entity;
using Kindergarten.Views.Pages;

namespace Kindergarten.Views.Windows
{
    /// <summary>
    /// Interaction logic for SendWindows.xaml
    /// </summary>
    public partial class SendWindows : Window
    {
        private readonly Child _currentChild;
        private readonly ChildrenPage _currentWindow;
        public SendWindows(ChildrenPage windows, Child selectedChild)
        {
            InitializeComponent();
            _currentChild = selectedChild;
            _currentWindow = windows;
            CbGroups.ItemsSource = KindergartenEntities.GetContext().Groups.ToList();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (CbGroups.SelectedItem == null)
            {
                MessageBox.Show("Выберите клуб");
                return;
            }
            var group = (Group)CbGroups.SelectedItem;
            if (group.Children.Count == group.MaxChild)
            {
                MessageBox.Show("Клуб заполнен");
                return;
            }
            _currentChild.Group = group;
            KindergartenEntities.GetContext().SaveChanges();
            _currentWindow.Update();
            MessageBox.Show("Запись успешно прошла!");
            Close();
        }
    }
}
