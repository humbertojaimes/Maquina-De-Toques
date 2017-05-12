using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ControlToques
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			this.BindingContext = new MainPageVM(Navigation);
		}
	}
}
