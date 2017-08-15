using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XypTeam.View.Base;
using XypTeam.ViewModel;

namespace XypTeam.View
{
    public class BasePage : ViewPage<MemberViewModel> { }
	public partial class MembersPage : BasePage
	{
		public MembersPage()
		{
			InitializeComponent();
		}
	}
}
