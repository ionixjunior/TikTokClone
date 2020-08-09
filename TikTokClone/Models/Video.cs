using System;
namespace TikTokClone.Models
{
    public class Video
    {
        public string Link { get; private set; }

        public Video(string link)
        {
            Link = link;
        }
    }
}
