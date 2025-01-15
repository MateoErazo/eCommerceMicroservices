﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Infrastructure;

public static class DependencyInjection
{
  /// <summary>
  /// Extension method to add infrastructure services to the dependency injection container.
  /// </summary>
  /// <param name="services"></param>
  /// <returns></returns>
  public static IServiceCollection AddInfrastructure(this IServiceCollection services)
  {
    //TO DO: Add services to the IoC container
    //Infrastructure services often include data access, caching and other low-level components.
    return services;
  }
}

