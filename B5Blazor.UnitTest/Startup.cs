using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.Console;

using Xunit.DependencyInjection.Logging;
using Microsoft.Extensions.Logging;
using B5Blazor.UnitTest.Study;

namespace B5Blazor.UnitTest
{
    public class Startup
    {
        /// <summary>
        /// 配置Host
        /// </summary>
        public void ConfigureHost(IHostBuilder hostBuilder)
        {
            hostBuilder
            //.ConfigureContainer<IServiceCollection>((context, config) => { })
            //管理主机配置
            //.ConfigureHostConfiguration(builder =>{})
            //管理应用
            .ConfigureAppConfiguration((context, builder) =>
            {
                //context.Configuration
                //context.HostingEnvironment
            });
        }

        public void ConfigureServices(IServiceCollection services, HostBuilderContext context)
        {
            //context.HostingEnvironment
            //context.Configuration

            //注册服务
            services.AddScoped<IServerDemo, ServerDemo>();

            //配置日志
            services.AddLogging(builder =>
            {
                //把 ILogger 日志, 输出到 xUnit的标准输出-ITestOutputHelperAccessor 中。
                builder.AddXunitOutput();
            });
        }
    };
}
