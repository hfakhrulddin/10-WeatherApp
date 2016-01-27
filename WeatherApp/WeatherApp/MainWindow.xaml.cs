using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WeatherApp.Core;
using WeatherApp.Core.Domain;
using WeatherApp.Core.Services;



namespace WeatherApp
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            string zip;
            zip = textBox.Text;
            var result = WeatherService.GetWeatherFor(zip);
            label2.Content = result.weather;
            label3.Content = "Temperature: " + result.temp_f + "°F" + " (" + result.temp_c + "°C)";
            label4.Content = "Feels Like: " + result.feelslike_string;
            label5.Content = "Wind: " + result.wind_string;
            label6.Content = "Wind Direction: " + result.wind_dir;
            label8.Content = "Last Updated on: " + result.observation_time;
            label9.Content = "Humidity: " + result.relative_humidity;
            label10.Content = "Visibility: " + result.visibility_mi + " miles";
            label11.Content = "UV: " + result.UV;
            label12.Content = "Precipitation: " + result.precip_today_string + " in (mm)";
            label.Content = result.display_location.full;
            label1.Content = "Latitude / Longitude: " + result.display_location.latitude + " / " + result.display_location.longitude;
            label7.Content = "Elevation: " + result.display_location.elevation;




            string fileUrl = $"{Environment.CurrentDirectory}/{result.icon}.gif";
            if (!File.Exists(fileUrl))
            {
                using (var webClient = new WebClient())
                {
                    byte[] bytes = webClient.DownloadData(result.icon_url);

                    File.WriteAllBytes(fileUrl, bytes);
                }
            }

            BitmapImage image = new BitmapImage(new Uri(fileUrl));
            
            image2.Source = image;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
