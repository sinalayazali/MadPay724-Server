using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadPay724.Common.Return;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Dtos.Site.Admin;
using MadPay724.Data.Models;
using MadPay724.Repo.Infrastructure;
using MadPay724.Services.Site.Admin.Auth.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MadPay724.Presentation.Controllers.Site.Admin
{
    [Route("site/admin/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUnitOfWork<MadpayDbContext> _db;
        private readonly IAuthService _authService;
        public AuthController(IUnitOfWork<MadpayDbContext> dbContext, IAuthService authService)
        {
            _db = dbContext;
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
            userForRegisterDto.UserName = userForRegisterDto.UserName.ToLower();
            if (await _db.UserRepository.UserExists(userForRegisterDto.UserName))
            {
                return BadRequest(new ReturnMessage()
                {
                   status=false,
                   title="خطا",
                   message = "نام کاربری وجود دارد"
                });
            }
                

            var userToCreate = new User
            {
                UserName = userForRegisterDto.UserName,
                Name = userForRegisterDto.Name,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                Address = "",
                City = "",
                DataOfBirth = DateTime.Now,
                Gender = true,
                IsActive = true,
                Status = true
            };
            var createdUser = await _authService.Register(userToCreate, userForRegisterDto.Password);

            return StatusCode(201);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            var user = new User()
            {
                Address = "",
                City = "",
                DataOfBirth = DateTime.Now,
                Gender = true,
                IsActive = true,
                Name = "",

                PaswordHash = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                PaswordSalt = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },

                PhoneNumber = "",
                Status = true,
                UserName = ""
            };

            var u = await _authService.Register(user, "soheil");

            return Ok(u);
        }
    }
}