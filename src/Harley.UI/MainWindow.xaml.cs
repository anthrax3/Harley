namespace Harley.UI
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow(string title = null, string address = null)
        {
            Title = title ?? Title;

            EmbeddedBrowser.Init();
            InitializeComponent();
            Browser.Address = address;
        }
    }
}