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
            var linkExemplo = "https://v16m.tiktokcdn.com/3b928120abddc4435131a19ed2f7c0e5/5f320550/video/tos/useast2a/tos-useast2a-ve-0068c004/5b8cb85c601d4619b635961255179e4b/?a=1233&br=3858&bt=1929&cr=0&cs=0&dr=0&ds=3&er=&l=2020080902412001018907409218046FE8&lr=tiktok_m&mime_type=video_mp4&qs=0&rc=ajh3NXVnN2RvdDMzNjczM0ApOTM7Ozw6ZWU8NzU1Z2ZpOGczZV40cWRrbXBfLS0yMTZzc18vX14xLWA0YmE0L2NeXjA6Yw%3D%3D&vl=&vr=";
            Videos = new ObservableRangeCollection<Video>();
            Videos.Add(new Video("#ff0000", linkExemplo));
            Videos.Add(new Video("#00ff00", linkExemplo));
            Videos.Add(new Video("#0000ff", linkExemplo));
        }
    }
}
