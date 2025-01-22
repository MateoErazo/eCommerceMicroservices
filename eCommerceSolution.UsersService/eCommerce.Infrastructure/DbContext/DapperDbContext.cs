﻿using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace eCommerce.Infrastructure.DbContext;

internal class DapperDbContext
{
  private readonly IConfiguration _configuration;
  private readonly IDbConnection _connection;

  public DapperDbContext(IConfiguration configuration)
  {
    _configuration = configuration;
    string? connectionString = _configuration.GetConnectionString("PostgresConnection");

    //Create a new npg sql connection with the retrieved connection string
    _connection = new NpgsqlConnection(connectionString); 
  }

  public IDbConnection DbConnection => _connection;
}
