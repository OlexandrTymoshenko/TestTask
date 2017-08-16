using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Ninject.Web.Common.OwinHost;
using Ninject;
using Ninject.Modules;
using TestTask.DAL.Infrastructure;
using System.Reflection;
using TestTask.Management.Interfaces;
using TestTask.Management.Managers;
using Ninject.Web.WebApi.OwinHost;
using TestTask.Api.App_Start;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(TestTask.Api.Startup))]

namespace TestTask.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            app.UseCors(CorsOptions.AllowAll);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(httpConfiguration);
            
        }
        private static StandardKernel CreateKernel()
        {
            var modules = new INinjectModule[] { new ServiceModule("DBConnection") };
            var kernel = new StandardKernel(modules);
            kernel.Bind<IBookManager>().To<BookManager>();
            kernel.Load(Assembly.GetExecutingAssembly());

            return kernel;
        }
    }
}
