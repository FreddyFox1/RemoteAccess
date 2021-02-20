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
            new Thread(() => client.SendRequest($"shutdown -s -t {TimeSlider.Value}")).Start();
        }

        private void RebootPC(object sender, EventArgs e)
        {
            client = new AndroidClient(AdressServer.Text, PortServer.Text);
            new Thread(() => client.SendRequest($"shutdown -r -t {TimeSlider.Value}")).Start();
        }

        private void CancelOperation(object sender, EventArgs e)
        {
            client = new AndroidClient(AdressServer.Text, PortServer.Text);
            new Thread(() => client.SendRequest("shutdown -a")).Start();
        }
    }
}