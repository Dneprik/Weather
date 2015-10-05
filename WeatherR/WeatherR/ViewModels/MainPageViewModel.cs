using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WeatherR.Annotations;
using WeatherR.Weather;

namespace WeatherR.ViewModels
{
    public class MainPageViewModel: INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            SetNewCity();
        }
        readonly IWeatherService _weatherService = new WeatherService();

        public ObservableCollection<string> Cities { get; set; } 

        private double _temperatureToday;
        private string _city;
        private int _selectedCityIndex;


        #region Realization of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private void SetNewCity(int selectedCityIndex=0)
        {
            InitializeCityCollection();
            SelectedCityIndex = selectedCityIndex;
            City = Cities[selectedCityIndex];
            SetTemperatureToday();
        }


        public int SelectedCityIndex
        {
            get { return _selectedCityIndex;
                
            }
            set
            {
                if (value == _selectedCityIndex) return;
                _selectedCityIndex = value;
                SetNewCity(_selectedCityIndex);
                OnPropertyChanged();
            }
        }

        public double TemperatureToday
        {
            get { return _temperatureToday; }
            set
            {
                if (value == _temperatureToday) return;
                _temperatureToday = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                if (value == _city) return;
                _city = value;
                OnPropertyChanged();
            }
        }




        async private void SetTemperatureToday()
        {
            TemperatureToday = await _weatherService.GetTemperatureTodayAsync(City);
        }

        private void InitializeCityCollection()
        {
            Cities = new ObservableCollection<string>();
            Cities.Add("Dnipropetrovsk");
            Cities.Add("Kiev");
            Cities.Add("Lviv");
            Cities.Add("Lodon");
            Cities.Add("Paris");

        }


    }
}
