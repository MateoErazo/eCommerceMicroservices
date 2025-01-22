using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories
{
  internal class UsersRepository : IUsersRepository
  {
    private readonly DapperDbContext _dbContext;

    public UsersRepository(DapperDbContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
      //generate a new unique User Id for the user
      user.UserId = Guid.NewGuid();

      //SQL Query to insert data into the "Users" table.
      string query = "INSERT INTO public.\"Users\"(\"UserId\",\"Email\",\"PersonName\",\"Gender\",\"Password\") VALUES (@UserId, @Email, @PersonName, @Gender, @Password)";

      int rowsCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);

      if (rowsCountAffected <= 0) {
        return null;
      }

      return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
      //SQL Query to select a user by Email and Password.
      string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
      
      ApplicationUser? user = await _dbContext.DbConnection
        .QueryFirstOrDefaultAsync<ApplicationUser>(query, new {Email=email, Password=password});

      if (user == null) { return null; }

      return user;
    }
  }
}
