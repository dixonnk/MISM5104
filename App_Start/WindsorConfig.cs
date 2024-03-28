using Castle.MicroKernel.Registration;
using Castle.Windsor.Installer;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Castle.MicroKernel.SubSystems.Configuration;
using System.Web.Mvc;
using System.Web.Routing;
using MISM5104.Repositories;

namespace MISM5104
{
	public class WindsorConfig
	{
	}
	public class CastleInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			var controllers = Assembly.GetExecutingAssembly().GetTypes().Where(m => m.BaseType == typeof(Controller))
				.ToList();
			foreach (var controller in controllers)
			{
				container.Register(Component.For(controller).LifestyleTransient());
			}
			container.Register(
				Classes.FromThisAssembly()
					.Where(type => type.Name.EndsWith("Service"))
					.WithServiceDefaultInterfaces()
					.LifestyleTransient()
			);
			container.Register(
				Classes.FromThisAssembly()
					.Where(type => type.Name.EndsWith("Repository"))
					.WithServiceDefaultInterfaces()
					.LifestyleTransient()
			);
			//Register components
			//container.Register(
			//	Component.For<IRepository>().ImplementedBy<Repository>().LifestyleTransient()
			//);
		}
	}

	public class ControllerFactory : DefaultControllerFactory
	{
		public readonly IWindsorContainer Container;

		public ControllerFactory(IWindsorContainer container)
		{
			Container = container;
		}

		protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
		{
			if (controllerType == null)
				return null;
			return Container.Resolve(controllerType) as IController;
		}

		public override void ReleaseController(IController controller)
		{
			var disposableType = controller as IDisposable;
			disposableType?.Dispose();
			Container.Release(controller);
		}
	}
}