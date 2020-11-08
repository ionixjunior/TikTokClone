using TikTokClone.iOS.Renderers;
using Xamarin.Forms;
using MediaElement = Xamarin.CommunityToolkit.UI.Views.MediaElement;
using MediaElementRenderer = Xamarin.CommunityToolkit.UI.Views.MediaElementRenderer;

[assembly: ExportRenderer(typeof(MediaElement), typeof(CustomMediaElementRenderer))]
namespace TikTokClone.iOS.Renderers
{
	public class CustomMediaElementRenderer : MediaElementRenderer
	{
        protected override void Dispose(bool disposing)
        {
            if (rateObserver != null)
            {
                avPlayerViewController?.Player?.RemoveObserver(rateObserver, "rate");
                rateObserver.Dispose();
                rateObserver = null;
            }

            base.Dispose(disposing);
        }
    }
}