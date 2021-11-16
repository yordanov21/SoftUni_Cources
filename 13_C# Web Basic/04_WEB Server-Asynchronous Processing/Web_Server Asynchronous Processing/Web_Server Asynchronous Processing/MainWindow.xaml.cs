using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
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

namespace Web_Server_Asynchronous_Processing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public object ShowImage { get; private set; }

        //event handler
        private async void Button_Click(object sender, RoutedEventArgs e) //async e ot Tack po princip te vrushtat Tack, void v sluchaq se pozvolqva, samo kgato imame event handler (v sluchaq butona)
        {
            //ako napishem await otpred na showImageAsync shte zabavim operaciqta, zashtoto kazvame izchakai da svurshi i togawa prodylvi napred s drugiq
           ShowImageAsync(Image1, "https://http.cat/100");
           ShowImageAsync(Image2, "https://http.cat/200");
           ShowImageAsync(Image3, "https://http.cat/301");
           ShowImageAsync(Image4, "https://http.cat/404");
           ShowImageAsync(Image5, "https://http.cat/403");
           ShowImageAsync(Image6, "https://http.cat/307");
           ShowImageAsync(Image7, "https://http.cat/501");
           ShowImageAsync(Image8, "https://http.cat/500");
        }

        private async Task ShowImageAsync(Image image, string url)
        {
            HttpClient httpClient = new HttpClient();
            var response =await httpClient.GetAsync(url);
          //  var response = httpClient.GetAsync(url).GetAwaiter().GetResult();
            byte[] imageBytes =await response.Content.ReadAsByteArrayAsync();
          //  byte[] imageBytes = response.Content.ReadAsByteArrayAsync().GetAwaiter().GetResult();

            image.Source =await Task.Run(() => LoadImage(imageBytes));

        }

        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
    }
}
