using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTokClone.ContentViews;
using TikTokClone.Models;
using TikTokClone.Templates;
using TikTokClone.ViewModels;
using Xamarin.Forms;

namespace TikTokClone.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainView : ContentPage
    {
        private readonly Lazy<TabItemHomeView> _homeView;
        private readonly Lazy<TabItemDiscoverView> _discoverView;
        private readonly Lazy<TabItemAddView> _addView;
        private readonly Lazy<TabItemInboxView> _inboxView;
        private readonly Lazy<TabItemMeView> _meView;

        public MainView()
        {
            InitializeComponent();

            _homeView = new Lazy<TabItemHomeView>();
            _discoverView = new Lazy<TabItemDiscoverView>();
            _addView = new Lazy<TabItemAddView>();
            _inboxView = new Lazy<TabItemInboxView>();
            _meView = new Lazy<TabItemMeView>();

            BindingContext = new MainViewModel();
        }

        private void OnTabTapped(object sender, EventArgs args)
        {
        }
    }
}
