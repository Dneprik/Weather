using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WeatherR.Annotations;
using WeatherR.Weather;

namespace WeatherR.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            SetNewCity();
            GetTimeNow();
        }

        public ObservableCollection<string> Cities { get; set; }

        private void SetNewCity(int selectedCityIndex = 0)
        {
            InitializeCityCollection();
            SelectedCityIndex = selectedCityIndex;
            City = Cities[selectedCityIndex];
            SetTemperatureToday();
            SetHumidityToday();
            SetWeatherStatusToday();
            SetWeatherDescriptionToday();
            SetWeatherIconLink();
            SetForecastTemperature();
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

        #region privateField

        private readonly IWeatherService _weatherService = new WeatherService();
        private string _city;
        private string _dateOfFirstForecastDay;
        private string _dateOfSecondForecastDay;
        private string _dateOfThirdForecastDay;
        private string _humidityToday;
        private int _selectedCityIndex;
        private string _temperatureOfFirstForecastDay;
        private string _temperatureOfSecondForecastDay;
        private string _temperatureOfThirtForecastDay;

        private string _temperatureToday;
        private string _timeNow;
        private string _weatherDescription;
        private string _weatherStatus;
        private string _wetherIconLink;

        #endregion

        #region SetWheatherMethods

        private async void SetWeatherStatusToday()
        {
            WeatherStatus = await _weatherService.GetWheatherStatusAsync(City);
        }

        private async void SetWeatherDescriptionToday()
        {
            WeatherDescription = await _weatherService.GetWheatherDescriptionAsync(City);
        }

        private async void SetWeatherIconLink()
        {
            WetherIconLink = await _weatherService.GetWheatherIconLinkAsync(City);
        }

        private async void SetTemperatureToday()
        {
            TemperatureToday = Math.Round(await _weatherService.GetTemperatureTodayAsync(City)) + "°C";
        }

        private async void SetHumidityToday()
        {
            HumidityToday = "Humidity " + Math.Round(await _weatherService.GetHumidityTodayAsync(City)) + "%";
        }

        private async void SetForecastTemperature()
        {
            var forecasList = await _weatherService.GetForecastTemperaturesAsync(City, 3);
            TemperatureOfFirstForecastDay = Math.Round(Convert.ToDouble(forecasList[0].Item2.ToString())) + "°C";
            TemperatureOfSecondForecastDay = Math.Round(Convert.ToDouble(forecasList[1].Item2.ToString())) + "°C";
            TemperatureOfThirtForecastDay = Math.Round(Convert.ToDouble(forecasList[2].Item2.ToString())) + "°C";
            DateOfFirstForecastDay = forecasList[0].Item1.DayOfWeek.ToString();
            DateOfSecondForecastDay = forecasList[1].Item1.DayOfWeek.ToString();
            DateOfThirdForecastDay = forecasList[2].Item1.DayOfWeek.ToString();
        }

        private async void GetTimeNow()
        {
            while (true)
            {
                await Task.Delay(1000);
                TimeNow = string.Format("{0:00}:{1:00}", DateTime.Now.Hour, DateTime.Now.Minute);
            }
        }

        #endregion

        #region INotifyProperties

        public int SelectedCityIndex
        {
            get { return _selectedCityIndex; }
            set
            {
                if (value == _selectedCityIndex) return;
                _selectedCityIndex = value;
                SetNewCity(_selectedCityIndex);
                OnPropertyChanged();
            }
        }


        public string DateOfFirstForecastDay
        {
            get { return _dateOfFirstForecastDay; }
            set
            {
                if (value == _dateOfFirstForecastDay) return;
                _dateOfFirstForecastDay = value;
                OnPropertyChanged();
            }
        }

        public string DateOfSecondForecastDay
        {
            get { return _dateOfSecondForecastDay; }
            set
            {
                if (value == _dateOfSecondForecastDay) return;
                _dateOfSecondForecastDay = value;
                OnPropertyChanged();
            }
        }

        public string DateOfThirdForecastDay
        {
            get { return _dateOfThirdForecastDay; }
            set
            {
                if (value == _dateOfThirdForecastDay) return;
                _dateOfThirdForecastDay = value;
                OnPropertyChanged();
            }
        }

        public string TemperatureOfFirstForecastDay
        {
            get { return _temperatureOfFirstForecastDay; }
            set
            {
                if (value == _temperatureOfFirstForecastDay) return;
                _temperatureOfFirstForecastDay = value;
                OnPropertyChanged();
            }
        }

        public string TemperatureOfSecondForecastDay
        {
            get { return _temperatureOfSecondForecastDay; }
            set
            {
                if (value == _temperatureOfSecondForecastDay) return;
                _temperatureOfSecondForecastDay = value;
                OnPropertyChanged();
            }
        }

        public string TemperatureOfThirtForecastDay
        {
            get { return _temperatureOfThirtForecastDay; }
            set
            {
                if (value == _temperatureOfThirtForecastDay) return;
                _temperatureOfThirtForecastDay = value;
                OnPropertyChanged();
            }
        }

        public string TemperatureToday
        {
            get { return _temperatureToday; }
            set
            {
                if (value == _temperatureToday) return;
                _temperatureToday = value;
                OnPropertyChanged();
            }
        }

        public string HumidityToday
        {
            get { return _humidityToday; }
            set
            {
                if (value == _humidityToday) return;
                _humidityToday = value;
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

        public string WeatherStatus
        {
            get { return _weatherStatus; }
            set
            {
                if (value == _weatherStatus) return;
                _weatherStatus = value;
                OnPropertyChanged();
            }
        }

        public string WeatherDescription
        {
            get { return _weatherDescription; }
            set
            {
                if (value == _weatherDescription) return;
                _weatherDescription = value;
                OnPropertyChanged();
            }
        }

        public string WetherIconLink
        {
            get { return _wetherIconLink; }
            set
            {
                if (value == _wetherIconLink) return;
                _wetherIconLink = value;
                OnPropertyChanged();
            }
        }

        public string TimeNow
        {
            get { return _timeNow; }
            set
            {
                if (value.Equals(_timeNow)) return;
                _timeNow = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Realization of INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}