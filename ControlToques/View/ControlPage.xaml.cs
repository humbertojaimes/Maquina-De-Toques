using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ControlToques
{
	public partial class ControlPage : ContentPage
	{
		public ControlPage(User currentUser)
		{
			InitializeComponent();
			this.BindingContext = new ControlVM(currentUser);
		}
	}
}
