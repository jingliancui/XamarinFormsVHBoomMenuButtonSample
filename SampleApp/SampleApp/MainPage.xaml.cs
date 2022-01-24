using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleApp
{
    public partial class MainPage : ContentPage
    {
        public const string BoomIndex = "BoomIndex";

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<object, int>(this, BoomIndex, async (s, e) =>
             {
                 await DisplayAlert("标题", $"点击了第{e}个", "OK");
             });
        }
    }
}
