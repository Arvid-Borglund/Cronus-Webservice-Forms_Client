using System;
using Microsoft.Extensions.Configuration;
using System.Web.Hosting;

namespace WebApplicationCronus
{
    public static class MyConfigurationHelper
    {
        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(HostingEnvironment.MapPath("~"))
                .AddJsonFile("MYappsettings.json");

            return builder.Build();
        }
    }
}