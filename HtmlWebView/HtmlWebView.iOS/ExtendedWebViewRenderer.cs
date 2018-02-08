using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using HtmlWebView.Control;
using Xamarin.Forms.Platform.iOS;
using HtmlWebView.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(ExtendedWebView), typeof(ExtendedWebViewRenderer))]
namespace HtmlWebView.iOS
{
    public class ExtendedWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            Delegate = new ExtendedUIWebViewDelegate(this);
        }
    }

    public class ExtendedUIWebViewDelegate : UIWebViewDelegate
    {
        ExtendedWebViewRenderer webViewRenderer;

        public ExtendedUIWebViewDelegate(ExtendedWebViewRenderer _webViewRenderer = null)
        {
            webViewRenderer = _webViewRenderer ?? new ExtendedWebViewRenderer();
        }

        public override async void LoadingFinished(UIWebView webView)
        {
            var wv = webViewRenderer.Element as ExtendedWebView;
            if (wv != null)
            {
                wv.HeightRequest = 10;
                // wait here till content is rendered
                await System.Threading.Tasks.Task.Delay(100);
                wv.HeightRequest = (double)webView.ScrollView.ContentSize.Height;
            }
        }
    }
}