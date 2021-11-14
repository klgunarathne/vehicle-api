using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.data;
using backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/vehicle")]
    [ApiController]
    public class VehicleController: Controller
    {
        private readonly ApplicationDbContext _context;
        public VehicleController(ApplicationDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            return Ok(await _context.Vehicles.ToListAsync());
        }

        [HttpPost]
        public IActionResult CreateVehicle([FromBody]Vehicle vehicle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetVehicle(int id)
        {
            var vehicle = _context.Vehicles.Where(v => v.Id == id).SingleOrDefault();
            if (vehicle == null)
                return NotFound();
            return Ok(vehicle);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle(int id, [FromBody]Vehicle vehicle)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vehicleInDb = _context.Vehicles.Where(v => v.Id == id).SingleOrDefault();
            if (vehicleInDb == null)
                return NotFound();

            vehicleInDb.VehicleType = vehicle.VehicleType;
            vehicleInDb.Make = vehicle.Make;

            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle(int id)
        {
            var vehicleInDb = _context.Vehicles.Where(v => v.Id == id).SingleOrDefault();
            if (vehicleInDb == null)
                return NotFound();

            _context.Vehicles.Remove(vehicleInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}