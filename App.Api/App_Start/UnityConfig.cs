using App.Api.DB;
using App.Api.Models;
using App.Api.Service;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.Lifetime;
using Unity.WebApi;

namespace App.Api
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IContactService, ContactService>();
            container.RegisterType<IContactRepository, ContactRepository>();

            container.RegisterType<ISession>(new InjectionFactory(c => c.Resolve<ISessionFactory>().OpenSession()));

            container.RegisterType<ISessionFactory>(
                    new ContainerControlledLifetimeManager(),
                    new InjectionFactory(c =>
                    {
                        var v = Fluently.Configure()
                        .Database(MsSqlConfiguration
                            .MsSql2008
                            .ConnectionString(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Repos\ContactApp\App.Api\App_Data\ContactsDB.mdf;Integrated Security=True")
                            .ShowSql())
                       .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Contact>())
                       .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                       .BuildSessionFactory();

                        return v;
                    })
                );

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}