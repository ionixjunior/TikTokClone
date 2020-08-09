using System.Linq;
using System.Collections.Generic;
using TikTokClone.ViewModels;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace TikTokClone.ContentViews
{
    public partial class TabItemHomeView : ContentView
    {
        public TabItemHomeView()
        {
            InitializeComponent();
            BindingContext = new TabItemHomeViewModel();
        }

        private void OnCurrentItemChanged(object sender, CurrentItemChangedEventArgs args)
        {
            if (IsFirstVideoToAppear(args))
                PlayVideoInOfBounds();
        }

        private bool IsFirstVideoToAppear(CurrentItemChangedEventArgs args) => args.PreviousItem is null;

        private void OnPositionChanged(object sender, PositionChangedEventArgs args)
        {
            StopVideoOutOfBounds();
            PlayVideoInOfBounds();
        }

        private void StopVideoOutOfBounds()
        {
            for (var index = 0; index < CarouselViewVideos.VisibleViews.Count - 1; index++)
            {
                if (CarouselViewVideos.VisibleViews[index]?.FindByName<MediaElement>("Video") is MediaElement videoOutOfBounds)
                {
                    videoOutOfBounds.Stop();
                    videoOutOfBounds.IsLooping = false;
                }
            }
        }

        public void PlayVideoInOfBounds()
        {
            if (CarouselViewVideos.VisibleViews.LastOrDefault()?.FindByName<MediaElement>("Video") is MediaElement videoInOfBounds)
            {
                videoInOfBounds.Play();
                videoInOfBounds.IsLooping = true;
            }

            if (CarouselViewVideos.VisibleViews.LastOrDefault()?.FindByName<Image>("MusicCipher1") is Image imageCipher1)
            {
                Task.Run(() =>
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await imageCipher1.TranslateTo(-30, -10, 500);
                        await imageCipher1.TranslateTo(-45, -25, 500);
                        await imageCipher1.TranslateTo(-50, -50, 500);
                        await imageCipher1.TranslateTo(-60, -80, 500);
                    });
                });
            }
        }
    }
}
