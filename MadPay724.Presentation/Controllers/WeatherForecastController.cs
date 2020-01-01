using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadPay724.Data.DatabaseContext;
using MadPay724.Data.Infrastructure;
using MadPay724.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MadPay724.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IUnitOfWork<MadpayDbContext> _db;
        public WeatherForecastController(IUnitOfWork<MadpayDbContext> dbContext)
        {
            _db = dbContext;
        }
       
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        

      

        [HttpGet]

        public async Task<ActionResult<IEnumerable<string>>> Get()
        {
            /*var user = new User()
            {
                Address = "",
                City = "",
                DataOfBirth = "",
                Gender = "",
                IsActive = true,
                Name = "",

                PaswordHash = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },
                PaswordSalt = new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 },

                PhoneNumber = "",
                Status = true,
                UserName = ""
            };

            await _db.UserRepository.InsertAsync(user);
            await _db.SaveAsync();

            var model = await _db.UserRepository.GetAllAsync();*/


            return Ok("SinA");
        }
       
    }
}
