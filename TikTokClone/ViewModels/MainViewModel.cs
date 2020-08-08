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
                new TabItem("Home", "tab_home_selected", typeof(TabItemHomeView)),
                new TabItem("Discover", "tab_discover_init", typeof(TabItemDiscoverView)),
                new TabItem("Add", "tab_add_init", typeof(TabItemAddView)),
                new TabItem("Inbox", "tab_inbox_init", typeof(TabItemInboxView)),
                new TabItem("Me", "tab_me_init", typeof(TabItemMeView))
            };
        }
    }
}
