using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using XypTeam.Model;
using XypTeam.Services;

namespace XypTeam.ViewModel
{
    public class MemberViewModel : INotifyPropertyChanged
    {
		public event PropertyChangedEventHandler PropertyChanged;
		public ObservableCollection<Member> Members { get; set; }
		public Command GetMembersCommand { get; set; }
        public bool IsBusy { get; set; }

        private Member selectedMember;
        public Member SelectedMember
        {
            get { return selectedMember; }
            set
            {
                selectedMember = value;
                if (selectedMember == null) return;

                GetMembersCommand.ChangeCanExecute();
            }
        }


        public MemberViewModel()
		{
			Members = new ObservableCollection<Member>();
			GetMembersCommand = new Command(async () => await GetMembers(), () => !IsBusy);
		}

        private async Task GetMembers()
        {
			if (IsBusy)
            {
				return;
            }

			Exception error = null;
			try
			{
				IsBusy = true;

				var service = DependencyService.Get<AzureService>();
				var items = await service.GetMembers();

				Members.Clear();
				foreach (var item in items)
                {
					Members.Add(item);
                }
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Error: " + ex);
				error = ex;
			}
			finally
			{
				IsBusy = false;
			}

			if (error != null)
            {
				await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
            }
        }

		//private async Task GetMembers()
		//{
		//	if (IsBusy)
		//		return;

		//	Exception error = null;
		//	try
		//	{
		//		IsBusy = true;

		//		using (var client = new HttpClient())
		//		{
		//			//grab json from server
		//			var json = await client.GetStringAsync("https://demo8208387.mockable.io/xypteam");

		//			//Deserialize json
		//			var items = JsonConvert.DeserializeObject<List<Member>>(json);

		//			//Load members into list
		//			Members.Clear();
		//			foreach (var item in items)
		//				Members.Add(item);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		Debug.WriteLine("Error: " + ex);
		//		error = ex;
		//	}
		//	finally
		//	{
		//		IsBusy = false;
		//	}

		//	if (error != null)
		//		await Application.Current.MainPage.DisplayAlert("Error!", error.Message, "OK");
		//}
    }
}
