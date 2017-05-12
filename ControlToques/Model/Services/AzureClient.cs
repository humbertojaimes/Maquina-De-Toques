using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace ControlToques
{
	public class AzureClient
	{
		private IMobileServiceClient _client;
		private IMobileServiceTable<User> _table;
		const string dbPath = "contactDb";
		private const string serviceUri = "http://serviciotoques.azurewebsites.net/";

		public AzureClient()
		{
			_client = new MobileServiceClient(serviceUri);
			_table = _client.GetTable<User>();
		}


		public async void AddUser(User contact)
		{
			await _table.InsertAsync(contact);

		}





	}
}
