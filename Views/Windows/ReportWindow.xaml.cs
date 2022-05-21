using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Kindergarten.Models.Entity;

namespace Kindergarten.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
            var clubs = KindergartenEntities.GetContext().Groups.ToList();
            var TvItems = new List<object>();
            clubs.ForEach(club =>
            {
                TvItems.Add(new TreeViewItem()
                {
                    Header = $"Группа: {club.Title} ({((club.Children.Count == 0) ? "Детей в группе нет" : $"Количество детей: {club.Children.Count}")})",
                    ItemsSource = club.Children.Select(x => x.Fullname)
                });
            });
            SpClubs.ItemsSource = TvItems;
        }
    }
}
