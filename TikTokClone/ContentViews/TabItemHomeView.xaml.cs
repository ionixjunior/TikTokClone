using System.Linq;
using System.Collections.Generic;
using TikTokClone.ViewModels;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;
using System.Threading;
using TikTokClone.Controls;

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
                if (CarouselViewVideos.VisibleViews[index] is View view)
                {
                    if (view.FindByName<MediaElement>("Video") is MediaElement videoOutOfBounds)
                    {
                        videoOutOfBounds.Stop();
                        videoOutOfBounds.IsLooping = false;
                    }

                    if (view.FindByName<Image>("MusicCipher1") is Image cipher1 &&
                        view.FindByName<Image>("MusicCipher2") is Image cipher2 &&
                        view.FindByName<Image>("MusicCipher3") is Image cipher3)
                    {
                        _cancellationTokenSourceOfTaskCipherAnimations?.Cancel();
                        _cancellationTokenSourceOfTaskCipherAnimations?.Dispose();
                        _cancellationTokenSourceOfTaskCipherAnimations = null;

                        ResetCipherState(cipher1);
                        ResetCipherState(cipher2);
                        ResetCipherState(cipher3);
                    }

                    if (view.FindByName<MarqueeLabel>("AnimatedSongName") is MarqueeLabel songName)
                        songName.StopAnimation();
                }
            }
        }

        private CancellationTokenSource _cancellationTokenSourceOfTaskCipherAnimations;

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
                    _cancellationTokenSourceOfTaskCipherAnimations = new CancellationTokenSource();
                    Task.Run(async () => await StartCipherAnimations(cipher1, cipher2, cipher3, _cancellationTokenSourceOfTaskCipherAnimations.Token));
                }
            }
        }

        private async Task StartCipherAnimations(Image cipher1, Image cipher2, Image cipher3, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            await Task.WhenAny(
                AnimateCipher(cipher1, TimeSpan.Zero, token),
                AnimateCipher(cipher2, TimeSpan.FromMilliseconds(900), token),
                AnimateCipher(cipher3, TimeSpan.FromMilliseconds(1800), token)
            );

            token.ThrowIfCancellationRequested();
            await Task.Delay(700);

            await StartCipherAnimations(cipher1, cipher2, cipher3, token);
        }

        private async Task AnimateCipher(Image image, TimeSpan delayToAnimate, CancellationToken token)
        {
            await Task.Delay(delayToAnimate);
            token.ThrowIfCancellationRequested();

            ResetCipherState(image);

            await Task.WhenAll(
                MoveCipherAsync(image),
                ScaleCipherAsync(image),
                FadeCipherAsync(image)
            );
        }

        private void ResetCipherState(Image image)
        {
            image.TranslationX = 0;
            image.TranslationY = 0;
            image.Scale = 1;
            image.Opacity = 0;
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
