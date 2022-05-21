using System;
using System.Timers;
using System.Windows;
using Kindergarten.Models;

namespace Kindergarten.Views.Windows
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
        public Timer MainTimer { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            PageManager.SetFrame(MainFrame);
            PageManager.Navigate(new AuthPage());
            AlertManager.SetWindow(this);
            MainTimer = new Timer(3000);
            MainTimer.Elapsed += MainTimerOnElapsed;
        }

        private void MainTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                SbAlert.IsActive = false;
                MainTimer.Stop();
            });
        }


        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            BtnBack.Visibility = PageManager.CanGoBack() ? Visibility.Visible : Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PageManager.GoBack();
        }
    }
}
