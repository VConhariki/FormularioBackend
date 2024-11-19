using FormularioBackend.Models;

namespace FormularioBackend.Repositories.Interface
{
    public interface IFeedbackRepository
    {
        Task<IEnumerable<Feedback>> GetAllFeedbacks();
        Task<Feedback?> GetFeedbackById(int id);
        void InsertFeedback(Feedback newFeedback);
        void UpdateFeedback(Feedback newFeedback);
    }
}
