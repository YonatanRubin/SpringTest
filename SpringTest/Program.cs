using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
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
					.AddConfigServer("/development/master");

			var cfg = builder.Build();
			Console.WriteLine(string.Join(",", cfg.GetChildren().Select(c => c.Key)));
			Console.WriteLine(cfg.GetDebugView());
		}

		class Config
		{
			public Another Another { get; set; }
			public string Role { get; set; }
		}

		class Another
		{
			public string Sub { get; set; }
			public string Key { get; set; }
		}
	}
}