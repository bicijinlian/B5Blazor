using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

namespace B5Blazor
{
    public static class B5BlazorServiceCollectionExtensions
    {
        public static IServiceCollection AddB5Blazor(this IServiceCollection serviceCollection, Action<B5BlazorOptions>? options = null)
        {
            //注册服务到IoC容器
            return serviceCollection;
        }
    }
}
