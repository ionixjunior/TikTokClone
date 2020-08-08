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
            if (IsScrollUp(args))
            {
                if (CarouselViewVideos.VisibleViews.FirstOrDefault()?.FindByName<MediaElement>("Video") is MediaElement videoUp)
                    videoUp.Stop();

                if (CarouselViewVideos.VisibleViews.LastOrDefault()?.FindByName<MediaElement>("Video") is MediaElement videoDown)
                    videoDown.Play();

                return;
            }

            if (IsScrollDown(args))
            {
                if (CarouselViewVideos.VisibleViews.FirstOrDefault()?.FindByName<MediaElement>("Video") is MediaElement videoUp)
                    videoUp.Stop();

                if (CarouselViewVideos.VisibleViews.LastOrDefault()?.FindByName<MediaElement>("Video") is MediaElement videoDown)
                    videoDown.Play();

                return;
            }
        }

        private bool IsScrollUp(PositionChangedEventArgs args) => args.PreviousPosition < args.CurrentPosition;
        private bool IsScrollDown(PositionChangedEventArgs args) => !IsScrollUp(args);
    }
}
