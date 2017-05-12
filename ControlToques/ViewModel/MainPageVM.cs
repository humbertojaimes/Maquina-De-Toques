using System;
using Xamarin.Forms;

namespace ControlToques
{
	public class MainPageVM:BaseViewModel
	{


		private Command signUpCommand;

		public Command SignUpCommand
		{
			get { return signUpCommand; }
			set { signUpCommand = value; OnPropertyChanged(); }
		}

		public MainPageVM(INavigation navigationService)
			: base(navigationService)
		{
			this.signUpCommand= new Command((obj) => SignUp());
		}

		void SignUp()
		{
			NavigationService.PushAsync(new SignUpPage());
		}
}
}
