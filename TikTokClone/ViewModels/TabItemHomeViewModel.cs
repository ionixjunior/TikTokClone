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
            var linkExemplo = "https://v16m.tiktokcdn.com/221e2077660762507810ff7c03194793/5f2f4d61/video/tos/useast2a/tos-useast2a-pve-0068/d86080fc80ff49fea2cf12e03bafda8a/?a=1233&br=2298&bt=1149&cr=0&cs=0&dr=0&ds=3&er=&l=2020080701120001018906603211655894&lr=tiktok_m&mime_type=video_mp4&qs=0&rc=am5mNjloZzM7dTMzOzczM0ApOzQ3OjhnZmQ4NzQ4PGQ2Omc0X2AtNmJraDJfLS01MTZzc2EuLjJeNDQtYTVhNDYwLy86Yw%3D%3D&vl=&vr=";
            Videos = new ObservableRangeCollection<Video>();
            Videos.Add(new Video("#ff0000", linkExemplo));
            Videos.Add(new Video("#00ff00", linkExemplo));
            Videos.Add(new Video("#0000ff", linkExemplo));
        }
    }
}
