using System.Linq;
using System.Collections.Generic;
using TikTokClone.ViewModels;
using Xamarin.Forms;
using System.Threading.Tasks;
using System;
using System.Threading;
using TikTokClone.Controls;
using MvvmHelpers;

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

        public void StopVideoOutOfBounds()
        {
            _cancellationTokenSourceOfAnimations?.Cancel();
            _cancellationTokenSourceOfAnimations?.Dispose();
            _cancellationTokenSourceOfAnimations = null;

            Task.Run(() =>
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
                            ResetCipherState(cipher1);
                            ResetCipherState(cipher2);
                            ResetCipherState(cipher3);
                        }

                        if (view.FindByName<MarqueeLabel>("AnimatedSongName") is MarqueeLabel songName)
                            songName.RestoreOriginalText();

                        if (view.FindByName<Grid>("SongDisc") is Grid grid)
                            ResetSongDiscRotatePosition(grid);
                    }
                }
            }).SafeFireAndForget(ExceptionFromTask);
        }

        private CancellationTokenSource _cancellationTokenSourceOfAnimations;
        
        public void PlayVideoInOfBounds()
        {
            _cancellationTokenSourceOfAnimations = new CancellationTokenSource();

            if (CarouselViewVideos.VisibleViews.LastOrDefault() is View view)
            {
                var tasks = new List<Task>();

                if (view.FindByName<MediaElement>("Video") is MediaElement videoInOfBounds)
                    tasks.Add(PlayVideo(videoInOfBounds));

                if (view.FindByName<Image>("MusicCipher1") is Image cipher1 &&
                    view.FindByName<Image>("MusicCipher2") is Image cipher2 &&
                    view.FindByName<Image>("MusicCipher3") is Image cipher3)
                {
                    tasks.Add(StartCipherAnimations(cipher1, cipher2, cipher3, _cancellationTokenSourceOfAnimations.Token));
                }

                if (view.FindByName<MarqueeLabel>("AnimatedSongName") is MarqueeLabel songName)
                    tasks.Add(songName.StartAnimationAsync(_cancellationTokenSourceOfAnimations.Token));

                if (view.FindByName<Grid>("SongDisc") is Grid grid)
                    tasks.Add(StartSongDiscRotationAsync(grid, _cancellationTokenSourceOfAnimations.Token));

                Task.WhenAny(tasks.ToArray())
                    .SafeFireAndForget(ExceptionFromTask);
            }
        }

        private void ExceptionFromTask(Exception exception)
        {
            System.Diagnostics.Debug.WriteLine(exception.Message);
        }

        private Task PlayVideo(MediaElement video)
        {
            video.Play();
            video.IsLooping = true;
            return Task.FromResult(true);
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
            image.Scale = 0.3;
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

        private async Task StartSongDiscRotationAsync(View view, CancellationToken token)
        {
            token.ThrowIfCancellationRequested();

            var totalAnimationTime = 7000;
            var totalCycles = 10;
            var positionToMoveInEachCycle = 360 / totalCycles;
            var animationTimeInEachCycle = (uint) (totalAnimationTime / totalCycles);

            for (var cycle = 1; cycle <= totalCycles; cycle++)
            {
                token.ThrowIfCancellationRequested();

                await view.RotateTo(positionToMoveInEachCycle * cycle, animationTimeInEachCycle);
            }

            ResetSongDiscRotatePosition(view);
            await StartSongDiscRotationAsync(view, token);
        }

        private void ResetSongDiscRotatePosition(View view) => view.Rotation = 0;
    }
}
