using Xamarin.Forms;

namespace XAM320
{
    public class App : Application
    {
        public App() => MainPage = new NavigationPage(new PersonPage());
    }
}
