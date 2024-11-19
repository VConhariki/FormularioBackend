using Dapper;
using FormularioBackend.Models;
using FormularioBackend.Repositories.Interface;
using FormularioBackend.Scipts;
using Npgsql;

namespace FormularioBackend.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public async Task<IEnumerable<Feedback>?> GetAllFeedbacks()
        {
            string comandoSql = @"
                SELECT *
	                FROM public.""Feedback""
                order by 1 asc;
            ";

            string connectionString = Helper.ObterConnectionString();
            await using var connection = new NpgsqlConnection(connectionString);
            var feedbacks = connection.Query<Feedback>(comandoSql);
            return feedbacks;
        }

        public async Task<Feedback?> GetFeedbackById(int id)
        {
            string comandoSql = @"
                SELECT *
	            FROM public.""Feedback"" f
                WHERE f.id = @id;
            ";

            string connectionString = Helper.ObterConnectionString();
            await using var connection = new NpgsqlConnection(connectionString);
            var feedbacks = connection.Query<Feedback>(comandoSql, new {id});
            return feedbacks.FirstOrDefault();
        }

        public async void InsertFeedback(Feedback newFeedback)
        {
            string comandoSql = @"
                INSERT INTO public.""Feedback""(
	            titulo, descricao, tipo, status)
	            VALUES (@Titulo, @Descricao, @Tipo, @Status);
            ";

            string connectionString = Helper.ObterConnectionString();
            await using var connection = new NpgsqlConnection(connectionString);
            await connection.ExecuteAsync(comandoSql,
            new
            {
                newFeedback.Titulo,
                newFeedback.Descricao,
                newFeedback.Tipo,
                newFeedback.Status
            });
        }

        public async void UpdateFeedback(Feedback newFeedback)
        {
            string comandoSql = @"
                UPDATE public.""Feedback"" f
	            SET status=@Status
	            WHERE f.id = @Id;
            ";

            string connectionString = Helper.ObterConnectionString();
            await using var connection = new NpgsqlConnection(connectionString);
            await connection.ExecuteAsync(comandoSql,
            new
            {
                newFeedback.Id,
                newFeedback.Status
            });
        }
    }
}
