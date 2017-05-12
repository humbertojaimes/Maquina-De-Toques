using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ControlToques
{
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage()
		{
			InitializeComponent();
			this.BindingContext = new SignUpVM();
		}
	}
}
