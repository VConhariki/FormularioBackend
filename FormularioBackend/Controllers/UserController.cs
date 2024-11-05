using FormularioBackend.Model;
using FormularioBackend.Repositories.Interface;
using FormularioBackend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FormularioBackend.Controllers
{
    [ApiController]
    public class UserController(IUserRepository userRepository) : ControllerBase
    {
        private readonly IUserRepository _userRepository = userRepository;

        [HttpPost]
        [Route("login")]
        public ActionResult<dynamic> Login([FromBody] User user)
        {
            var validatedUser = _userRepository.GetUser(user.Username, user.Password).Result;
            if (validatedUser == null) return NotFound("Usuário não encontrado");
            var token = TokenService.GenerateToken(validatedUser);
            return Ok(token);
        }

        [HttpPost]
        [Route("cadastrar")]
        [Authorize(Roles = "Admin")]
        public ActionResult<string> Cadastrar(User newUser)
        {
            _userRepository.InsertUser(newUser);
            return Ok("Usuário inseriodo com sucesso");
        }

        [HttpGet]
        [Route("obterTodosUsuarios")]
        [Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<User>> ObterTodosUsuarios()
        {
            var resp = _userRepository.GetAllUsers().Result;
            return Ok(resp);
        }
    }
}
