using System;
using MvvmHelpers;
using TikTokClone.Models;

namespace TikTokClone.ViewModels
{
    public class TabItemHomeViewModel
    {
        public ObservableRangeCollection<Video> Videos { get; private set; }

        public TabItemHomeViewModel()
        {
            var linkExemplo = "https://v16m.tiktokcdn.com/5a1c25ea2ab48981a704a0d993fc4a5f/5f322faa/video/tos/useast2a/tos-useast2a-ve-0068c004/9fa3da104133427b84799ab69672417d/?a=1233&br=1636&bt=818&cr=0&cs=0&dr=0&ds=3&er=&l=2020080905420201019019104736013EA8&lr=tiktok_m&mime_type=video_mp4&qs=0&rc=ajk0ZW1nZDM8czMzNTczM0ApPGU6OjZlaDs8NzQ6NmhoNGdyaG9fbXBuZmtfLS1iMTZzczEvMTBeMTZhXmFfMGAtLzY6Yw%3D%3D&vl=&vr=";
            Videos = new ObservableRangeCollection<Video>();
            Videos.Add(new Video("#ff0000", linkExemplo));
            Videos.Add(new Video("#00ff00", linkExemplo));
            Videos.Add(new Video("#0000ff", linkExemplo));
        }
    }
}
