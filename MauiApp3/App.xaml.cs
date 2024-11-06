using MauiApp3.Components;

namespace MauiApp3
{
    public partial class App : Application
    {
        public App()
        {

           
            MainPage = new NavigationPage(new HomePage());

        }
    }
}
