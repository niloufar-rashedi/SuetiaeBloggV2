//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Hosting.Server;
//using Microsoft.AspNetCore.TestHost;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Net.Http.Headers;
//using System.Reflection;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.AspNetCore.Mvc.ApplicationParts;
//using Microsoft.AspNetCore.Mvc.Controllers;
//using Microsoft.AspNetCore.Mvc.ViewComponents;
//using System.Text;
//using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
//using SuetiaeBlogg.Data;
//using Microsoft.Extensions.Logging;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.Extensions.Hosting;
//using System.Linq;
//using Microsoft.Extensions.PlatformAbstractions;

namespace SuetiaeBlogg.Tests
//{
//    public class TestFixture<TStartup> : IDisposable
//    {
//        public HttpClient Client { get; }
//        private TestServer Server;


//        public void Dispose()
//        {
//            Client.Dispose();
//            Server.Dispose();
//        }
//        //public static string GetProjectPath(/*string projectRelativePath,*/ Assembly startupAssembly)
//        //{
//        //    #region former tries
//        //    //var projectName = startupAssembly.GetName().Name;

//        //    //var applicationBasePath = AppContext.BaseDirectory;
//        //    ////PlatformServices.Default.Application.ApplicationBasePath;


//        //    //var directoryInfo = new DirectoryInfo(applicationBasePath);

//        //    //do
//        //    //{
//        //    //    //find *.sln files
//        //    //    var solutionFileInfo = directoryInfo.GetFiles("*.sln").FirstOrDefault();
//        //    //    if (solutionFileInfo != null)
//        //    //    {
//        //    //        return Path.GetFullPath(Path.Combine(directoryInfo.FullName, projectName));
//        //    //    }
//        //    //    directoryInfo = directoryInfo.Parent;

//        //    //    var projectDirectoryInfo = new DirectoryInfo(Path.Combine(directoryInfo.FullName, projectRelativePath));

//        //    //    if (projectDirectoryInfo.Exists)
//        //    //        if (new FileInfo(Path.Combine(projectDirectoryInfo.FullName, projectName, $"{projectName}.csproj")).Exists)
//        //    //            return Path.Combine(projectDirectoryInfo.FullName, projectName);
//        //    //}
//        //    //while (directoryInfo.Parent != null);

//        //    //throw new Exception($"Project root could not be located using the application root {applicationBasePath}.");
//        //    //Get name of the target project which we want to test
//        //    //var projectName = startupAssembly.GetName().Name;

//        //    ////Get currently executing test project path
//        //    //var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;

//        //    ////Find the folder which contains the solution file. 
//        //    ////We then use this information to find the target project which we want to test
//        //    //DirectoryInfo directoryInfo = new DirectoryInfo(applicationBasePath);
//        //    //do
//        //    //{
//        //    //    //find *.sln files
//        //    //    var solutionFileInfo = directoryInfo.GetFiles("*.sln").FirstOrDefault();
//        //    //    if (solutionFileInfo != null)
//        //    //    {
//        //    //        return Path.GetFullPath(Path.Combine(directoryInfo.FullName, projectName));
//        //    //    }
//        //    //    directoryInfo = directoryInfo.Parent;
//        //    //}
//        //    //while (directoryInfo.Parent != null);

//        //    //throw new Exception($"Solution root could not be located using application root {applicationBasePath}");

//        //    #endregion
//        //}
//        //protected TestFixture(string relativeTargetProjectParentDir)
//        //{
//        //    var startupAssembly = typeof(IStartup).GetTypeInfo().Assembly;
//        //    var contentRoot = GetProjectPath(relativeTargetProjectParentDir, startupAssembly);

//        //    var configurationBuilder = new ConfigurationBuilder()
//        //        .SetBasePath(contentRoot)
//        //        .AddJsonFile("appsettings.json");

//        //    var webHostBuilder = new WebHostBuilder()
//        //        .UseContentRoot(contentRoot)
//        //        .ConfigureServices(InitializeServices)
//        //        .UseConfiguration(configurationBuilder.Build())
//        //        .UseEnvironment("Development")
//        //        .UseStartup(typeof(TStartup));

//        //    Create instance of test server
//        //   Server = new TestServer(webHostBuilder);

//        //    Add configuration for client
//        //   Client = Server.CreateClient();
//        //   Client.BaseAddress = new Uri("https://localhost:44351");
//        //   Client.DefaultRequestHeaders.Accept.Clear();
//        //    Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//        //}
//        public TestFixture() //: this(Path.Combine(""))
//        {
//            var startupAssembly = typeof(TStartup).GetTypeInfo().Assembly;

//            var projectPath = GetProjectPath(startupAssembly);
//            var host = new WebHostBuilder()
//                       .UseContentRoot(projectPath)
//                       .UseStartup(typeof(TStartup));

//            Server = new TestServer(host);
//            Client = Server.CreateClient();
//        }

//        protected virtual void InitializeServices(IServiceCollection services)
//        {
//            var startupAssembly = typeof(TStartup).GetTypeInfo().Assembly;

//            var manager = new ApplicationPartManager
//            {
//                ApplicationParts =
//                {
//                    new AssemblyPart(startupAssembly)
//                },
//                FeatureProviders =
//                {
//                    new ControllerFeatureProvider(),
//                    new ViewComponentFeatureProvider()
//                }
//            };

//            services.AddSingleton(manager);
//        }
//        //protected override IHostBuilder CreateHostBuilder()
//        //{
//        //    return base.CreateHostBuilder()
//        //                       .UseEnvironment("IntegrationTests");
//        //}

//        //protected override void ConfigureWebHost(IWebHostBuilder builder)
//        //{
//        //    builder.ConfigureServices(services =>
//        //    {
//        //        //
//        //        // This won't replace the DbContextOptions that are already in place 
//        //        //
//        //        ReplaceCoreServices<SuetiaeBloggDbContext>(services, (p, o) =>
//        //        {
//        //            o.UseSqlServer("SuetiaeBlogg");
//        //        }, ServiceLifetime.Scoped); 

//        //        //
//        //        // This will replace DbContextOptions
//        //        //
//        //        //ReplaceCoreServices<SomeDbContext>(services, (p, o) =>
//        //        //{
//        //        //    o.UseInMemoryDatabase("DB");
//        //        //}, ServiceLifetime.Scoped);

//        //    });
//        //}

//        //private static void ReplaceCoreServices<TContextImplementation>(IServiceCollection serviceCollection,
//        //                                        Action<IServiceProvider, DbContextOptionsBuilder> optionsAction,
//        //                                        ServiceLifetime optionsLifetime) where TContextImplementation : DbContext
//        //{
//        //    serviceCollection.Add(new ServiceDescriptor(typeof(DbContextOptions<TContextImplementation>),
//        //                          (IServiceProvider p) => DbContextOptionsFactory<TContextImplementation>(p, optionsAction), optionsLifetime));
//        //    serviceCollection.Add(new ServiceDescriptor(typeof(DbContextOptions),
//        //                          (IServiceProvider p) => p.GetRequiredService<DbContextOptions<TContextImplementation>>(), optionsLifetime));
//        //}

//        //private static DbContextOptions<TContext> DbContextOptionsFactory<TContext>(IServiceProvider applicationServiceProvider,
//        //                                           Action<IServiceProvider, DbContextOptionsBuilder> optionsAction) where TContext : DbContext
//        //{
//        //    DbContextOptionsBuilder<TContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<TContext>(
//        //        new DbContextOptions<TContext>(new Dictionary<Type, IDbContextOptionsExtension>()));
//        //    dbContextOptionsBuilder.UseApplicationServiceProvider(applicationServiceProvider);
//        //    optionsAction?.Invoke(applicationServiceProvider, dbContextOptionsBuilder);
//        //    return dbContextOptionsBuilder.Options;
//        //}
//    }
//}
{
    public abstract class TestBase : IClassFixture<TestApplicationFactory<FakeStartup>>
    {
        protected WebApplicationFactory<FakeStartup> Factory { get; }

        public TestBase(TestApplicationFactory<FakeStartup> factory)
        {
            Factory = factory;
        }

        // Add you other helper methods here
    }
}
