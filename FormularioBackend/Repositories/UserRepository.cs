using Dapper;
using FormularioBackend.Enum;
using FormularioBackend.Model;
using FormularioBackend.Repositories.Interface;
using FormularioBackend.Scipts;
using Npgsql;

namespace FormularioBackend.Repository
{
    public class UserRepository : IUserRepository
    {
        public async Task<User?> GetUser(string username, string password)
        {
            string comandoSql = @"
                SELECT *
                FROM public.""User"" u
                where u.username = @Username and u.password = @Password
            ";

            string connectionString = Helper.ObterConnectionString();
            await using var connection = new NpgsqlConnection(connectionString);
            var users = connection.Query<User>(comandoSql, param: new {Username = username, Password = password});
            return users.FirstOrDefault();
        }

        public async void InsertUser(User newUser)
        {
            string comandoSql = @"
                INSERT INTO public.""User""(
	            username, password, role)
	            VALUES (@username, @password, @role);
            ";

            string connectionString = Helper.ObterConnectionString();
            await using var connection = new NpgsqlConnection(connectionString);
            await connection.ExecuteAsync(comandoSql,
            new
            {
                username = newUser.Username,
                password = newUser.Password,
                role = newUser.Role
            });
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            string comandoSql = @"
                SELECT *
                FROM public.""User"";
            ";

            string connectionString = Helper.ObterConnectionString();
            await using var connection = new NpgsqlConnection(connectionString);
            var users = connection.Query<User>(comandoSql);
            return users;
        }
    }
}
