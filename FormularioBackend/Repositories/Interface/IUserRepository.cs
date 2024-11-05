using FormularioBackend.Model;

namespace FormularioBackend.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User?> GetUser(string username, string password);
        Task<IEnumerable<User>> GetAllUsers();
        void InsertUser(User newUser);
    }
}
