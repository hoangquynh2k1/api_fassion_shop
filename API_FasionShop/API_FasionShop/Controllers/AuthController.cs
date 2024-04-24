using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_FashionShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        

        [HttpGet("google-response")]
        public async Task<IActionResult> GoogleResponse(string returnUrl = "/")
        {
            var authenticateResult = await HttpContext.AuthenticateAsync();

            // Xử lý kết quả đăng nhập ở đây

            return Redirect(returnUrl);
        }
        [HttpGet("google")]
        public void LoginGoogle(string returnUrl = "/")
        {
            string clientid = "537443452324-9knkfuovs0msq5fll68cj9tcn6h8e480.apps.googleusercontent.com";
            string urls = "https://accounts.google.com/o/oauth2/v2/auth?scope=email&include_granted_scopes=true&redirect_uri=" + returnUrl + "&response_type=code&client_id=" + clientid + "";
            Response.Redirect(urls);
        }
    }
}
