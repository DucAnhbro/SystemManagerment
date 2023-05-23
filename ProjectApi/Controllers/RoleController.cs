using BusinessObject.DTO;
using BusinessObject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.Interfaces;

namespace ProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IUserRepository _userRepository = new UserRepository();
        private readonly IConfiguration  _configuration;

        public RoleController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpGet("GetAllRoles")]
        public ActionResult<IEnumerable<RoleDto>> GetAllRoles()
        {
            List<Role> roles = _userRepository.GetAllRoles();
            List<RoleDto> roleDtos = new List<RoleDto>();
            foreach (var role in roles)
            {
                RoleDto roleDto = new RoleDto()
                {
                    Id = role.Id,
                    Name = role.Name
                };
                roleDtos.Add(roleDto);
            }
            return Ok(roleDtos);
        }

    }
}
