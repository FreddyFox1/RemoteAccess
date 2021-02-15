using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Client.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "О программе";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://github.com/FreddyFox1/RemoteAccess"));
        }

        public ICommand OpenWebCommand { get; }
    }
}