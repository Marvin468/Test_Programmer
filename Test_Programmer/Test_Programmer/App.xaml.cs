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

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
