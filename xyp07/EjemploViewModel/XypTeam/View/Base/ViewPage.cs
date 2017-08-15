using System;

using Xamarin.Forms;
using XypTeam.Interfaces;

namespace XypTeam.View.Base
{
	public class ViewPage<T> : ContentPage where T : IViewModel, new()
	{
		readonly T viewModel;

		public T ViewModel
		{
			get
			{
				return viewModel;
			}
		}


		public ViewPage()
		{
			viewModel = new T();
			BindingContext = viewModel;
		}
	}
}

