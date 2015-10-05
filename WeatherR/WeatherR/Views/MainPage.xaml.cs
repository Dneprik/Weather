using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherR.ViewModels;
using WeatherR.Weather;
using Xamarin.Forms;

namespace WeatherR.Views
{
    public partial class MainPage : ContentPage
    {
         public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel();
        }
    }
}
