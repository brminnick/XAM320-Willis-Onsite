using Xamarin.Forms;

namespace XAM320
{
    public class BlankPage : ContentPage
    {
        public BlankPage()
        {
            Content = new Label
            {
                Text = "This Page is Blank",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
        }
    }
}
