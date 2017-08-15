using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Xamarin.Forms;
using XypTeam.Model;
using XypTeam.Services;

[assembly: Dependency(typeof(AzureService))]
namespace XypTeam.Services
{
	public class AzureService
	{
		public MobileServiceClient Client { get; set; } = null;
		IMobileServiceSyncTable<Member> table;

		public async Task Initialize()
		{
			if (Client?.SyncContext?.IsInitialized ?? false)
            {
				return;
            }

			var appUrl = "https://xypteam.azurewebsites.net";

			//Create our client
			Client = new MobileServiceClient(appUrl);

			//InitialzeDatabase for path
			var path = "syncstore.db";
			path = Path.Combine(MobileServiceClient.DefaultDatabasePath, path);

			//setup our local sqlite store and intialize our table
			var store = new MobileServiceSQLiteStore(path);

			//Define table
			store.DefineTable<Member>();

			//Initialize SyncContext
			await Client.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

			//Get our sync table that will call out to azure
			table = Client.GetSyncTable<Member>();
		}

		public async Task<IEnumerable<Member>> GetSpeakers()
		{
			await Initialize();
			await SyncMembers();
			return await table.OrderBy(s => s.Name).ToEnumerableAsync();
		}

		public async Task SyncMembers()
		{
			try
			{
				await Client.SyncContext.PushAsync();
				await table.PullAsync("allMembers", table.CreateQuery());
			}
			catch (Exception ex)
			{
                Debug.WriteLine("No se ha podido sincronizar, no pasa nada porque tenemos funcionalidades offline ;-) : " + ex);
			}
		}
	}
}
