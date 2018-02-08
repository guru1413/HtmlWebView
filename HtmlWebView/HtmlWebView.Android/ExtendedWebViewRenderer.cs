using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using HtmlWebView.Control;
using HtmlWebView.Droid;
using Xamarin.Forms;
using WebView = Android.Webkit.WebView;

[assembly: ExportRenderer(typeof(ExtendedWebView), typeof(ExtendedWebViewRenderer))]
namespace HtmlWebView.Droid
{
    public class ExtendedWebViewRenderer : WebViewRenderer
    {
        WebView _webView;
        public ExtendedWebViewRenderer(Context context) : base(context)
        {
        }

        class ExtendedWebViewClient : Android.Webkit.WebViewClient
        {
            ExtendedWebView _xwebView = null;
            public ExtendedWebViewClient(ExtendedWebView xwebView)
            {
                _xwebView = xwebView;
            }

            public override async void OnPageFinished(WebView view, string url)
            {
                if (_xwebView != null)
                {
                    int i = 10;
                    // wait here till content is rendered
                    while (view.ContentHeight < i && i-- > 0)
                        await System.Threading.Tasks.Task.Delay(100);
                    _xwebView.HeightRequest = view.ContentHeight;
                }
                base.OnPageFinished(view, url);
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            _webView = Control;

            if (e.OldElement == null)
            {
                _webView.SetWebViewClient(new ExtendedWebViewClient(e.NewElement as ExtendedWebView));
            }
        }
    }
}