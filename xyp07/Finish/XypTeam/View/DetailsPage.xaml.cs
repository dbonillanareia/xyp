using System;
using System.Collections.Generic;
using Plugin.TextToSpeech;
using Xamarin.Forms;
using XypTeam.Model;

namespace XypTeam.View
{
    public partial class DetailsPage : ContentPage
    {
        Member member;
        public DetailsPage(Member item)
        {
            InitializeComponent();

			this.member = item;

			BindingContext = this.member;

			ButtonSpeak.Clicked += ButtonSpeak_Clicked;

			ButtonWebsite.Clicked += ButtonWebsite_Clicked;
        }

		private void ButtonWebsite_Clicked(object sender, EventArgs e)
		{
			if (member.Website.StartsWith("http"))
				Device.OpenUri(new Uri(member.Website));
		}

		private void ButtonSpeak_Clicked(object sender, EventArgs e)
		{
			CrossTextToSpeech.Current.Speak(this.member.Description);
		}
    }
}
