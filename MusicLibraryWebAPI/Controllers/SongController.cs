using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicLibraryWebAPI.Data;
using MusicLibraryWebAPI.Models;
using System.Web.Http.Description;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MusicLibraryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : ControllerBase
    {

        private ApplicationDbContext _context;
        public SongController(ApplicationDbContext context) {
        
            _context = context;
        }



        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                var songs = _context.Songs.Select(s => new SongDto()
                {
                    Id = s.Id,
                    Artist = s.Artist,
                    Album = s.Album,
                    ReleaseDate = s.ReleaseDate,
                    Title = s.Title
                });
                if (songs == null)
                {
                    return StatusCode(400);
                }
                else
                {
                    return Ok(songs);
                }
            }
            catch
            {
                return StatusCode(500);
            }
            
        }

        // GET api/<MusicController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var song = _context.Songs.Where(s=>s.Id == id).Select(s => new SongDto()
            {
                Id = s.Id,
                Artist = s.Artist,
                Album = s.Album,
                ReleaseDate = s.ReleaseDate,
                Title = s.Title
            }).FirstOrDefault();
            return Ok(song);
        }

        // POST api/<MusicController>
        [HttpPost]
        public IActionResult Post([FromBody] SongDto song)
        {
            try
            {
                Song newSong = new Song() { 
                    Artist = song.Artist, 
                    Title = song.Title, 
                    ReleaseDate = song.ReleaseDate, 
                    Album = song.Album };
                _context.Add(newSong);
                _context.SaveChanges();
                song.Id = newSong.Id;
                return StatusCode(201, song);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT api/<MusicController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SongDto song)
        {
            try
            {
                var songInDb = _context.Songs.Where(s => s.Id == id).FirstOrDefault();
                if (songInDb != null)
                {
                    songInDb.Artist = song.Artist;
                    songInDb.Album = song.Album;
                    songInDb.ReleaseDate = song.ReleaseDate;
                    songInDb.Title = song.Title;
                    _context.Update(songInDb);
                    _context.SaveChanges();
                    return StatusCode(200, songInDb);
                }
                else
                {
                    return StatusCode(400);
                }

            }
            catch
            {
                return StatusCode(500);
            }
        }

        // DELETE api/<MusicController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var songToDelete = _context.Songs.Where(s => s.Id == id).FirstOrDefault();
                if (songToDelete != null)
                {
                    Song copyOfSong = new Song { Id = songToDelete.Id, Album = songToDelete.Album, Title = songToDelete.Title, Artist = songToDelete.Artist };
                    _context.Remove(songToDelete);
                    _context.SaveChanges();
                    return StatusCode(200, songToDelete);
                }
                else
                {
                    return StatusCode(400);
                }
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
