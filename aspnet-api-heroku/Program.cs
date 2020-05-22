using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace aspnet_api_heroku
{
    /// <summary>
    /// A web host that provides an API for weather forecasts.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Create a host builder with <paramref name="args"/>, then
        /// build and run a web host.
        /// </summary>
        /// <param name="args">
        /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/">Main() and command-line arguments - C# Programming Guide | Microsoft Docs</see>
        /// </param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// <list type="number">
        /// <item>
        /// <description>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.ihostbuilder?view=dotnet-plat-ext-3.1">IHostBuilder Interface | Microsoft Docs</see>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.host.createdefaultbuilder?view=dotnet-plat-ext-3.1#Microsoft_Extensions_Hosting_Host_CreateDefaultBuilder">CreateDefaultBuilder Method | Microsoft Docs</see>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.generichostbuilderextensions.configurewebhostdefaults?view=aspnetcore-3.1">ConfigureWebHostDefaults(...) Method | Microsoft Docs</see>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting.hostingabstractionswebhostbuilderextensions.usestartup?view=aspnetcore-3.1#Microsoft_AspNetCore_Hosting_HostingAbstractionsWebHostBuilderExtensions_UseStartup_Microsoft_AspNetCore_Hosting_IWebHostBuilder_System_String_">UseStartup(IWebHostBuilder, String) Method | Microsoft Docs</see>
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="args">The command line args.</param>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
