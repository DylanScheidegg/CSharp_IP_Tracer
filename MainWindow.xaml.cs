using RestSharp;
using System.Windows;
using System.Collections;
using Newtonsoft.Json;

namespace IP_Tracer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// https://www.youtube.com/watch?v=3g9uVRUmt0U
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            FetchCurrentIPLocation(etIPAddress.Text);
        }

        private string FetchCurrentIPLocation(string strIP)
        {
            string strIPLocation = string.Empty;

            var client = new RestClient("https://ipapi.co/" + strIP + "/json/");
            var request = new RestRequest()
            {
                Method = Method.GET
            };

            var response = client.Execute(request);

            //strIPLocation = response.Content;

            var dictionary = JsonConvert.DeserializeObject<IDictionary>(response.Content);

            foreach (var key in dictionary.Keys)
            {
                if (key.ToString() == "org")
                {
                    etISP.Text = dictionary[key].ToString();
                } 
                else if (key.ToString() == "city") {
                    etCity.Text = dictionary[key].ToString();
                }
                else if (key.ToString() == "postal")
                {
                    etPostal.Text = dictionary[key].ToString();
                }
                else if (key.ToString() == "region")
                {
                    etRegion.Text = dictionary[key].ToString();
                }
                else if (key.ToString() == "region_code")
                {
                    etRegionCode.Text = dictionary[key].ToString();
                }
                else if (key.ToString() == "country")
                {
                    etCountry.Text = dictionary[key].ToString();
                }
                else if (key.ToString() == "country_name")
                {
                    etCountryName.Text = dictionary[key].ToString();
                }
                else if (key.ToString() == "latitude")
                {
                    etLatitude.Text = dictionary[key].ToString();
                }
                else if (key.ToString() == "longitude")
                {
                    etLongitude.Text = dictionary[key].ToString();
                }
                else if (key.ToString() == "timezone")
                {
                    etTimezone.Text = dictionary[key].ToString();
                }
                else if (key.ToString() == "asn")
                {
                    etASN.Text = dictionary[key].ToString();
                }
                else if (key.ToString() == "reserved")
                {
                    MessageBox.Show("IP Reserved: " + dictionary[key].ToString(), "Error");
                }
            }

            return strIPLocation;
        }

    }
}
