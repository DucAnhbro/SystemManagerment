using BusinessObject.DTO;
using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repository;
using Repository.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository = new UserRepository();
        private readonly IConfiguration _configuration;
        
        public UserController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpGet("get_all_user")]
        public ActionResult<IEnumerable<UserDto>> GetAllUser()
        {
            List<User> users = _userRepository.GetAllUsers();
            List<UserDto> userDtos = new List<UserDto>();
            foreach (var user in users)
            {
                UserDto userDto = new UserDto()
                {
                    Id = user.Id,
                    RoleId= user.RoleId,
                    Username = user.Username,
                    Password= user.Password,
                    FirstName= user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    Gender= user.Gender,
                    Address= user.Address,
                    PhoneNumber= user.PhoneNumber,
                    Email= user.Email
                };
                userDtos.Add(userDto);
            }
            return Ok(userDtos);
        }

        [HttpGet("{userId}")]
        public ActionResult<UserDto> GetUserById(int userId)
        {
            User user = _userRepository.GetUserById(userId);
            if(user == null)
            {
                return BadRequest("User not exist");
            }
            UserDto userDto = new UserDto()
            {
                Id = user.Id,
                RoleId = user.RoleId,
                Username = user.Username,
                Password = user.Password,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Address = user.Address,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };
            return Ok(userDto);
        }

        [HttpPost("Add_new_user")]
        public IActionResult InsertNewUser(AddNewUserDto user)
        {
            try
            {
                _userRepository.InsertUser(user);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetUserById(id);
            if(user == null) return NotFound();
            _userRepository.DeleteUser(user);
            return Ok();
        }

        [HttpPut("updatedUser")]
        public IActionResult UpdateUser(int userId, AddNewUserDto userDto)
        {
            var user = _userRepository.GetUserById(userId);
            if(user == null) return NotFound();
            try
            {
                _userRepository.UpdateUser(userDto);
            }
            catch (Exception)
            {
                throw new Exception("Update fail");
            }
            return Ok();
            
        }

        [AllowAnonymous]
        [HttpGet("{email}/{password}")]
        public IActionResult Login(string email, string password)
        {

            User user = _userRepository.checkLogin(email, password);
            if (user == null)
            {
                return Unauthorized();
            }
            string role = _userRepository.GetRoleByEmail(email);
            var authClaims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                    new Claim(ClaimTypes.NameIdentifier, user.Username ?? string.Empty),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Email, user.Email ?? string.Empty),
                    new Claim(ClaimTypes.Role, role)
                };
            var token = CreateToken(authClaims);
            string newToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(newToken);
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
    }
}
