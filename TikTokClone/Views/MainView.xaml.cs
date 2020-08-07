using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TikTokClone.ContentViews;
using TikTokClone.Models;
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
        private Color _tabBarTransparent = Color.Transparent;
        private Color _tabBarWhite = Color.White;
        
        public MainView()
        {
            InitializeComponent();

            _homeView = new Lazy<TabItemHomeView>();
            _discoverView = new Lazy<TabItemDiscoverView>();
            _addView = new Lazy<TabItemAddView>();
            _inboxView = new Lazy<TabItemInboxView>();
            _meView = new Lazy<TabItemMeView>();

            TabItemContentView.Content = _homeView.Value;
            TabBar.BackgroundColor = _tabBarTransparent;
            BindingContext = new MainViewModel();
        }

        private async void OnTabTapped(object sender, EventArgs args)
        {
            await OnTabTappedAsync(sender, args);
        }

        private async Task OnTabTappedAsync(object sender, EventArgs args)
        {
            if (args is TappedEventArgs tappedEventArgs && tappedEventArgs.Parameter is TabItem tabItem)
            {
                if (tabItem.DataTemplateType == typeof(TabItemHomeView))
                {
                    var carouselViewElement = _homeView.Value.FindByName<CarouselView>("CarouselViewVideos");
                    carouselViewElement.IsScrollAnimated = false;

                    TabItemContentView.Content = _homeView.Value;
                    TabBar.BackgroundColor = _tabBarTransparent;

                    await Task.Delay(100);
                    carouselViewElement.IsScrollAnimated = true;
                    return;
                }

                if (tabItem.DataTemplateType == typeof(TabItemDiscoverView))
                {
                    TabItemContentView.Content = _discoverView.Value;
                    TabBar.BackgroundColor = _tabBarWhite;
                    return;
                }

                if (tabItem.DataTemplateType == typeof(TabItemAddView))
                {
                    TabItemContentView.Content = _addView.Value;
                    TabBar.BackgroundColor = _tabBarWhite;
                    return;
                }

                if (tabItem.DataTemplateType == typeof(TabItemInboxView))
                {
                    TabItemContentView.Content = _inboxView.Value;
                    TabBar.BackgroundColor = _tabBarWhite;
                    return;
                }

                if (tabItem.DataTemplateType == typeof(TabItemMeView))
                {
                    TabItemContentView.Content = _meView.Value;
                    TabBar.BackgroundColor = _tabBarWhite;
                    return;
                }
            }
        }
    }
}
