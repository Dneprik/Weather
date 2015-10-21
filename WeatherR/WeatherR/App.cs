using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherR.Services.Location;
using WeatherR.Views;
using Xamarin.Forms;

namespace WeatherR
{
    public class App : Application
    {
        public App()
        {
            // Old weather design
            //MainPage = new MainPage();
            //Weather on Map
            MainPage = new MapPage();
          //  Location l = new Location();

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
