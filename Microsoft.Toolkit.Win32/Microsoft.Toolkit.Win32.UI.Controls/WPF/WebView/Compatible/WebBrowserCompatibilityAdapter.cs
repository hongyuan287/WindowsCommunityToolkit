﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Toolkit.Win32.UI.Controls.Interop.WinRT;

namespace Microsoft.Toolkit.Win32.UI.Controls.WPF.Compatible
{
    internal sealed class WebBrowserCompatibilityAdapter : WebBaseCompatibilityAdapter
    {
        private WebBrowser _browser = new WebBrowser();

        private void Browser_Navigated(object sender, NavigationEventArgs e)
        {
            NavigationCompleted?.Invoke(sender, e);
        }

        private void Browser_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            NavigationStarting?.Invoke(sender, e);
            ContentLoading?.Invoke(sender, e);
        }

        public override Uri Source { get => _browser.Source; set => _browser.Source = value; }

        public override bool CanGoBack => _browser.CanGoBack;

        public override bool CanGoForward => _browser.CanGoForward;

        public override FrameworkElement View => _browser;

        public override event EventHandler<WebViewControlNavigationStartingEventArgs> NavigationStarting;

        public override event EventHandler<WebViewControlContentLoadingEventArgs> ContentLoading;

        public override event EventHandler<WebViewControlNavigationCompletedEventArgs> NavigationCompleted;

        public override bool GoBack()
        {
            _browser.GoBack();
            return true;
        }

        public override bool GoForward()
        {
            _browser.GoForward();
            return true;
        }

        public override string InvokeScript(string scriptName)
        {
            return _browser.InvokeScript(scriptName)?.ToString();
        }

        public override void Navigate(Uri url)
        {
            _browser.Navigate(url);
        }

        public override void Navigate(string url)
        {
            _browser.Navigate(url);
        }

        public override void Refresh()
        {
            _browser.Refresh();
        }

        public override void Stop()
        {
        }

        protected override void Initialize()
        {
            _browser.Navigating += Browser_Navigating;
            _browser.LoadCompleted += Browser_Navigated;
            Bind(nameof(Source), SourceProperty, _browser);
        }
    }
}