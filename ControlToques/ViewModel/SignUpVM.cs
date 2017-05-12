using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlToques
{
	public class SignUpVM : BaseViewModel
	{

		public List<string> Genders 
		{
			get;
		}




		public ICommand SignUpCommand
		{
			get;
			set;
		}



		public SignUpVM()
		{
			Genders = new List<string>();
			Genders.Add("Hombre");
			Genders.Add("Mujer");

			SignUpCommand = new Command((obj) => SignUp());
		}



		void SignUp()
		{
			NavigationService.PushAsync(new ControlPage(CurrentUser));
			//AzureClient client = new AzureClient();
			//client.AddContact(CurrentUser);
		}
}
}
