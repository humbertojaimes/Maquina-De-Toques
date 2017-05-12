using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace ControlToques
{
	public class ControlVM:BaseViewModel
	{

		private Stopwatch timeMeter = new Stopwatch();

		public ICommand IncreaseIntensityCommand
		{
			get;
			set;
		}


		public ICommand DecreaseIntensityCommand
		{
			get;
			set;
		}


		public ICommand StartConnectionCommand
		{
			get;
			set;
		}

		public ICommand EndConnectionCommand
		{
			get;
			set;
		}

		public ControlVM(User currentUser)
		{
			CurrentUser = currentUser;
			IncreaseIntensityCommand = new Command((obj) => IncreaseIntensity());
			DecreaseIntensityCommand = new Command((obj) => DecreaseIntensity());
			EndConnectionCommand = new Command((obj) => EndConnection() );
			StartConnectionCommand = new Command((obj) => ConnectBT()  );

		}

		void EndConnection()
		{
			DependencyService.Get<IBTConnection>().WriteData("B");
			AzureClient client = new AzureClient();
			client.AddUser(CurrentUser);
			timeMeter.Stop();
		}

		void ConnectBT()
		{
			DependencyService.Get<IBTConnection>().Connect();
			timeMeter.Start();
		}

		void DecreaseIntensity()
		{
			if (CurrentUser.Intensity > 1)
			{
				timeMeter.Start();
				CurrentUser.Intensity--;
				DependencyService.Get<IBTConnection>().WriteData("R");
			}
		}

		void IncreaseIntensity()
		{
			if (CurrentUser.Intensity < 10)
			{
				timeMeter.Start();
				CurrentUser.Intensity++;
				DependencyService.Get<IBTConnection>().WriteData("L");
			}
		}
}
}
