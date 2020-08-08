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
                new TabItem("Home", "tab_home_selected", 26, 26, typeof(TabItemHomeView)),
                new TabItem("Discover", "tab_discover_init", 26, 26, typeof(TabItemDiscoverView)),
                new TabItem(string.Empty, "tab_add_init", 55, 50, typeof(TabItemAddView)),
                new TabItem("Inbox", "tab_inbox_init", 26, 26, typeof(TabItemInboxView)),
                new TabItem("Me", "tab_me_init", 26, 26, typeof(TabItemMeView))
            };
        }
    }
}
