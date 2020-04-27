using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Steeltoe.Extensions.Configuration.ConfigServer;

namespace SpringTest
{
	class Program
	{
		static void Main(string[] args)
		{
			IConfigurationBuilder builder =
				new ConfigurationBuilder()
					.AddJsonFile("appsettings.json")
					.AddJsonFile("local.json")
					.AddConfigServer("/development/master");// the environment is built by {Deployment}/{Branch}.
																	   // so if we add something only to our branch we can keep using the same repo.
											                           // not quite sure how useful it is though

			var cfg = builder.Build();
			Console.WriteLine(string.Join(",", cfg.GetChildren().Select(c => c.Key))); // all known sections
			Console.WriteLine(cfg.GetDebugView()); // everything
			Console.WriteLine(JsonConvert.SerializeObject(cfg.Get<Config>())); //the configuration as binded
		}

		class Config
		{
			public Another Another { get; set; }
			public User User { get; set; }
		}

		class Another
		{
			public string Sub { get; set; }
			public string Key { get; set; }
		}

		class User
		{
			public string Role { get; set; }
		}
	}
}