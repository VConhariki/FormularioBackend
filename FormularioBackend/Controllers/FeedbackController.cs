using FormularioBackend.Models;
using FormularioBackend.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormularioBackend.Controllers
{
    [ApiController]
    public class FeedbackController(IFeedbackRepository feedbackRepository) : ControllerBase
    {
        private readonly IFeedbackRepository _feedbackRepository = feedbackRepository;

        [HttpGet]
        [Route("feedbacks")]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<Feedback>> Index()
        {
            var feedbacks = _feedbackRepository.GetAllFeedbacks().Result;
            if (feedbacks == null) { return NotFound(); }
            return Ok(feedbacks);
        }

        [HttpGet]
        [Route("feedbacks/{idFeedback}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Feedback> ShowId(int idFeedback)
        {
            var feedback = _feedbackRepository.GetFeedbackById(idFeedback).Result;
            if (feedback == null) { return NotFound(); }
            return Ok(feedback);
        }

        [HttpPost]
        [Route("feedback/cadastrar")]
        [Authorize(Roles = "Admin")]
        public ActionResult<string> Store([FromBody] Feedback feedback)
        {
            try
            {
                _feedbackRepository.InsertFeedback(feedback);
                return Ok("Feedback inserido com sucesso");
            }catch (Exception)
            {
                return StatusCode(500, "Erro ao inserir feedback");
            }
        }

        [HttpPut]
        [Route("feedback/atualizar")]
        [Authorize(Roles = "Admin")]
        public ActionResult<string> Update([FromBody] Feedback feedback)
        {
            try
            {
                _feedbackRepository.UpdateFeedback(feedback);
                return Ok("Feedback alterado com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ao alterar feedback");
            }
        }
    }
}
