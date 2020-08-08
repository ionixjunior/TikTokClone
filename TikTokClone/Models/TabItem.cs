using System;
using Xamarin.Forms;

namespace TikTokClone.Models
{
    public class TabItem
    {
        public string Name { get; private set; }
        public string Icon { get; set; }
        public Type DataTemplateType { get; private set; }

        public TabItem(string name, string icon, Type dataTemplateType)
        {
            Name = name;
            Icon = icon;
            DataTemplateType = dataTemplateType;
        }
    }
}
