using UserCrudWithAspDotNetCoreWithAngular.Model;

namespace UserCrudWithAspDotNetCoreWithAngular.Repository
{
    public interface IUserRepository
    {
        bool CreateUser(Users? user);
        Task<bool> DeleteUser(int id);
        Task<List<Users>> GetAllUsersAsync();
        Task<Users> GetUserById(int id);
        Task<bool> UpdateUser(Users? user, int id);
    }
}
