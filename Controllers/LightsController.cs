using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HomeControlApi.Models;
using HomeControlApi.Commons;

namespace HomeControlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LightsController : ControllerBase
    {
        private readonly LightsContextContext _context;

        public LightsController(LightsContextContext context)
        {
            _context = context;
        }

        // GET: api/devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Light>>> GetAllDevices()
        {
            return await _context.Light.ToListAsync();
        }

        // GET: api/device/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Light>> GetDeviceId(long id)
        {
            var deviceId = await _context.Light.FindAsync(id);

            if (deviceId == null)
            {
                return NotFound();
            }

            return deviceId;
        }

       

        // POST: api/Lights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Light>> PostLight(Light light)
        {
           if(GetDeviceId==null){
             return NotFound();
           }
           
           if(LightConstants.LIGHT_ON){
              _context.Add(light.LightOn=true);
           }
           
           if(LightConstants.LIGHT_OFF)
            {
             _context.Add(light.LightOn=false);
            }

            // _context.Light.Add(light);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLight", new { id = light.Id }, light);
        }

       
        private bool LightExists(long id)
        {
            return _context.Light.Any(e => e.Id == id);
        }
    }
}
