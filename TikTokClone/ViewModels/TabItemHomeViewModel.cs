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
            var linkExemplo = "https://v16m.tiktokcdn.com/b1faabf5380fc11321846e43f49e3390/5f320550/video/tos/alisg/tos-alisg-pve-0037/c64d7e9367ad4dcd9d53181ab9375565/?a=1180&br=2106&bt=1053&cr=0&cs=0&dr=3&ds=3&er=&l=2020080902412001018907409218046FE8&lr=tiktok&mime_type=video_mp4&qs=0&rc=ang3OXE5aWd4dTMzaTgzM0ApMzU4NWk7Nzs6Nzo2PDtnZWdqYTJrY2NrMjJfLS0zLzRzczVfXjAzYWMxYl9hYzAzNC46Yw%3D%3D&vl=&vr=";
            Videos = new ObservableRangeCollection<Video>();
            Videos.Add(new Video("#ff0000", linkExemplo));
            Videos.Add(new Video("#00ff00", linkExemplo));
            Videos.Add(new Video("#0000ff", linkExemplo));
        }
    }
}
