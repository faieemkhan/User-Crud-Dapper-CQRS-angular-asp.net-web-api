using System.Data.SqlClient;
using System.Data;
using UserCrudWithAspDotNetCoreWithAngular.Model;
using Dapper;
using UserCrudWithAspDotNetCoreWithAngular.Service;

namespace UserCrudWithAspDotNetCoreWithAngular.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly string connectionString;
        private readonly IConfiguration _configuration;
        private readonly IHashService _hashService;
        public UserRepository(IConfiguration configuration,IHashService hashService)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("CompanyDb");
            _hashService = hashService;
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);

            }
        }

        public bool CreateUser(Users? user)
        {
            (string hashedPassword, string salt) = _hashService.HashPassword(user.Password);
            user.Password = hashedPassword;
            user.Salt = salt;
            user.Id = Guid.NewGuid();   
            using (IDbConnection dbconnection = Connection)
            {
                string sql = @"INSERT INTO Users (Id,Name, Email, Phone,Salt, Password, Status)
                            VALUES
                              (@Id, @Name, @Email, @Phone, @Salt,@Password, 0)";
                dbconnection.Open();
                var result = dbconnection.Execute(sql, user);
                dbconnection.Close();
                if(result > 0)
                {
                    return true;
                }
                return false;
                
            }
        }

        public async Task<bool> DeleteUser(int id)
        {
            using (IDbConnection dbconnection = Connection)
            {
                string sql = @" delete from  Users   where Id=@id   ";
                dbconnection.Open();
                var res = await dbconnection.ExecuteAsync(sql, new { Id = id });
                dbconnection.Close();
                if(res > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public async Task<List<Users>> GetAllUsersAsync()
        {
            using (IDbConnection dbconnection = Connection)
            {
                string sql = @"select * from  Users";
                dbconnection.Open();
                return (List<Users>)await dbconnection.QueryAsync<Users>(sql);

            }
        }
        public async Task<Users> GetUserById(int id)
        {
            using (IDbConnection dbconnection = Connection)
            {
                string sql = @"select * from Users where Id=@id ";
                dbconnection.Open();
                return await dbconnection.QueryFirstOrDefaultAsync<Users>(sql, new { Id = id });
            }
        }

        public async Task<bool> UpdateUser(Users? user, int id)
        {
            using(IDbConnection dbconnection = Connection)
            {
                string sql = @"update Users set Name=@Name,Email=@Email,Phone=@Phone,Password=@Password,Status = @Status where Id=@Id";
                dbconnection.Open();
                var result = await dbconnection.ExecuteAsync(sql, user);
                dbconnection.Close();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
        }
    }
}
