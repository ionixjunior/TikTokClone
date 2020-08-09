using System;
namespace TikTokClone.Models
{
    public class Video
    {
        public string Link { get; set; }
        public string Description { get; set; }
        public string AccountName { get; set; }
        public string AccountAvatar { get; set; }
        public bool IsVerifiedAccount { get; set; }
        public string SongName { get; set; }
        public string SongAvatar { get; set; }
        public int Likes { get; set; }
        public int Messages { get; set; }
        public int Shares { get; set; }
    }
}
