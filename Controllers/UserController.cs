using System;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Mari7.Models;
using Mari7.Services;
using Mari7.Entities;
using Mari7.Helpers;
using Serilog;
using Serilog.Formatting.Compact;





namespace Mari7.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {


        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings, ILogger<UserController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticateModel model)
        {
            var user = _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            user.RoleList = _userService.GetUserRoles(user.ID).ToList();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            List<Claim> claimList = new List<Claim>();
            claimList.Add(new Claim(ClaimTypes.Name, user.ID.ToString()));/* claime userID eklenior */
            foreach (var item in user.RoleList)
            {
                claimList.Add(new Claim(ClaimTypes.Role, item.RoleID.ToString())); /* Claime userrole değerleri ekleniyor */
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claimList),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = user.ID,
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Token = tokenString
            });
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterModel model)
        {
            
               Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            // .WriteTo.Console()
             //.WriteTo.Console(new RenderedCompactJsonFormatter())
             .WriteTo.File(new RenderedCompactJsonFormatter(), "../logs/log.ndjson")
            .CreateLogger();
            Log.Information("Start Register Controller");
            // map model to entity
            var user = _mapper.Map<MariUser>(model);

            try
            {
                // create user
                _userService.Create(user, model.Password);
                //return Ok();
                return Ok(user);
            }
            catch (Exception ex)
            {
                Log.Information("Register Controller Exception "+ ex.Message);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        
        // [Authorize(Roles.HasClaim(Role.Admin))]
        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var model = _mapper.Map<IList<UserModel>>(users);
            return Ok(model);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            _logger.LogInformation("Hello, {id}!", id);
            // only allow admins to access other user records
            var currentUserId = int.Parse(User.Identity.Name);
            if (id != currentUserId && !User.IsInRole(Role.Admin))
                return Forbid();

            var user = _userService.GetById(id);
            if (user == null)
                return NotFound();

            var model = _mapper.Map<UserModel>(user);

            return Ok(model);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody]UpdateModel model)
        {
            // map model to entity and set id
            var user = _mapper.Map<MariUser>(model);
            user.ID = id;

            try
            {
                // update user 
                _userService.Update(user, model.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [Authorize(Roles = Role.Admin)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return Ok();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("AddRole")]
        public IActionResult AddRole(long userId, int roleId)
        {
            _userService.AddRole(userId, roleId);
            return Ok();
        }

    }
}