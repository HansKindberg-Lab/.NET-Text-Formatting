using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegionOrebroLan.ServiceLocation;
using RegionOrebroLan.ServiceLocation.Extensions;

namespace HansKindberg.TextFormatting.IntegrationTests
{
	// ReSharper disable PossibleNullReferenceException
	[TestClass]
	[SuppressMessage("Naming", "CA1716:Identifiers should not match keywords")]
	public static class Global
	{
		#region Fields

		private static IServiceProvider _serviceProvider;
		public static readonly string ProjectDirectoryPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName;
		[CLSCompliant(false)] public static readonly IConfiguration Configuration = new ConfigurationBuilder().SetBasePath(ProjectDirectoryPath).AddJsonFile("AppSettings.json").Build();

		#endregion

		#region Properties

		public static IServiceProvider ServiceProvider
		{
			get
			{
				// ReSharper disable InvertIf
				if(_serviceProvider == null)
				{
					var services = ScanServices(new ServiceCollection());

					_serviceProvider = services.BuildServiceProvider();
				}
				// ReSharper restore InvertIf

				return _serviceProvider;
			}
		}

		#endregion

		#region Methods

		[AssemblyCleanup]
		public static void Cleanup() { }

		private static ServiceLifetime GetServiceLifetime(IServiceConfigurationMapping serviceConfigurationMapping)
		{
			if(serviceConfigurationMapping == null)
				throw new ArgumentNullException(nameof(serviceConfigurationMapping));

			// ReSharper disable SwitchStatementMissingSomeCases
			switch(serviceConfigurationMapping.Configuration.InstanceMode)
			{
				case InstanceMode.Request:
				case InstanceMode.Thread:
					return ServiceLifetime.Scoped;
				case InstanceMode.Singleton:
					return ServiceLifetime.Singleton;
				default:
					return ServiceLifetime.Transient;
			}
			// ReSharper restore SwitchStatementMissingSomeCases
		}

		[AssemblyInitialize]
		[SuppressMessage("Usage", "CA1801:Review unused parameters")]
		public static void Initialize(TestContext testContext) { }

		private static IServiceCollection ScanServices(IServiceCollection services)
		{
			if(services == null)
				throw new ArgumentNullException(nameof(services));

			const string name = "HansKindberg";

			var libraries = DependencyContext.Default.RuntimeLibraries.Where(library => library.Name.Equals(name, StringComparison.OrdinalIgnoreCase) || library.Name.StartsWith(name + ".", StringComparison.OrdinalIgnoreCase));

			var assemblies = libraries.Select(library => Assembly.Load(library.Name));

			foreach(var mapping in new ServiceConfigurationScanner().Scan(assemblies))
			{
				services.Add(new ServiceDescriptor(mapping.Configuration.ServiceType, mapping.Type, GetServiceLifetime(mapping)));
			}

			return services;
		}

		#endregion
	}

	// ReSharper restore PossibleNullReferenceException
}