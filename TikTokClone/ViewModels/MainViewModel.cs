using System.Collections.Generic;
using MvvmHelpers;
using TikTokClone.ContentViews;
using TikTokClone.Models;

namespace TikTokClone.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
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
