using System;
namespace TikTokClone.Models
{
    public class Video
    {
        public string Color { get; private set; }

        public Video(string color)
        {
            Color = color;
        }
    }
}
