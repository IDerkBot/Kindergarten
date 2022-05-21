using System.Windows.Controls;
using Kindergarten.Views.Windows;
using MaterialDesignThemes.Wpf;
using System.Timers;

namespace Kindergarten.Models
{
	internal class PageManager
	{
		private static Frame MainFrame { get; set; }
        public static void SetFrame(Frame frame) { MainFrame = frame; }
		public static void Navigate(Page titlePage) => MainFrame.Navigate(titlePage);
		public static void GoBack() { if (MainFrame.CanGoBack) MainFrame.GoBack(); }
        public static bool CanGoBack() => MainFrame.CanGoBack;
    }

    internal class AlertManager
    {
        private static MainWindow MainWindow { get; set; }
        public static void SetWindow(MainWindow window)
        {
            MainWindow = window;
        }
        public static void Alert(string message)
        {
            MainWindow.SbAlert.Message = new SnackbarMessage { Content = message };
            MainWindow.SbAlert.IsActive = true;
            MainWindow.MainTimer.Start();
        }
    }
}