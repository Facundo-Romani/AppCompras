using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppCompras.Vistas;

namespace AppCompras
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new Agregarcompra());
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
