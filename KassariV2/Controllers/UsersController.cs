using Kassari.Domain.Interfaces;
using KassariV2.Context;
using KassariV2.Entities;
using KassariV2.Repository;
using KassariV2.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KassariV2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IJWTManagerRepository _jWTManagerRepository;
        private readonly UsersRepository _usersRepository;
        //private readonly UsersRepository;
        private readonly KassariContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public UsersController(IJWTManagerRepository jWTManagerRepository, KassariContext context, UsersRepository usersRepository, IUnitOfWork unitOfWork)
        {
            _jWTManagerRepository = jWTManagerRepository;
            _context = context;
            _usersRepository = usersRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Users> Get()
        {
            return _usersRepository.GetAll();
        }

        [AllowAnonymous]
        [HttpPost]
        public StatusCodeResult Post([FromBody] Users user)
        {
            var alreadyExists = _context.Users.Where(u => u.Username == user.Username).ToList().Count > 0 ? true : false;
            if (alreadyExists) return StatusCode(409);
            _usersRepository.Save(user);
            _unitOfWork.Commit();
            return StatusCode(201);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(string username, string password)
        {
            var user = _context.Users.Where(u => u.Username == username && u.Password == password).First();
            var token = _jWTManagerRepository.Authenticate(user);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
