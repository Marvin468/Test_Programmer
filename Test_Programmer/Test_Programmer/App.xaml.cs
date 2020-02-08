using System;
using Test_Programmer.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test_Programmer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected async override void OnStart()
        {
            await GetData.GetEployees();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
