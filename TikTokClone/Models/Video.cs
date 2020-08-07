using System;
namespace TikTokClone.Models
{
    public class Video
    {
        public string Color { get; private set; }
        public string Link { get; private set; }

        public Video(string color, string link)
        {
            Color = color;
            Link = link;
        }
    }
}
