namespace eVision.Desktop.UI
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
            : this(null, _ => Task.FromResult(0))
        {}

        public MainWindow(string title, Func<IDictionary<string, object>, Task> appFunc)
        {
            Title = title ?? Title;

            EmbeddedOwinBrowser.Init(appFunc);
            InitializeComponent();
        }
    }
}