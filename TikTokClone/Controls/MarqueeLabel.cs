using System;
using System.Text;
using System.Threading.Tasks;
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
            {
                label.Text = (string)newValue;
                label.StartAnimationAsync();
            }
        }

        private int _totalLetters = 0;

        private async Task StartAnimationAsync()
        {
            _totalLetters = Text.Length;
            await MoveLettersAsync();
        }

        private async Task MoveLettersAsync()
        {
            for (var letterIndex = 0; letterIndex < _totalLetters; letterIndex++)
            {
                var charsToRemove = GetFirstLetterToRemove();
                System.Diagnostics.Debug.WriteLine($"charsToRemove: {charsToRemove}");

                var isFirstLetter = letterIndex == 0;
                var textWithRemovedLetterAtEnd = AddLetterToTheEnd(charsToRemove, isFirstLetter);
                System.Diagnostics.Debug.WriteLine($"textWithRemovedLetterAtEnd: {textWithRemovedLetterAtEnd}");

                var newText = RemoveFirstLetter(textWithRemovedLetterAtEnd);
                System.Diagnostics.Debug.WriteLine($"newText: {newText}");

                Text = newText;
                await Task.Delay(100);
            }

            for (var _ = 0; _ < SpaceCharacters.Length; _++)
            {
                var charsToRemove = GetFirstLetterToRemove();
                var isFirstLetter = false;
                var textWithRemovedLetterAtEnd = AddLetterToTheEnd(charsToRemove, isFirstLetter);
                var newText = RemoveFirstLetter(textWithRemovedLetterAtEnd);

                Text = newText;
                await Task.Delay(100);
            }

            await MoveLettersAsync();
        }

        private string GetFirstLetterToRemove() => Text.Substring(0, 1);

        private const string SpaceCharacters = "    ";

        private string AddLetterToTheEnd(string letter, bool isFirstLetter)
        {
            var stringBuilder = new StringBuilder();

            stringBuilder.Append(Text);

            if (isFirstLetter)
                stringBuilder.Append(SpaceCharacters);

            stringBuilder.Append(letter);

            return stringBuilder.ToString();
        }

        private string RemoveFirstLetter(string text) => text.Substring(1);

        public MarqueeLabel()
        {
        }
    }
}
