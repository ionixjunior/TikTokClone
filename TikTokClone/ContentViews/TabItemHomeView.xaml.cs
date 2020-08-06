using System;
using System.Collections.Generic;
using TikTokClone.ViewModels;
using Xamarin.Forms;

namespace TikTokClone.ContentViews
{
    public partial class TabItemHomeView : ContentView
    {
        public TabItemHomeView()
        {
            InitializeComponent();
            BindingContext = new TabItemHomeViewModel();
        }
    }
}
