using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spotify.DAL;
using Spotify.Models;

namespace Spotify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly PlayerContext _context;

        public SongsController(PlayerContext context)
        {
            _context = context;
        }

        // GET: api/Songs
        [HttpGet]
        public IActionResult GetSongs ()
        {
            IList<Songs> songs = null;
            using (_context)
            {
                songs = _context.Songs.Select(s => new Songs()
                {
                    ID = s.ID,
                    Title = s.Title,
                    TrackId = s.TrackId,
                    Artists = s.Artists
                }).ToList<Songs>();
            }
            if (songs.Count == 0)
            {
                return NotFound();
            }
            return Ok(songs);
        }
       /*public async Task<ActionResult<IEnumerable<Songs>>> GetSongs()
        {
            return await _context.Songs.ToListAsync();
        }*/
        /*public IEnumerable<Songs> Get()
        {
            //return _context.Songs.OrderByDescending(p => p.ID);
            return IEnumerable.Range
            {
                new {id =1, Name="Svinninge"}, // dette er et anonymt objekt (klasse)
                new {id =2, Name="S"},
                new {id =3, Name="inge"},
            });
        }*/
        /*public JsonResult GetSongs()
        {
            return new JsonResult(new List<object>()
            {
                new {id =1, Name="Svinninge"}, // dette er et anonymt objekt (klasse)
                new {id =2, Name="S"},
                new {id =3, Name="inge"},
            });
        }*/

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Songs>> GetSongs(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var songs = await _context.Songs.FindAsync(id);

            if (songs == null)
            {
                return NotFound();
            }

            return songs;
        }

        // PUT: api/Songs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSongs(int id, Songs songs)
        {
            if (id != songs.ID)
            {
                return BadRequest();
            }

            _context.Entry(songs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Songs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Songs>> PostSongs(Songs songs)
        {
            _context.Songs.Add(songs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSongs", new { id = songs.ID }, songs);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Songs>> DeleteSongs(int id)
        {
            var songs = await _context.Songs.FindAsync(id);
            if (songs == null)
            {
                return NotFound();
            }

            _context.Songs.Remove(songs);
            await _context.SaveChangesAsync();

            return songs;
        }

        private bool SongsExists(int id)
        {
            return _context.Songs.Any(e => e.ID == id);
        }
    }
}
