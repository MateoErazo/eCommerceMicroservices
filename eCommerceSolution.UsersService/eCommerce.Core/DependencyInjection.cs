using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core;

public static class DependencyInjection
{
  /// <summary>
  /// Extension method to add core services to the dependency injection container.
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public static IServiceCollection AddCore(this IServiceCollection services)
  {
    //TO DO: Add services to the IoC container
    //Core services often include data access, caching and other low-level components.
    return services;
  }
}

