using Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Client.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ControlPage : ContentPage
    {
        private AndroidClient client;
        public ControlPage()
        {
            InitializeComponent();
        }

        private void PowerOff(object sender, EventArgs e)
        {
            client = new AndroidClient(AdressServer.Text, PortServer.Text);
            //new Thread(() => DisplayAlert("Уведомление", client.SendRequest("/c shutdown -s -t 6000"),"OK")).Start();
            new Thread(() => client.SendRequest("/c shutdown -s -t 6000")).Start();



        }

        private void RebootPC(object sender, EventArgs e)
        {
            client = new AndroidClient(AdressServer.Text, PortServer.Text);
            //new Thread(() => DisplayAlert("Уведомление", client.SendRequest("/c shutdown -r -t 6000"), "OK")).Start();
            new Thread(() => client.SendRequest("/c shutdown -r -t 6000")).Start();
        }

        private void CancelOperation(object sender, EventArgs e)
        {
            client = new AndroidClient(AdressServer.Text, PortServer.Text);
            //new Thread(() => DisplayAlert("Уведомление", client.SendRequest("/c shutdown -a"), "OK")).Start();
            new Thread(() => client.SendRequest("/c shutdown -a")).Start();
        }
    }
}