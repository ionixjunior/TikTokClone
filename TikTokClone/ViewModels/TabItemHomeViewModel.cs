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
            var linkExemplo = "https://v16m.tiktokcdn.com/fb5f45461ca8ae8e24b7cbe864ea8747/5f321a35/video/tos/useast2a/tos-useast2a-ve-0068/7fcc89a31a364ca9a651169fa1ba9d49/?a=1233&br=3108&bt=1554&cr=0&cs=0&dr=0&ds=3&er=&l=202008090410290101901760400B014510&lr=tiktok_m&mime_type=video_mp4&qs=0&rc=M3NvcDc0eWhzcDMzZjczM0ApOzo3NDQ1Nzs6NzU0NDM2O2cyaHFuNnJmbDRfLS01MTZzczZjNDVfNi02NC8xXl9jMF86Yw%3D%3D&vl=&vr=";
            Videos = new ObservableRangeCollection<Video>();
            Videos.Add(new Video("#ff0000", linkExemplo));
            Videos.Add(new Video("#00ff00", linkExemplo));
            Videos.Add(new Video("#0000ff", linkExemplo));
        }
    }
}
