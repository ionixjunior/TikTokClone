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
        }
    }
}
