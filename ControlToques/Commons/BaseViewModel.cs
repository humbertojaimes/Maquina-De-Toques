using System;
using Xamarin.Forms;

namespace ControlToques
{
	public class BaseViewModel:ObservableBaseObject
	{
		protected  User currentUser= new User();

		public  User CurrentUser
		{
			get { return currentUser; }
			set { currentUser = value; }
		}

		protected static INavigation navigationService;

		public static INavigation NavigationService
		{
			get { return navigationService; }
			set { navigationService = value; }
		}

		private bool isBusy;

		public bool IsBusy
		{
			get { return isBusy; }
			set { isBusy = value; OnPropertyChanged(); }
		}

		public BaseViewModel()
		{

		}

		public BaseViewModel(INavigation navigationService)
		{
			NavigationService = navigationService;


		}

	}
}
