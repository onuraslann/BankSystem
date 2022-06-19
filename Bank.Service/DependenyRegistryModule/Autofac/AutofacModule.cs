using Autofac;
using Autofac.Extras.DynamicProxy;
using Bank.Core.BaseRepository.Abstract;
using Bank.Core.Utilities.Interceptors;
using Bank.DataAccess.EntityFramework.Repository;
using Bank.DataAccess.UnitOfWork;
using Bank.Service.ApplicationServices.Abstract;
using Bank.Service.ApplicationServices.Concrete;
using Bank.Service.BaseService;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service.DependenyRegistryModule.Autofac
{
    public class AutofacModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)) .As(typeof(IGenericRepository<>)) .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(ServiceGeneric<,>)).As(typeof(IServiceGeneric<,>)).InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();






            //AS
            builder.RegisterType<CustomerAS>().As<ICustomerAS>().SingleInstance();
            builder.RegisterType<EmployeeAS>().As<IEmployeeAS>().SingleInstance();
            builder.RegisterType<CreditAS>().As<ICreditAS>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
