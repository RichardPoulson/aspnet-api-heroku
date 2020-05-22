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
    public class Program
    {
        /// <summary>Create a host builder, then build a web host which provides
        /// an API for accessing a weather forecast.
        /// <list type="number">
        /// <item>
        /// <description>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/main-and-command-args/">Main() and command-line arguments - C# Programming Guide | Microsoft Docs</see>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting?view=aspnetcore-3.1">Microsoft.AspNetCore.Hosting Namespace (v3.1) | Microsoft Docs</see>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting?view=dotnet-plat-ext-3.1">Microsoft.Extensions.Hosting Namespace (v3.1) | Microsoft Docs</see>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.host.createdefaultbuilder?view=dotnet-plat-ext-3.1#Microsoft_Extensions_Hosting_Host_CreateDefaultBuilder">Host.CreateDefaultBuilder Method (Microsoft.Extensions.Hosting (v3.1)) | Microsoft Docs</see>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.hosting.generichostbuilderextensions.configurewebhostdefaults?view=aspnetcore-3.1">GenericHostBuilderExtensions.ConfigureWebHostDefaults(...) Method (Microsoft.Extensions.Hosting) | Microsoft Docs</see>
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.hosting.hostingabstractionswebhostbuilderextensions.usestartup?view=aspnetcore-3.1#Microsoft_AspNetCore_Hosting_HostingAbstractionsWebHostBuilderExtensions_UseStartup_Microsoft_AspNetCore_Hosting_IWebHostBuilder_System_String_">HostingAbstractionsWebHostBuilderExtensions.UseStartup(IWebHostBuilder, String) Method (Microsoft.AspNetCore.Hosting) | Microsoft Docs</see>
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
