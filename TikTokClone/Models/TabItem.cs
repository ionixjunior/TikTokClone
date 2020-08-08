using System;
using Xamarin.Forms;

namespace TikTokClone.Models
{
    public class TabItem
    {
        public string Name { get; }
        public string Icon { get; }
        public double IconWidth { get; }
        public double IconHeight { get; }
        public Type DataTemplateType { get; private set; }

        public TabItem(string name, string icon, double iconWidth, double iconHeight, Type dataTemplateType)
        {
            Name = name;
            Icon = icon;
            IconWidth = iconWidth;
            IconHeight = iconHeight;
            DataTemplateType = dataTemplateType;
        }
    }
}
