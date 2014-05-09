namespace Harley
{
    using System.Windows;
    using Harley.Properties;
    using Harley.UI;

    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            new MainWindow(Settings.Default.Title, Settings.Default.Address)
                .Show();
        }
    }
}