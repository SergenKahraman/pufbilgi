using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Puf.Api.Models;
using Puf.Common.Contracts;
using Puf.Contracts.Management;
using Puf.Services.Management.Abstraction;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

//TODO:  Register işlemi yapacağız ardından da doğrulama maili sistemini inşa edip aktif edeceğiz...
namespace Puf.Api.Areas.Management
{
    [Route("api/[area]/[controller]")]
    [Area("Management")]
    [ApiController]
    [Authorize]
    public class WriterController : ControllerBase
    {
        private readonly IWriterService service;
        private readonly IMailService mailService;
        private readonly string signingKey;
        private readonly string hostUrl;

        public WriterController(IWriterService service, IOptions<Settings> options, IMailService mailService)
        {
            this.service = service;
            this.mailService = mailService;
            signingKey = options.Value.Authentication.Secret;
            hostUrl = options.Value.HostUrl;
        }


        [HttpGet("get/{id}")]
        public WriterDto ListWriters(Guid id)
        {
            return service.GetWriter(id);
        }

        [HttpPost("update-writer")]
        public IActionResult UpdateWriter([FromBody] WriterDto writer)
        {
            var result = service.UpdateWriter(writer);
            if (result)
            {
                return Ok(true);
            }
            return BadRequest(false);
        }


        [AllowAnonymous]

        [HttpGet("list/{count}")]
        public IEnumerable<WriterDto> ListWriters(int count)
        {
            return service.GetListOfWriter(count);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = service.Authenticate(model.UserName, model.Password);
            if (user != null)
            {
                var key = Encoding.ASCII.GetBytes(signingKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.GivenName, user.DisplayName)
                    }),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var result = new DetailedSessionInformation
                {
                    Token = tokenHandler.WriteToken(token),
                    Id = user.Id,
                    DisplayName = user.DisplayName,
                };
                return Ok(result);
            }
            return BadRequest("incorrect credentials");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] NewWriterDto newWriter)
        {
            var (saved, writerId, verificationCode) = service.Register(newWriter);
            if (saved)
            {
                var content = new StringBuilder("<html><body>");
                content.Append("<h1>Hoşgeldiniz. Üyeliğiniz onaylandı.</h1>");
                content.Append($"<p>Üyeliğinizin aktifleştirilmesi için <a href=\"{hostUrl}/writer/varification-page?code={verificationCode}&writerId={writerId}\">buraya</a> tıklayınız</p>");
                content.Append("</body></html>");
                mailService.SendVerificationMail(writerId, content.ToString());
                return Ok(true);
            }
            return BadRequest(false);
        }

        [AllowAnonymous]
        [HttpPost("check/{code}/{writerId}")]

        public bool CheckCode(string code, Guid writerId)
        {
            var result = service.CheckIfCodeAndUserExists(code, writerId);
            if (result)
            {
                return true;
            }
            return false;
        }


    }
}