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
            if (CarouselViewVideos.VisibleViews.LastOrDefault() is View view)
            {
                if (view.FindByName<MediaElement>("Video") is MediaElement videoInOfBounds)
                {
                    videoInOfBounds.Play();
                    videoInOfBounds.IsLooping = true;
                }

                if (view.FindByName<Image>("MusicCipher1") is Image cipher1 &&
                    view.FindByName<Image>("MusicCipher2") is Image cipher2 &&
                    view.FindByName<Image>("MusicCipher3") is Image cipher3)
                {
                    Task.Run(() =>
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            await Task.WhenAll(
                                MoveCipherAsync(cipher1),
                                ScaleCipherAsync(cipher1),
                                FadeCipherAsync(cipher1)
                            );
                        });
                    });
                }
            }
        }

        private async Task MoveCipherAsync(Image image)
        {
            await image.TranslateTo(-30, -10, 500);
            await image.TranslateTo(-45, -25, 500);
            await image.TranslateTo(-50, -50, 500);
            await image.TranslateTo(-60, -80, 500);
        }

        private async Task ScaleCipherAsync(Image image)
        {
            await image.ScaleTo(1.8, 2000);
        }

        private async Task FadeCipherAsync(Image image)
        {
            await image.FadeTo(1, 1000);
            await image.FadeTo(0, 1000);
        }
    }
}
