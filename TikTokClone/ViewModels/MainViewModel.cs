using System;
using System.Collections.Generic;
using System.Windows.Input;
using MvvmHelpers;
using MvvmHelpers.Commands;
using TikTokClone.ContentViews;
using TikTokClone.Models;

namespace TikTokClone.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private TabItem _currentTab;
        public TabItem CurrentTab
        {
            get => _currentTab;
            set => SetProperty(ref _currentTab, value);
        }

        public List<TabItem> Tabs { get; private set; }
        public ICommand PositionChangedCommand { get; private set; }
        public ICommand TabTappedCommand { get; private set; }

        private Xamarin.Forms.Color _tabBackground;
        public Xamarin.Forms.Color TabBackground
        {
            get => _tabBackground;
            set => SetProperty(ref _tabBackground, value);
        }

        public MainViewModel()
        {
            Tabs = new List<TabItem>
            {
                new TabItem("Home", typeof(TabItemHomeView)),
                new TabItem("Discover", typeof(TabItemDiscoverView)),
                new TabItem("Add", typeof(TabItemAddView)),
                new TabItem("Inbox", typeof(TabItemInboxView)),
                new TabItem("Me", typeof(TabItemMeView))
            };

            TabBackground = Xamarin.Forms.Color.Transparent;

            PositionChangedCommand = new Command(PositionChanged);
            TabTappedCommand = new Command<TabItem>(TabTapped);
        }

        private void PositionChanged()
        {
            if (CurrentTab is null)
                return;

            if (CurrentTab.DataTemplateType == typeof(TabItemHomeView))
            {
                TabBackground = Xamarin.Forms.Color.Transparent;
                return;
            }

            TabBackground = Xamarin.Forms.Color.Yellow;
        }

        private void TabTapped(TabItem tabItem)
        {
            CurrentTab = tabItem;
        }
    }
}
