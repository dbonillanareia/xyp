using Xamarin.Forms;
using XypTeam.Model;

namespace XypTeam.View
{
    public partial class MembersPage : ContentPage
    {
        public MembersPage()
        {
            InitializeComponent();

			ListViewMembers.ItemSelected += ListViewMembers_ItemSelected;
		}

		private async void ListViewMembers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var member = e.SelectedItem as Member;
			if (member == null)
				return;

			await Navigation.PushAsync(new DetailsPage(member));

			ListViewMembers.SelectedItem = null;
		}
    }
}
