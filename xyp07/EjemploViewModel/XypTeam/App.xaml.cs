using Xamarin.Forms;
using XypTeam.View;

namespace XypTeam
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

			var content = new BasePage();
            MainPage = content;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
