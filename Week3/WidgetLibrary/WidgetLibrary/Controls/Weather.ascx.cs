using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WidgetLibrary.Data;

namespace WidgetLibrary.Controls
{
    public partial class Weather : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                var WeatherList = WeatherData.CallApi(Zipcode.Text);
                if (WeatherList == null)
                {
                    ErrorMessage.Text = "Error, a problem occured.";
                    Location.Text = "";
                    Temp.Text = "";
                    Humidity.Text = "";
                    TempMax.Text = "";
                    TempMin.Text = "";
                    Pressure.Text = "";
                    WindSpeed.Text = "";
                }
                else
                {
                    Location.Text = "Location: " + WeatherList["Location Name"];
                    Temp.Text = "Temperature: " + WeatherList["Temperature"];
                    Humidity.Text = "Humidity: " + WeatherList["Humidity"];
                    TempMax.Text = "Temperature Max: " + WeatherList["Temperature Max"];
                    TempMin.Text = "Temperature Min: " + WeatherList["Temperature Min"];
                    Pressure.Text = "Pressure: " + WeatherList["Pressure"];
                    WindSpeed.Text = "Windspeed: " + WeatherList["Wind Speed"];
                }
                
            }
        }
    }
}