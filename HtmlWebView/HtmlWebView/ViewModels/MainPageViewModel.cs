using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlWebView.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private string _htmlString;
        public string HtmlString
        {
            get { return _htmlString; }
            set { SetProperty(ref _htmlString, value); }
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            HtmlString = "<h1>Special Condition</h1>\r\n<h2>Special Condition</h2>\r\n<h3>Special Condition</h3>\r\n<h4>Special Condition</h4>\r\n<h5>Special Condition</h5>\r\n<h6>Special Condition</h6>";
        }
    }
}
