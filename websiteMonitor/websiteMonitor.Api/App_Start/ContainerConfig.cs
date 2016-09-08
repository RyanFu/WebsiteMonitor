using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Autofac;
using Autofac.Extras.Quartz;
using Autofac.Integration.WebApi;
using Quartz;
using websiteMonitor.Api.ScheduledTasks;

namespace websiteMonitor.Api
{

    public class ContainerConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(ContainerConfig).Assembly).InstancePerLifetimeScope();
            //This registers 'A'
            builder.RegisterAssemblyModules(typeof(ContainerConfig).Assembly);

            // 1) Register IScheduler
            builder.RegisterModule(new QuartzAutofacFactoryModule());
            // 2) Register jobs
            builder.RegisterModule(new QuartzAutofacJobsModule(typeof(WebsiteCheckJob).Assembly));
            var container = builder.Build();
            var scheduler = container.Resolve<IScheduler>();
            scheduler.Start();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }

    //This is 'A'
    public class RegisterServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            ////____DbContext____
            //builder.RegisterType<PropertyButlerContext>().As<IPropertyButlerContext>().InstancePerLifetimeScope();


            ////___Managers____
            ////builder.RegisterType<HomeManager>().AsImplementedInterfaces();
            //builder.RegisterType<HomeManager>().As<IHomeManager>();

            base.Load(builder);
        }
    }