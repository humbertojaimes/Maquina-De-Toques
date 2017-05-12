using System;
using System.IO;
using System.Threading.Tasks;
using Android.Bluetooth;
using Android.Widget;
using ControlToques;
using ControlToques.Droid;
using Java.Util;
[assembly: Xamarin.Forms.Dependency(typeof(BTConnection))]
namespace ControlToques.Droid
{
	public class BTConnection : IBTConnection
	{
		private static BluetoothAdapter mBluetoothAdapter = null;
		private static BluetoothSocket btSocket = null;
		private static BluetoothDevice device;
		private static string address = "00:14:01:02:31:00";
		private static UUID MY_UUID = UUID.FromString("00001101-0000-1000-8000-00805F9B34FB");
		private static Stream inStream = null;
		private static Stream outStream = null;



		public void Connect()
		{
º			mBluetoothAdapter = BluetoothAdapter.DefaultAdapter;
			device = mBluetoothAdapter.GetRemoteDevice(address);
			mBluetoothAdapter.CancelDiscovery();
			try
			{
				btSocket = device.CreateRfcommSocketToServiceRecord(MY_UUID);
				btSocket.Connect();
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine(e.Message);
				try
				{
					btSocket.Close();
				}
				catch (Exception)
				{
					Toast.MakeText(Xamarin.Forms.Forms.Context, "Imposible conectar", ToastLength.Short).Show();
				}
			}
			BeginListenForData();
		}

		public void BeginListenForData()
		{
			try
			{
				inStream = btSocket.InputStream;
			}
			catch (IOException ex)
			{
				System.Diagnostics.Debug.WriteLine(ex.Message);
			}
			Task.Factory.StartNew(() =>
			{
				byte[] buffer = new byte[1024];
				int bytes;
				while (true)
				{
					try
					{
						bytes = inStream.Read(buffer, 0, buffer.Length);
						if (bytes > 0)
						{
							//RunOnUiThread(() => {
							//    string valor = System.Text.Encoding.ASCII.GetString(buffer);
							//    Result.Text = Result.Text + "\n" + valor;
							//});
						}
					}
					catch (Java.IO.IOException)
					{
						//RunOnUiThread(() => {
						//    Result.Text = string.Empty;
						//});
						//break;
					}
				}
			});
		}

		public void WriteData(string data)
		{
			try
			{
				outStream = btSocket.OutputStream;
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error al enviar" + e.Message);
			}

			Java.Lang.String message = new Java.Lang.String(data);

			byte[] msgBuffer = message.GetBytes();

			try
			{
				outStream.Write(msgBuffer, 0, msgBuffer.Length);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Error al enviar" + e.Message);
			}
		}


	}
}
