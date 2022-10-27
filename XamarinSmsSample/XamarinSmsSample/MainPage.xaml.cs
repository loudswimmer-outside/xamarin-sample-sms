using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace XamarinSmsSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void ReadSmsBtn_Clicked(object sender, EventArgs e)
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Sms>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Sms>();
            }

            if (status == PermissionStatus.Granted)
            {
                var service = DependencyService.Get<Services.ISmsService>();

                var ret = service?.ReadSms("") ?? default;
                if (ret != default)
                {
                    list.ItemsSource = ret;
                }
                else
                {
                    // 오류
                }
            }
            else
            {
                // 오류
            }
        }
    }
}
