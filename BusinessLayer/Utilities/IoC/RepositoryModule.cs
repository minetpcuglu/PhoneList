using Autofac;
using DataAccessLayer.BaseRepositories.EntityTypeRepo.Concrete;
using DataAccessLayer.BaseRepositories.EntityTypeRepo.Interface;
using DataAccessLayer.UnitOfWorks.Concrete;
using DataAccessLayer.UnitOfWorks.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utilities.IoC
{
    public class RepositoryModule : Module //UnitOfWork için bagımlılıklardan kurtulmak amacıyla IoC Containerlardan yardım almak 
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PersonRepository>().As<IPersonRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            //builder.RegisterType<ContactRepository>().As<IContactRepository>().InstancePerLifetimeScope();
            //builder.RegisterType<CityRepository>().As<ICityRepository>().InstancePerLifetimeScope();



        }
    }
}
