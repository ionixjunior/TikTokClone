using System;
using Xamarin.Forms;

namespace TikTokClone.Models
{
    public class TabItem
    {
        public string Name { get; private set; }
        public Type DataTemplateType { get; private set; }

        public TabItem(string name, Type dataTemplateType)
        {
            Name = name;
            DataTemplateType = dataTemplateType;
        }
    }
}
