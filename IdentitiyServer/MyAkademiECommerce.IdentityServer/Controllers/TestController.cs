using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAkademiECommerce.IdentityServer.Dtos;
using MyAkademiECommerce.IdentityServer.Models;
using System.Threading.Tasks;

namespace MyAkademiECommerce.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public TestController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]

        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var values = new ApplicationUser()
            {
                UserName = userRegisterDto.UserName,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
                City = userRegisterDto.City,
                Email = userRegisterDto.Mail
            };
            var result = await _userManager.CreateAsync(values, userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok("Kullanıcı başarıyla eklendi");
            }
            else
            {
                return Ok("Hata oluştu!");
            }
        }
    }
}
