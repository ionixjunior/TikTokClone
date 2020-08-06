using System;
using TikTokClone.ContentViews;
using TikTokClone.Models;
using Xamarin.Forms;

namespace TikTokClone.Templates
{
    public class TabItemDataTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate _home;
        private readonly DataTemplate _discover;
        private readonly DataTemplate _add;
        private readonly DataTemplate _inbox;
        private readonly DataTemplate _me;

        public TabItemDataTemplateSelector()
        {
            _home = new DataTemplate(typeof(TabItemHomeView));
            _discover = new DataTemplate(typeof(TabItemDiscoverView));
            _add = new DataTemplate(typeof(TabItemAddView));
            _inbox = new DataTemplate(typeof(TabItemInboxView));
            _me = new DataTemplate(typeof(TabItemMeView));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is TabItem tabItem)
            {
                if (tabItem.DataTemplateType == typeof(TabItemHomeView))
                    return _home;

                if (tabItem.DataTemplateType == typeof(TabItemDiscoverView))
                    return _discover;

                if (tabItem.DataTemplateType == typeof(TabItemAddView))
                    return _add;

                if (tabItem.DataTemplateType == typeof(TabItemInboxView))
                    return _inbox;

                if (tabItem.DataTemplateType == typeof(TabItemMeView))
                    return _me;
            }

            return null;
        }
    }
}
