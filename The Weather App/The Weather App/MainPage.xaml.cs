namespace The_Weather_App
{
    public partial class MainPage : ContentPage
    {
        RestService _restService;
        public MainPage()
        {
            InitializeComponent();
            _restService = new RestService();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        async void  OnGetWeatherButtonClicked(object sender,EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_cityEntry.Text)) 
            {
                WeatherData weatherData = await _restService.GetWeatherData(GenerateRequestURI(Constants.OpenWeatherMapEndpoint));

                BindingContext = weatherData;
            }
        }

        string GenerateRequestURI(string endPoint)
        {
            string requestURI = endPoint;
            requestURI += $"?q={_cityEntry.Text}";
            requestURI += "&units=imperial";
            requestURI += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestURI;

        }
    }
}