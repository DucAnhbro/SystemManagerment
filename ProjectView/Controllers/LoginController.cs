using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace ProjectView.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient client = null;
        private string UserApiUrl = "";
        public LoginController()
        {
            client = new HttpClient();
            UserApiUrl = "http://localhost:5000/api/User/Login";
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("logout")]

        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("jwtToken");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            HttpResponseMessage response = await client.GetAsync(UserApiUrl + "/" + email + "/" + password);
            if (!response.IsSuccessStatusCode)
            {
                return View();
            }
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddMinutes(5);
            Response.Cookies.Append("jwtToken", strData, cookieOptions);


            var jwtHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtHandler.ReadJwtToken(strData);
            string role = "";
            foreach (var claim in jwtToken.Claims)
            {
                var type = claim.Type;
                if (claim.Type.Equals("http://schemas.microsoft.com/ws/2008/06/identity/claims/role"))
                {
                    role = claim.Value;
                }
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
