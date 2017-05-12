using System;
namespace ControlToques
{
	public interface IBTConnection
	{

		void Connect();
		void BeginListenForData();
	    void WriteData(string data);
	}
}
