using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_RepositoryPattern.Core;
using WebApi_RepositoryPattern.Data;
using WebApi_RepositoryPattern.Models;

namespace WebApi_RepositoryPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public DriverController(IUnitOfWork context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Drivers.GetAll());
        }

        [HttpGet]
        [Route(template: "GetById")]
        public async Task<IActionResult> Get(int Id)
        {
            var driver = await _context.Drivers.GetById(Id);
            if(driver == null) return NotFound();

            return Ok(driver);
        }

        [HttpPost]
        [Route(template: "AddDriver")]
        public async Task<IActionResult> AddDriver(Driver driver)
        {
            await _context.Drivers.Add(driver);
            await _context.CompleteAsync();
            return Ok();
        }

        [HttpDelete]
        [Route(template: "DeleteDriver")]
        public async Task<IActionResult> DeleteDriver(int Id)
        {
            var driver = await _context.Drivers.GetById(Id);

            if (driver == null) return NotFound();

            await _context.Drivers.Delete(driver);
            await _context.CompleteAsync();

            return Ok();
        }

        [HttpPatch]
        [Route(template: "UpdateDriver")]
        public async Task<IActionResult> UpdateDriver(Driver driver)
        {
            var existDriver = await _context.Drivers.GetById(driver.Id);

            if (existDriver == null) return NotFound();

            await _context.Drivers.Update(driver);
            await _context.CompleteAsync();

            return NoContent();
        }
    }
}
