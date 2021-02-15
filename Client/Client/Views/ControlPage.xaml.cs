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
            new Thread(() => client.SendRequest("Первое сообщение от Android клиента")).Start();
            DisplayAlert("Уведомление", "Сообщение доставлено", "ОK");
        }

        private void RebootPC(object sender, EventArgs e)
        {
            client = new AndroidClient(AdressServer.Text, PortServer.Text);
            new Thread(() =>
               client.SendRequest("Второе сообщение от Android клиента")).Start();
            DisplayAlert("Уведомление", "Сообщение доставлено", "ОK");
        }

    }
}