using System.Data.SqlClient;
using System.Data;
using UserCrudWithAspDotNetCoreWithAngular.Model;
using Dapper;

namespace UserCrudWithAspDotNetCoreWithAngular.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly string connectionString;
        private readonly IConfiguration _configuration;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("default");
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
            using (IDbConnection dbconnection = Connection)
            {
                string sql = @"INSERT INTO Users (Name, Email, Phone, Password, Status)
                            VALUES
                              (@Name, @Email, @Phone, @Password, @Status)";
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
