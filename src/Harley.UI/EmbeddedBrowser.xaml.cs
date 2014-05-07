namespace Harley.UI
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    using CefSharp;
    using CefSharp.Wpf;

    /// <summary>
    ///     Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class EmbeddedBrowser
    {
        private readonly Dictionary<string, Action> _propertyChangeHandlers = new Dictionary<string, Action>();
        private readonly WebView _webView;

        public EmbeddedBrowser()
        {
            InitializeComponent();

            var browserSettings = new BrowserSettings
            {
                ApplicationCacheDisabled = true,
                PageCacheDisabled = true,
                DatabasesDisabled = true,
            };
            _webView = new WebView("http://zombo.com/", browserSettings);
            _propertyChangeHandlers.Add("Address", () => AddressTextBox.Text = _webView.Address);
            _webView.PropertyChanged += (sender, args) =>
            {
                Action handler;
                if(_propertyChangeHandlers.TryGetValue(args.PropertyName, out handler))
                {
                    Dispatcher.Invoke(handler);
                }
            };
            DockPanel.Children.Add(_webView);
        }

        public static void Init(Func<IDictionary<string, object>, Task> appFunc)
        {
            var settings = new Settings();
            if(CEF.Initialize(settings))
            {
                // Plug in custom scheme handler here.
                //CEF.RegisterScheme("http", new OwinSchemeHandlerFactory(appFunc));
            }
        }

        private void AddressTextBox_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }
            _webView.Load(AddressTextBox.Text);
        }

        private void ForwardButton_OnClick(object sender, RoutedEventArgs e)
        {
            _webView.Forward();
        }

        private void BackButton_OnClick(object sender, RoutedEventArgs e)
        {
            _webView.Back();
        }

        private void EmbeddedOwinBrowser_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                _webView.Reload(true);
                return;
            }
            if (e.Key == Key.F12)
            {
                _webView.ShowDevTools();
            }
        }
    }
}