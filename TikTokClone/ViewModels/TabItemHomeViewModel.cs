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
            Videos = new ObservableRangeCollection<Video>();
            Videos.Add(new Video("#ff0000"));
            Videos.Add(new Video("#00ff00"));
            Videos.Add(new Video("#0000ff"));
        }
    }
}
