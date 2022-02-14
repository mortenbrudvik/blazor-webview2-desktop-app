using System;
using System.Windows;

namespace WPF.UI
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            webView2.EnsureCoreWebView2Async(null);
            webView2.Source = new Uri("https://localhost:7225/");

            webView2.CoreWebView2InitializationCompleted += (sender, args) =>
            {
                if (args.IsSuccess)
                {
                    webView2.CoreWebView2.NewWindowRequested += async (sender2, args2) =>
                    {
                        args2.Handled = true;

                        var filePath = args2.Uri.ToString();
                        
                        await webView2.ExecuteScriptAsync($"interopFunctions.setFilePath('{filePath}');");
                    };
                    
                }
            };
        }

        private async void ButtonSetFilePath_Click(object sender, RoutedEventArgs e)
        {
            await webView2.ExecuteScriptAsync($"interopFunctions.setFilePath('{txtFilePath.Text}');");
        }

    }
}
