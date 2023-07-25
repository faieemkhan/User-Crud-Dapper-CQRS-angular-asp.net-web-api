namespace UserCrudWithAspDotNetCoreWithAngular.Service
{
    public interface IHashService
    {
        
        (string hashedPassword, string salt) HashPassword(string password);
    }
}
