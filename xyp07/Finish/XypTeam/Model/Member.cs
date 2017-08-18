using System;
namespace XypTeam.Model
{
    public class Member
    {
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Website { get; set; }
		public string Title { get; set; }
		public string Avatar { get; set; }

		//Azure information for version
		[Microsoft.WindowsAzure.MobileServices.Version]
		public string AzureVersion { get; set; }
    }
}
