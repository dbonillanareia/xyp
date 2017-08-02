using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace xyp04
{
    public class xyp04ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private double amount;
        public double Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged();
				OnPropertyChanged("Tax");
				OnPropertyChanged("Total");
            }
        }

        public double Tax => Amount * 22 / 100;

        public double Total => Tax + Amount;

        public ICommand LightCommand => new Command(() => MakeLight());

        private void MakeLight()
        {
			//         var fgColor = Application.Current.Resources["fgColor"];
			//Application.Current.Resources["fgColor"] = Application.Current.Resources["bgColor"];
			//Application.Current.Resources["bgColor"] = fgColor;

            var fgColor = Application.Current.MainPage.Resources["fgColor"];
			Application.Current.MainPage.Resources["fgColor"] = Application.Current.MainPage.Resources["bgColor"];
			Application.Current.MainPage.Resources["bgColor"] = fgColor;
        }

		public ICommand DarkCommand => new Command(() => MakeDark());

		private void MakeDark()
		{
			var bgColor = Application.Current.MainPage.Resources["bgColor"];
			Application.Current.MainPage.Resources["bgColor"] = Application.Current.MainPage.Resources["fgColor"];
			Application.Current.MainPage.Resources["fgColor"] = bgColor;
		}
    }
}
