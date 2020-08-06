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

            TabItemContentView.Content = _homeView.Value;
            BindingContext = new MainViewModel();
        }

        private void OnTabTapped(object sender, TappedEventArgs args)
        {
            if (args.Parameter is TabItem tabItem)
            {
                if (tabItem.DataTemplateType == typeof(TabItemHomeView))
                {
                    TabItemContentView.Content = _homeView.Value;
                    return;
                }

                if (tabItem.DataTemplateType == typeof(TabItemDiscoverView))
                {
                    TabItemContentView.Content = _discoverView.Value;
                    return;
                }

                if (tabItem.DataTemplateType == typeof(TabItemAddView))
                {
                    TabItemContentView.Content = _addView.Value;
                    return;
                }

                if (tabItem.DataTemplateType == typeof(TabItemInboxView))
                {
                    TabItemContentView.Content = _inboxView.Value;
                    return;
                }

                if (tabItem.DataTemplateType == typeof(TabItemMeView))
                {
                    TabItemContentView.Content = _meView.Value;
                    return;
                }
            }
        }
    }
}
