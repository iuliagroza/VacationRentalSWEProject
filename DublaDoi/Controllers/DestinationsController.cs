using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DublaDoi.DTOs;
using DublaDoi.Models;
using DublaDoi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace DublaDoi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DestinationsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Destinations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Destination>>> GetDestinations()
        {
            if (_context.Destinations == null)
            {
                return NotFound();
            }
            return await _context.Destinations.ToListAsync();
        }

        // GET: api/Destinations/public
        [HttpGet("getPublicDestinations")]
        public async Task<ActionResult<IEnumerable<Destination>>> GetDestination()
        {
            if (_context.Destinations == null)
            {
                return NotFound();
            }
            return await _context.Destinations.Where(d => d.IsPublic == true).ToListAsync();
        }


        // POST: api/Destinations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("public")]
        public async Task<ActionResult<DestinationDTO>> PostPublicDestination([FromBody] DestinationDTO destinationDTO)
        {
            if (_context.Destinations == null)
            {
                return Problem("Entity set 'AppDbContext.Destinations'  is null.");
            }
            var destination = new Destination
            {
                Geolocation = destinationDTO.Geolocation,
                Title = destinationDTO.Title,
                Image = destinationDTO.Image,
                Description = destinationDTO.Description,
                CreatorId = destinationDTO.CreatorId,
                IsPublic = true
            };


            _context.Destinations.Add(destination);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDestination", new { id = destination.Id }, destination);
        }

        [HttpPost("private")]
        public async Task<ActionResult<Destination>> PostPrivatecDestination([FromBody] DestinationDTO destinationDTO)
        {
            if (_context.Destinations == null)
            {
                return Problem("Entity set 'AppDbContext.Destinations'  is null.");
            }

            var destination = new Destination
            {
                Geolocation = destinationDTO.Geolocation,
                Title = destinationDTO.Title,
                Image = destinationDTO.Image,
                Description = destinationDTO.Description,
                CreatorId = destinationDTO.CreatorId,
                IsPublic = false
            };

            _context.Destinations.Add(destination);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDestination", new { id = destination.Id }, destination);
        }

        [HttpPost("{UserId}/add/{DestinationId}")]
        public async Task<ActionResult<UserDestination>> AddUserDestination(int UserId, int DestinationId, UserDestinationDTO destinationDTO)
        {
            var user = await _context.Users.FindAsync(UserId);
            var destination = await _context.Users.FindAsync(DestinationId);

            if (user == null || destination == null)
            {
                return NotFound();
            }

            var UserDestination = new UserDestination
            {
                UserID = user.Id,
                DestinationId = destination.Id,
            };

            _context.UserDestinations.Add(UserDestination);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(AddUserDestination), destinationDTO);
        }



        private bool DestinationExists(int id)
        {
            return (_context.Destinations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
