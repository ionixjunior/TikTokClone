using System;
using Xamarin.Forms;

namespace TikTokClone.Controls
{
    public class MarqueeLabel : Label
    {
        public static readonly BindableProperty AnimatedTextProperty =
            BindableProperty.Create(
                nameof(AnimatedText),
                typeof(string),
                typeof(MarqueeLabel),
                string.Empty,
                BindingMode.OneWay,
                propertyChanged: OnAnimatedTextChanged
            );

        public string AnimatedText
        {
            get { return (string)GetValue(AnimatedTextProperty); }
            set { SetValue(AnimatedTextProperty, value); }
        }

        private static void OnAnimatedTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            System.Diagnostics.Debug.WriteLine($"Texto alterado: {newValue}");

            if (bindable is MarqueeLabel label)
                label.Text = (string)newValue;
        }

        public MarqueeLabel()
        {
        }
    }
}
