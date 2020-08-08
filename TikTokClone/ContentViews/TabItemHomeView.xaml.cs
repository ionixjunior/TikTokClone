using System.Linq;
using System.Collections.Generic;
using TikTokClone.ViewModels;
using Xamarin.Forms;

namespace TikTokClone.ContentViews
{
    public partial class TabItemHomeView : ContentView
    {
        public TabItemHomeView()
        {
            InitializeComponent();
            BindingContext = new TabItemHomeViewModel();
        }

        private void OnPositionChanged(object sender, PositionChangedEventArgs args)
        {
            StopVideoOutOfBounds();
            PlayVideoInOfBounds();
        }

        private void StopVideoOutOfBounds()
        {
            if (CarouselViewVideos.VisibleViews.FirstOrDefault()?.FindByName<MediaElement>("Video") is MediaElement videoOutOfBounds)
            {
                videoOutOfBounds.Stop();
                videoOutOfBounds.IsLooping = false;
            }
        }

        private void PlayVideoInOfBounds()
        {
            if (CarouselViewVideos.VisibleViews.LastOrDefault()?.FindByName<MediaElement>("Video") is MediaElement videoInOfBounds)
            {
                videoInOfBounds.Play();
                videoInOfBounds.IsLooping = true;
            }
        }
    }
}
